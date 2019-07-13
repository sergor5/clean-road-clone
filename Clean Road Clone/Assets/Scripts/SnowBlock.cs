using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBlock : MonoBehaviour
{
    public RescuedCarLogic rescuedCarLogic;
    OrderRescuedCars orderRescuedCars;
    public ParticleSystem smile;
    private void Start()
    {
        orderRescuedCars = GameObject.FindGameObjectWithTag("rescuedCars").GetComponent<OrderRescuedCars>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "shovel")
        {
            rescuedCarLogic.gameObject.transform.parent = null;
            rescuedCarLogic.enabled = true;
            smile.gameObject.SetActive(true);
            Destroy(gameObject);
            orderRescuedCars.OrderCars();
        }
    }
}
