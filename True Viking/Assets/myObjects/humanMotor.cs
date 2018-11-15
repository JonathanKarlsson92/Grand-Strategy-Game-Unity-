using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class humanMotor : MonoBehaviour {

    public LayerMask movementMask;
    NavMeshAgent agent;
    public bool homeless ;
    public GameObject house;
    public bool atHome;
    public string mission; //MoveIn, Home, (Working), (MoveOut)

    //Random rnd = new Random();
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        //agent.Warp(new Vector3(200+Random.Range(-5, 5), 20, 200+Random.Range(-5, 5))); //set this to spawn point
        agent.Warp(new Vector3(5f,7f,100f)); //WARNING HARD CODED
        //Debug.Log(agent.Warp(new Vector3(10, 0, 20))); 

        homeless = true;
        atHome = false;
        mission = "Nothing";
    }
	
	// Update is called once per frame
	void Update () {
         
        if (Random.Range(0, 100) == 99)
        {
            //agent.SetDestination(agent.transform.position+ new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20))); //test

            //Debug.Log("new position");
            //Debug.Log(new Vector3(220, 16.5f, 320));
        }

        if (homeless == false)
        {
            Transform housePopList = transform.Find("Buildings");
        }
        if (mission == "MoveIn")
        {
            if (Vector3.Distance(transform.position,house.transform.position) < 1)
            {
                //if close to house, freeze and disable unit
                gameObject.SetActive(false);
                mission = "Home";
            }
        }
    }
    public void setGoalObject() //remove later
    {
        agent.SetDestination(new Vector3(200, 7, 150));
    }
    public void setGoalObject(Vector3 destination)
    {
        Debug.Log(destination);
        agent.SetDestination(destination);
        //agent.SetDestination(destination);
    }
    public void setMissionMoveIn(Vector3 destination)
    {
        Debug.Log(destination);
        agent.SetDestination(destination);
        mission = "MoveIn";
        //agent.SetDestination(destination);
    }
}
