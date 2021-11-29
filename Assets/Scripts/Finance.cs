using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finance : MonoBehaviour
{
    [SerializeField] Text moneyText;
    private int actualMoney;

    public Finance()
    {
        this.actualMoney = 0;
    }

    public void addMoney(int amount)
    {
        this.actualMoney += amount;
        setMoneyText();
    }

    public bool canRemoveMoney(int amount)
    {
        if (amount <= actualMoney) return true;
        else return false;
    }

    public void removeMoney(int amount)
    {
        if(canRemoveMoney(amount))
        {
            actualMoney -= amount;
            setMoneyText();
        }
    }

    public void setMoneyText()
    {
        moneyText.GetComponent<Text>().text = "Balance: " + getActualMoney().ToString() + "$";
    }

    public float getActualMoney()
    {
        return actualMoney;
    }
}
