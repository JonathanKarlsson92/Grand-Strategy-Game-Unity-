using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour {

    roadNetwork roadNetwork;
    Camera cam;
    GUI line;

    // public id
    public GameObject spawnee; //temp object
    private GameObject newBuild; //object to store
    public bool isBuilding = false;
    public int buildID;
    // list that holds all created objects - deleate all instances if desired
    public List<GameObject> createdObjects = new List<GameObject>();


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
            newBuild.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            

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
            if (isBuilding)
            {
                createdObjects.Add(spawnee);
                newBuild = Instantiate(spawnee);
                if (createdObjects.Count > 1)   //quick fix for test, change later
                {
                    
                }
                Debug.Log("Number of buildings" + createdObjects.Count);
            }
        }
        
    }

    //activate manager
    public void activateBuilder()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            Debug.Log("Button1 clicked");
            newBuild = Instantiate(spawnee);
        }
    }
}
