using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resourceManager : MonoBehaviour {
    // Script that keeps track on resources available
    public static int money=1000;
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
    private void Update()
    {
        goldText.text = money.ToString();
    }
}
