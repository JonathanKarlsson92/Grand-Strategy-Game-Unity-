using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadNetwork : MonoBehaviour {

   

    // list that holds all created objects - deleate all instances if desired
    public List<GameObject> network = new List<GameObject>();


    //Add Nodes
    public void AddNode(Node node)
    {

    }
    //Add Transitions
    public void AddTransition(Vector3 nodeM,Vector3 nodeN)
    {

    }
    //Remove Node

    //Remove Transition

}

public class Transition
{
    //declare all transition components
    int transitionID;
    Node nodeM;
    Node nodeN;
    float width;
    float cost; //speed of road

    //get and set functions
    
}
public class Node
{
    //declare all node components
    int nodeID;
    Vector3 position;

    //get and set functions
}
