using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class natureSimulator : MonoBehaviour {
    //add this script to new trees and objects created

    simulationTimer sim;
    //TODO change to Nature object containing model, position etc
    public static List<GameObject> objectList; //static so the object list is stored
    public GameObject spawner;

    private int localTimer=0;
    private float minSze = 0.1f;
    private float maxSize = 2f;
    Random rnd = new Random();
    

    int tempTime = 0; // added to update only sometimes
    
    //public GameObject spawnee;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //localTimer = gameObject.GetComponent<simulationTimer>().getTimerSec(); //works if they are attached to the same object
        //localTimer = GetComponent<simulationTimer>().getTimerSec();
        localTimer = simulationTimer.getTimerSec();



        if (localTimer >tempTime+5) //simulation step
        {
            tempTime = localTimer;
            Transform treeList = transform.Find("Trees");

            int number = treeList.childCount; //number of trees in trees folder
            for (int i = 0; i < number; i++)
            {
                var tempObj=Instantiate(spawner,treeList.GetChild(i).position + new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f)), treeList.GetChild(i).rotation);

                // var tempObj=Instantiate(spawner, treeObj.position + new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f)), treeObj.rotation);

                tempObj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                tempObj.transform.parent = treeList;
            }

            //Transform treeObj = gameObject.GetComponentInChildren(typeof(Transform)) as Transform;
            Debug.Log("tree folder: " +treeList.childCount);
            
            //Debug.Log("Number of trees"+treeObj.childCount);
            /*for (int i=0; i< treeObj.childCount; i++) //Handle all trees
            {
                //treeObj.GetChild(i).position; // object i

                //randomly instantiate
                //create new object with respect to parent
                Instantiate(spawner, treeObj.GetChild(i).position + new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f)), treeObj.GetChild(i).rotation);
                spawner.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                //update object i
                //treeObj.GetChild(i).localScale = Vector3.Scale(treeObj.GetChild(i).localScale, new Vector3(1.05f, 1.05f, 1.05f));
            }*/
            
            //increase size of object
            /*if (spawner.transform.localScale.x < maxSize)
            {
                spawner.transform.localScale = Vector3.Scale(spawner.transform.localScale, new Vector3(1.05f, 1.05f, 1.05f));
            }*/

            //print to console
            //Debug.Log(localTimer);
        }
	}

    //call when adding a tree
    public void AddObject(GameObject natureObject)
    {
        //add object to nature list
        objectList.Add(natureObject);
    }

    //call when removing a tree
    public void RemoveObject(GameObject natureObject)
    {
        //add object to nature list
        objectList.Remove(natureObject);
    }
}
