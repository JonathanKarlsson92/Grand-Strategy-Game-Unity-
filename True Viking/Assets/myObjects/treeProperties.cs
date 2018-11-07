using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeProperties : MonoBehaviour {

    
    public int age;
    public int wood;
    public int updatefreq = 1;
    private int creationTime;
    private int tempTime = 0;
    private int localTimer = simulationTimer.getTimerSec();
    private int maxScale = 2;

   
    // Use this for initialization
    void Start () {

        creationTime = simulationTimer.getTimerSec();
        age = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

       
        localTimer = simulationTimer.getTimerSec();
        
        //Debug.Log("VL" + localTimer);
        //Debug.Log("HL" + (tempTime + updatefreq));
        if (localTimer > tempTime + updatefreq) //simulation step
        {
            tempTime = localTimer;
            age = localTimer - creationTime;


            if (gameObject.transform.localScale.x<maxScale)
            {
                gameObject.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.15f, 1.15f, 1.15f));
                //Debug.Log("Age:" + age);
                

            }
        }

       

}
}
