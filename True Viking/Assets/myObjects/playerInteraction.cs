using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class playerInteraction : MonoBehaviour {

    //public LayerMask mask;
    Camera cam;
    //buildManager build;

    public Text objectText; //UI
    private string objText; //string here
    //GameObject bManager=GameObject.Find()
    
    // Use this for initialization
    void Start () {
        cam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << 15; //building layer

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                //if target is a building
                //Debug.Log(transform.name);
                //Debug.Log(transform.GetComponent<buildManager2>().isBuilding);


                if (transform.GetComponent<buildManager2>().isBuilding == false) //attached to master
                {
                    Transform a = transform.Find("Object Panel");
                    //get gameobject
                    GameObject building = hit.transform.gameObject;
                    //store name and building properties

                    objText = "Name: "+building.name + Environment.NewLine+
                        "Inhabitants: " +building.GetComponent<buildingProperty>().inhabitants.Count + Environment.NewLine+
                        " Reserved: " + building.GetComponent<buildingProperty>().reservedBy + Environment.NewLine +
                        " Capacity: " + building.GetComponent<buildingProperty>().populationCapacity;

                    //objText = objText.Replace("@", "@" + Environment.NewLine);
                    //objText = "hello@line 2@line3@";
                    //objText = objText.Replace("@", "@" + Environment.NewLine);

                    objectText.text = objText;
                    transform.GetComponent<UIManager>().objectText = objectText;  // should have get and set methods instead
                }

            }else{
                Transform a = transform.Find("Object Panel");
                //objectText.text = "";
                //transform.GetComponent<UIManager>().objectText = objectText;
            }
        }
    }
}
