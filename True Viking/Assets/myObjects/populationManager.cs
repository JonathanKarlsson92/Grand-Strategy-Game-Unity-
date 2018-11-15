using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//attached to
public class populationManager : MonoBehaviour {

    public static int population = 0;
    public Text populationText;
    public GameObject spawnee;
    public GameObject spawnPoint;

    private GameObject newPerson;
    private humanMotor h_motor;
    private static int houseCapacity=0;
    private GameObject emptyHouse;

    private int peopleCounter=0;

    private buildingProperty houseProperty;
    //private Transform populationSpawner = transform.Find("populationSpawner");
    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
    private void Update()
    {
       populationText.text = population.ToString()+"/"+houseCapacity.ToString();

        //quick test to spawn people up to houseCapacity
        if (population < houseCapacity)
        {
            //find empty house and spawn person
            Transform housePopList = transform.Find("Buildings");
            for(int i=0;i<housePopList.childCount; i++)
            {
                //find house with empty slot
                houseProperty = housePopList.GetChild(i).GetComponent<buildingProperty>();
                if (houseProperty.inhabitants.Count < houseProperty.populationCapacity)
                {
                    //if house has space

                    //spawn people
                    var newPerson = Instantiate(spawnee,new Vector3(5,7,100) ,Quaternion.identity);
                    newPerson.name = nameGenerator();
                    newPerson.transform.parent = transform.Find("People");
                    //Debug.Log(newPerson.gameObject.transform.position);
                    //get script of unit
                        //newPerson.GetComponent<humanMotor>().setGoalObject();
                    //tell where to go
                    //Debug.Log(housePopList.GetChild(i).gameObject);
                    //h_motor.setGoalObject(housePopList.GetChild(i).position);
                    //h_motor.setGoalObject();
                    population += 1;
                    

                }
            }

            //get homeless people and find them a house(if free space)
            Transform peopleList = transform.Find("People");
            for (int i = 0; i < peopleList.childCount; i++)
            {
                //go through all people(works)
                GameObject person = peopleList.GetChild(i).gameObject;
                if(person.GetComponent<humanMotor>().homeless == true){
                    //person.GetComponent<humanMotor>().homeless = false;
                    person.GetComponent<humanMotor>().house=findFreeHouse(person); //assign house, null if nothing is found
                    if (person.GetComponent<humanMotor>().house != null)
                    {
                        person.GetComponent<humanMotor>().homeless = false;
                        person.GetComponent<humanMotor>().setMissionMoveIn(person.GetComponent<humanMotor>().house.transform.position); //move in
                    }
                }
                //Debug.Log(person.transform.position);
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

        Transform houseList = transform.Find("Buildings");
        for (int i = 0; i < houseList.childCount; i++)
        {
            //go through all people(works)
            GameObject house = houseList.GetChild(i).gameObject;
            if (house.GetComponent<buildingProperty>().populationCapacity >house.GetComponent<buildingProperty>().inhabitants.Count) //if free space in building
            {
                house.GetComponent<buildingProperty>().addPerson(person); //add person in house
                return house;

            }
            
            Debug.Log(person.transform.position);
        }
        return null; //if nothing is found
    }
    private string nameGenerator()
    {
        peopleCounter++;
        return "unit" + peopleCounter.ToString();
        
    }
}
