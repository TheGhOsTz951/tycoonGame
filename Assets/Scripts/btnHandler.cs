using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnHandler : MonoBehaviour
{
    public void buyShop(Shop s)
    {
        s.buyShop(1);
    }
}
