﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//attached to
public class populationManager : MonoBehaviour {

    public static int population = 0;
    public static int popChange = 0;
    public static Transform peopleList;

    public Text populationText;
    public GameObject spawnee;
    public GameObject spawnPoint;
    public static Transform housePopList;

    private GameObject newPerson;
    private humanMotor h_motor;
    private static int houseCapacity=0;
    private GameObject emptyHouse;

    private int peopleCounter=0;

    private int r; //random variable
    System.Random rnd = new System.Random();

    //private Transform populationSpawner = transform.Find("populationSpawner");
    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
    private void Update()
    {
       //update UI
       populationText.text = population.ToString()+"/"+houseCapacity.ToString()+ "+"+popChange;

        //Spawn people up to houseCapacity
        if (population+popChange < houseCapacity)
        {
            r= rnd.Next(1, 100);
            if ( r> 90) //1% chance every frame
            {

                //Debug.Log("person moving in!");

                //spawn people
                newPerson = Instantiate(spawnee, new Vector3(5, 7, 100), Quaternion.identity); //hard coded
                
                //set properties
                newPerson.name = nameGenerator();
                newPerson.transform.parent = transform.Find("People");

                r = rnd.Next(100, 200);
                newPerson.GetComponent<humanMotor>().setWealth(100);

                r = rnd.Next(10, 40);
                newPerson.GetComponent<humanMotor>().setAge(r);

                // find house
                newPerson.GetComponent<humanMotor>().house = findFreeHouse(newPerson); //assign house, null if nothing is found

                //set misson
                //newPerson.GetComponent<humanMotor>().status = "MoveIn";
                newPerson.GetComponent<humanMotor>().setMissionMoveIn(newPerson.GetComponent<humanMotor>().house.transform.position); //move in

                popChange += 1;
            }

        }

    }
    public static void addHouseCapacity(int capacity)
    {
        houseCapacity += capacity;
    }
    public GameObject findFreeHouse(GameObject person)
    {
        /// finds a house for a person, connects it to the house and returns the gameobject of the house 
        housePopList = transform.Find("Buildings");
        for (int i = 0; i < housePopList.childCount; i++)
        {
            //find house with empty slot
            buildingProperty houseProperty = housePopList.GetChild(i).GetComponent<buildingProperty>();
            if (houseProperty.reservedBy < houseProperty.populationCapacity)
            {
                //if house has space return house
                //popChange += 1; // UI
                houseProperty.reservedBy += 1;
                //Debug.Log("+1");
                return housePopList.GetChild(i).gameObject;

            }
        }
        Debug.Log("Error: No house found");
        return null;
        
    }
 

    public static void addInHouse(GameObject person) //add gameobject to house
    {
        GameObject house=person.GetComponent<humanMotor>().house;
        house.GetComponent<buildingProperty>().addPerson(person); //add to house list
    }
    private string nameGenerator()
    {
        peopleCounter++;
        return "unit" + peopleCounter.ToString();
        
    }
    
    //called from external classes

    public static void removePerson(GameObject person)
    {
        Destroy(peopleList.transform.Find(person.name));
    }

    public static void addPopulation() //arrived at house
    {
        population += 1;
        popChange -= 1;
    }
    
}


/*public void addInHouse(GameObject person) //obsolete
{
    Transform houseList = transform.Find("Buildings");
    for (int i = 0; i < houseList.childCount; i++)
    {
        //go through all people(works)
        GameObject house = houseList.GetChild(i).gameObject;
        if (house.GetComponent<buildingProperty>().populationCapacity > house.GetComponent<buildingProperty>().inhabitants.Count) //if free space in building
        {
            house.GetComponent<buildingProperty>().addPerson(person); //add person in house
                                                                      //return house;

        }

        //Debug.Log(person.transform.position);
    }
    //return null; //if nothing is found
}*/