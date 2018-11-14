using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class populationManager : MonoBehaviour {

    public static int population = 0;
    public Text populationText;
    public GameObject spawnee;
    public GameObject spawnPoint;

    private GameObject newPerson;
    private static int houseCapacity=0;
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
            //spawn people
            newPerson=Instantiate(spawnee);
            population += 1;
        }
    }
    public static void addHouseCapacity(int capacity)
    {
        houseCapacity += capacity;
    }
}
