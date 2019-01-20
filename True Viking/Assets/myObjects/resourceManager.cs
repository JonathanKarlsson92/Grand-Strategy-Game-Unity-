using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resourceManager : MonoBehaviour {
    // Script that keeps track on resources available
    public static int money=1000;

    public static int wood = 0;
    public static int furnitures = 0;

    public static int iron = 0;
    public static int tools = 0;
    public static int weapons = 0;

    public static int wheat = 0;
    public static int bread = 0;
    
    public static int honey = 0;
    public static int mead = 0;

    public static int fish = 0;

    public static int hemp = 0;
    public static int rope = 0;

    public static int meat = 0;

    public static int oil = 0;



    public Text goldText;
	
	public static void AddExpense(int cost)
    {
        //remove cost from treasury
        money -= cost;
        Debug.Log(money);
    }
    public static void AddIncome(int income)
    {
        money += income;
    }
    void Start()
    {
        goldText.text = "";
    }
    void Update()
    {
        goldText.text = money.ToString();
    }
}
