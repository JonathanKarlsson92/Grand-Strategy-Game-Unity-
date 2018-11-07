using System.Collections;
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
    public bool isBuilding = false;
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
            Physics.Raycast(ray, out hit);

            //visualize objects on ground while building
            newBuild.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            if (startNode == false)
            {
                //place between
                newBuildSupport.transform.position = new Vector3((newBuild.transform.position.x + prevPos.x) / 2, (newBuild.transform.position.y + prevPos.y) / 2, (newBuild.transform.position.z + prevPos.z) / 2);
                Debug.Log(newBuildSupport.transform.position);

                //Rotation(works ok for now)
                var dir = newBuild.transform.position - prevPos;
                newBuildSupport.transform.LookAt(newBuild.transform);
                Vector3 scale = newBuildSupport.transform.localScale;
                scale.z = dir.magnitude;
                newBuildSupport.transform.localScale = scale;
                
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
                
                Debug.Log("Number of buildings" + createdObjects.Count);

                startNode = false; //not initial node anymore
            }

            //cancel/end build
            if (Input.GetMouseButtonDown(1))
            {
                isBuilding = false;
                //createdObjects.Remove(newBuild); //should it not be a global list?? or persistent

                //remove and destroy
                createdObjects.Remove(newBuild);
                Destroy(newBuild);
                Destroy(newBuildSupport);
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
}
