using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class humanMotor : MonoBehaviour {

    public LayerMask movementMask;
    NavMeshAgent agent;
    //Random rnd = new Random();
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(new Vector3(200+Random.Range(-5, 5), 20, 200+Random.Range(-5, 5))); //set this to spawn point
        //Debug.Log(agent.Warp(new Vector3(10, 0, 20))); 
    }
	
	// Update is called once per frame
	void Update () {
        
        if(Random.Range(0, 100) == 99)
        {
            agent.SetDestination(agent.transform.position+ new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20))); //test
            //Debug.Log("new position");
        }
	}
}
