using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money = 10;

    public TMP_Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        money = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int newMoney)
    {
        money += newMoney;
        moneyText.text = "Money: " + money;
    }

}
