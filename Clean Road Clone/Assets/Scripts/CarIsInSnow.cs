using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIsInSnow : MonoBehaviour
{

    GameObject shovel;
    CarMovement carMovement;
    GameObject trail;
    private void Start()
    {
        trail = GameObject.FindGameObjectWithTag("trail");
        shovel= GameObject.FindGameObjectWithTag("shovel");
        carMovement = shovel.GetComponent<CarMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == shovel)
        {
        print(other);
            carMovement.isCarInSnow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == shovel)
        {
            carMovement.isCarInSnow = false;
        }
    }

}
