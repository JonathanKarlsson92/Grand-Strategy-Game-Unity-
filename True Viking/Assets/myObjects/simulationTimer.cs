using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class simulationTimer : MonoBehaviour {
    //Keeps track of time
    public static int timer=0;
	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if ((int)Time.time > timer)
        {
            timer =(int)Time.time;
            //Debug.Log(timer);
        }
        
	}

    //get timer in seconds
    public static int getTimerSec()
    {
        return timer;
    }
}
