using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderRescuedCars : MonoBehaviour
{
    public void OrderCars()
    {
        int childCount = transform.childCount;

        if(childCount > 0)
        {
            for (int i = 0; i < childCount; i++)
            {
                transform.GetChild(i).transform.name = (int.Parse(transform.GetChild(i).transform.name) + 1).ToString();
                transform.GetChild(i).GetComponent<RescuedCarLogic>().SetMultiplier();
            }
        }
    }
}
