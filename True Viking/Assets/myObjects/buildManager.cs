using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour {

    roadNetwork roadNetwork;
    Camera cam;
    GUI line;

    // public id
    public GameObject spawnee; //temp object
    public bool isBuilding = false;
    public int buildID;
    public List<GameObject> createdObjects = new List<GameObject>();

    //public GameObject spawneeSupport; //temp object help for walls and roads etc
    private GameObject newBuild; //object to store
    private GameObject newBuildSupport; //support object to store
    private Vector3 prevPos; //store last position when building roads, walls etc
    private bool startNode=false;
    private Quaternion buildRotation;
    private static int buildingCounter; // for naming
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        isBuilding = false;
        buildingCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (isBuilding)
        {
            //newBuild.GetComponent<Collider>().
            //Debug.Log(buildRotation);
            //plot building on mouse
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Physics.Raycast(ray, out hit); //15 bygger inte på mark men på (mur och staket)
            //LayerMask mask = LayerMask.GetMask("Ground");

            // Test
            // Bit shift the index of the layer (15) to get a bit mask
            int layerMask = 1 << 15; //choose building layer or other

            // This would cast rays only against colliders in layer 15.
            // But instead we want to collide against everything except layer 15. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }

            // END test

            //int skip1n2 = ~((1 <<15));
            //Physics.Raycast(transform.position, transform.forward, out hit, 100, skip1n2);

            //visualize objects on ground while building
            //newBuild.transform.rotation = Quaternion.Euler(buildRotation);
            //Debug.Log(transform.parent.name);
            newBuild.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            /*if (buildID > 4) //temporary, change this such that it appies to current building
            { 
                if (startNode == false)
                {
                    //place between
                    newBuildSupport.transform.position = new Vector3((newBuild.transform.position.x + prevPos.x) / 2, (newBuild.transform.position.y + prevPos.y) / 2, (newBuild.transform.position.z + prevPos.z) / 2);
                    //Debug.Log(newBuildSupport.transform.position);

                    //Rotation(works ok for now)
                    var dir = newBuild.transform.position - prevPos;
                    newBuildSupport.transform.LookAt(newBuild.transform);
                    Vector3 scale = newBuildSupport.transform.localScale;
                    scale.z = dir.magnitude;
                    newBuildSupport.transform.localScale = scale;

                }
            } */


            //if colliding with other house
            if (newBuild.GetComponent<collisionScript>().collision == true)
            {
                //Debug.Log("collision with building");
                newBuild.GetComponent<MeshRenderer>().material.color = new Color(2.0f, 1.0f, 1.0f, 1f); //red
            }
            else
            {
                newBuild.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 2.0f, 1.0f, 1f); //red
            }

            //place object
            if (Input.GetMouseButtonDown(0))
            {
                if (newBuild.GetComponent<collisionScript>().collision == false)
                {
                    //in build mode
                    createdObjects.Add(spawnee); //change this later, not everything is added

                    prevPos = hit.point; //store point where object is placed
                                         //Debug.Log("prev: " + prevPos);

                    // create new building(repeat)
                    //buildRotation = newBuild.transform.localRotation;

                    //save and set settings
                    newBuild.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1f); //set color of temp house
                                                                                                            //newBuild.GetComponent<Collider>().enabled = true; //not working)

                    newBuild = Instantiate(spawnee, newBuild.transform.position, newBuild.transform.rotation);
                    newBuild.name = nameGenerator();//get unique name
                                                    //newBuild.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 2.0f, 1.0f, 1.0f);
                                                    //newBuild.GetComponent<BoxCollider>().enabled = true;
                    newBuild.transform.parent = transform.root.Find("Buildings");
                    //newBuild.GetComponent<MeshCollider>().enabled = true;

                    //newBuildSupport = Instantiate(spawneeSupport);
                    if (buildID > 4)
                    {
                        startNode = false; //not initial node anymore
                    }

                    //Debug.Log("Number of buildings" + createdObjects.Count);



                    //test: activate box collider
                    //newBuildSupport.GetComponent<Collider>().enabled = true;



                    // Add expense
                    resourceManager.AddExpense(100);
                    //add house in populationManager
                    populationManager.addHouseCapacity(10);
                    //populationManager.
                }
            }

            //cancel/end build
            if (Input.GetMouseButtonDown(1))
            {
                isBuilding = false;
                buildingCounter -= 1;
                //createdObjects.Remove(newBuild); //should it not be a global list?? or persistent

                //remove and destroy
                createdObjects.Remove(newBuild);
                Destroy(newBuild);
                if (buildID > 4)
                {
                    Destroy(newBuildSupport);
                }
                   
            }
            //Rotate object
            if (Input.GetKey("q"))
            {
                newBuild.transform.RotateAround(spawnee.transform.position, Vector3.up, -1);
            }
            if (Input.GetKey("e"))
            {
                newBuild.transform.RotateAround(spawnee.transform.position, Vector3.up, 1);
            }
            
        }
        
    }

    //activate manager
    public void activateBuilder()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            startNode = true;
            //Debug.Log("Button1 clicked");

            newBuild = Instantiate(spawnee);
            newBuild.name = nameGenerator();//get unique name
            newBuild.transform.parent = transform.root.Find("Buildings");
            newBuild.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 2.0f, 1.0f, 1f); //set color of temp house
            //newBuild.GetComponent<MeshCollider>().enabled = false;
        }
    }
    public void activateBuilder(int buildID) //called from activateBuildManager
    {
        
    }
    private string nameGenerator()
    {
        buildingCounter++;
        return "building" + buildingCounter.ToString();

    }
    
}




// backup 13/11
/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour {

    roadNetwork roadNetwork;
    Camera cam;
    GUI line;

    // public id
    public GameObject spawnee; //temp object
    public GameObject spawneeSupport; //temp object help for walls and roads etc
    private GameObject newBuild; //object to store
    private GameObject newBuildSupport; //support object to store
    private bool isBuilding = false;
    public int buildID;
    // list that holds all created objects - deleate all instances if desired
    public List<GameObject> createdObjects = new List<GameObject>();
    private Vector3 prevPos; //store last position when building roads, walls etc
    private bool startNode=false;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        isBuilding = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isBuilding)
        {
            //plot building on mouse
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit); //15 bygger inte på mark men på (mur och staket)

            //visualize objects on ground while building
            newBuild.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            if (buildID > 4) //temporary, change this such that it appies to current building
            { 
                if (startNode == false)
                {
                    //place between
                    newBuildSupport.transform.position = new Vector3((newBuild.transform.position.x + prevPos.x) / 2, (newBuild.transform.position.y + prevPos.y) / 2, (newBuild.transform.position.z + prevPos.z) / 2);
                    //Debug.Log(newBuildSupport.transform.position);

                    //Rotation(works ok for now)
                    var dir = newBuild.transform.position - prevPos;
                    newBuildSupport.transform.LookAt(newBuild.transform);
                    Vector3 scale = newBuildSupport.transform.localScale;
                    scale.z = dir.magnitude;
                    newBuildSupport.transform.localScale = scale;

                }
            } 
            
            

            
            //place object
            if (Input.GetMouseButtonDown(0))
            {
                //in build mode
                createdObjects.Add(spawnee); //change this later, not everything is added

                prevPos = hit.point; //store point where object is placed
                Debug.Log("prev: " + prevPos);
                newBuild = Instantiate(spawnee);
                newBuildSupport = Instantiate(spawneeSupport);
                if (buildID > 4)
                {
                    startNode = false; //not initial node anymore
                }
                    
                //Debug.Log("Number of buildings" + createdObjects.Count);

                

                //test: activate box collider

                //newBuildSupport.GetComponent<Collider>().enabled = true;
            }

            //cancel/end build
            if (Input.GetMouseButtonDown(1))
            {
                isBuilding = false;
                //createdObjects.Remove(newBuild); //should it not be a global list?? or persistent

                //remove and destroy
                createdObjects.Remove(newBuild);
                Destroy(newBuild);
                if (buildID > 4)
                {
                    Destroy(newBuildSupport);
                }
                   
            }
        }
    }

    //activate manager
    public void activateBuilder()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            startNode = true;
            Debug.Log("Button1 clicked");
            newBuild = Instantiate(spawnee);
        }
    }
}*/
