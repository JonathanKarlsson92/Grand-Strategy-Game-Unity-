using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// called when a construction button is clicked and when isPlayerBuilding==false
public class spawner : MonoBehaviour {

    public Transform spawnPos;
    public GameObject spawnee;
    public bool isBuilding = false;

    private
	// Update is called once per frame
	void Update () {
        

        // todo add a delay
        if (isBuilding)
        {
            Debug.Log("In building mode");
            if (Input.GetMouseButton(0))
            {
                
                Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
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
    }
}
