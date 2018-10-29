using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteraction : MonoBehaviour {

    //public LayerMask mask;
    Camera cam;

    // object to spawn
    public GameObject spawnee;
    public int buildID;
    private GameObject newBuild;
    // list that holds all created objects - deleate all instances if desired
    public List<GameObject> createdObjects = new List<GameObject>();

    public bool isBuilding = false;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        isBuilding = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (isBuilding)
        {
            //plot building on mouse
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            //GameObject newBuild = (GameObject)Instantiate(spawnee, hit.point, Quaternion.Euler(new Vector3(-90, 0, 0)));
            newBuild.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            //Rotate object
            if (Input.GetKey("q"))
            {
                newBuild.transform.RotateAround(newBuild.transform.position, Vector3.up, -1);
            }
            if (Input.GetKey("e"))
            {
                newBuild.transform.RotateAround(newBuild.transform.position, Vector3.up, 1);
            }

            if (Input.GetMouseButtonDown(1))
            {
                isBuilding = false;
                createdObjects.Remove(newBuild); //should it not be a global list?? or persistent

                //remove and destroy
                createdObjects.Remove(newBuild);
                Destroy(newBuild);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("we hit" + hit.collider.name + " " + hit.point);
            }
            //Debug.Log("we clicked");

            if (isBuilding)
            {
                //call build function
                //spawner(true, hit);

                // generate object
                //GameObject newBuild = (GameObject)Instantiate(spawnee, hit.point, Quaternion.Euler(new Vector3(-90,0,0)));
                //createdObjects.Add(newBuild);
                isBuilding = false;
                createdObjects.Add(spawnee);
                Debug.Log("house built");
            }
        }
        
        
    }

    //function to handle the spawn of new buildings
    /*public void spawner(bool isBuilding, RaycastHit hit)
    {
        // todo add a delay
        if (isBuilding)
        {
            Debug.Log("In building mode");
            if (Input.GetMouseButton(0))
            {
               
                //create and add to list of all created
                GameObject newBuild=(GameObject)Instantiate(spawnee, hit.point, Quaternion.identity);
                createdObjects.Add(newBuild);
                isBuilding = false;
            }
        }
        if (!isBuilding)
        {
            // TODO solve the mouse click later
            if (Input.GetMouseButton(1))
            {
                //Debug.Log("spawner running" + isBuilding);
                isBuilding = true;
            }
        }
        
    }*/

    public void activateBuilder()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            Debug.Log("Button1 clicked");
            newBuild = Instantiate(spawnee);
        }
    }
   /* public void activateBuilderTree()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            Debug.Log("Button2 clicked");
        }
    }*/
}
