using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class humanAnimator : MonoBehaviour {

    const float locomotionAnimatoionSmoothTime=.1f;

    NavMeshAgent agent;
    Animator animator;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimatoionSmoothTime, Time.deltaTime);
        //Debug.Log(speedPercent);
        
	}
}
