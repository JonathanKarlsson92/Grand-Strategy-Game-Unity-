using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class humanMotor : MonoBehaviour {

    public LayerMask movementMask;
    NavMeshAgent agent;
    public bool homeless;
    public GameObject house;
    public bool atHome=false;
    
    public int age;
    public string status = "Nothing"; //MoveIn, Home, (Working), (MoveOut)

    private Vector3 spawnPoint=new Vector3(5f,7f,100f);
    

    //Random rnd = new Random();
    // Use this for initialization
    void Start () {
        populationManager parentScript = this.transform.parent.GetComponent<populationManager>();
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(transform.name + "to" + house.transform.name + "=" + Vector3.Distance(transform.position, house.transform.position));
        //Debug.Log(status);
        
        //when moved in remove unit (and add to house), should pre occupy
        if (status == "MoveIn")
        {
            
            if (Vector3.Distance(transform.position,house.transform.position) < 10)
            {
                //if close to house, freeze and disable unit
                gameObject.SetActive(false);
                status = "Home";
                homeless = false; //this one sets
                atHome = true;
                populationManager.addPopulation();
                
            }
        }
        //Debug.Log(Vector3.Distance(transform.position, spawnPoint));
        if (status == "MoveOut")
        {
            if (!gameObject.activeInHierarchy)
            {
                gameObject.SetActive(true);
            }
            
            if (Vector3.Distance(transform.position, spawnPoint) < 10)
            {
                populationManager.removePerson(gameObject);
            }
        }
    }
    public void setGoalObject() //remove later
    {
        agent.SetDestination(new Vector3(200, 7, 150));
    }
    public void setGoalObject(Vector3 destination)
    {
        //Debug.Log(destination);
        agent.SetDestination(destination);
        //agent.SetDestination(destination);
    }
    public void setMissionMoveIn(Vector3 destination)
    {
        status = "MoveIn";
        homeless = true;
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(spawnPoint); //WARNING HARD CODED
        agent.SetDestination(destination);
        
        //Debug.Log("MISSION IS:"+status);
        //agent.SetDestination(destination);
    }
}
