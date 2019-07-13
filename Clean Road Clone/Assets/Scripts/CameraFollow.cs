using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject car;
    void FixedUpdate()
    {
        if(car.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            float smoothPos = Mathf.Lerp(transform.position.z, car.transform.position.z, 0.1f);
            transform.position = new Vector3(transform.position.x,transform.position.y,smoothPos);
        }
    }
}
