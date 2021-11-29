using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameBehaviour : MonoBehaviour
{
    [SerializeField] int basicEarn = 5;
    [SerializeField] Shop[] shops;

    [SerializeField] Finance finance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(basicEarning());

        foreach(Shop s in shops)
        {
            StartCoroutine(shopEarning(s));
        }
    }

    IEnumerator basicEarning() {
        yield return new WaitForSeconds(1);
        finance.addMoney(basicEarn);
        StartCoroutine(basicEarning());
    }

    IEnumerator shopEarning(Shop s)
    {
        yield return new WaitForSeconds(s.getTime());
        finance.addMoney(s.getIncome());
        StartCoroutine(shopEarning(s));
    }
}
