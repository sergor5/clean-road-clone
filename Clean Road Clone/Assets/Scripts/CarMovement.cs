using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public TouchControls touchControls;
    public TouchControlsV2 TouchControlsV2;
    public GameObject leftTire;
    public GameObject rightTire;
    public GameObject trail;
    public GameObject rTrailSide;
    public GameObject lTrailSide;
    public float speed = 5.0f;
    public bool isCarInSnow = false;
    Vector3 direction;
    Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        direction.z = touchControls.direction.y;
        direction.x = touchControls.direction.x/2;

        //direction.z = TouchControlsV2.direction.y;
        //direction.x = TouchControlsV2.direction.x;
        direction.z = Mathf.Clamp(direction.z,0.75f,1.5f);

        float rotationSpeed;

        if (direction.x < 0.5f && direction.x > -0.5f)
        {
            rotationSpeed = 0.2f;
        }
        else if (direction.x < 0.8f && direction.x > -0.8f)
        {
            rotationSpeed = 0.3f;
        }else
        {
            rotationSpeed = 0.6f;
        }

        transform.forward = Vector3.Lerp(transform.forward, direction, rotationSpeed);

        leftTire.transform.forward = direction;
        rightTire.transform.forward = direction;

        rb.velocity = transform.forward * speed;
        rb.angularVelocity = Vector3.zero;

        if (isCarInSnow == true)
        {
            //trail.GetComponent<TrailRenderer>().emitting = true;
            lTrailSide.SetActive(true);
            rTrailSide.SetActive(true);

        }
        else
        {
            //trail.GetComponent<TrailRenderer>().emitting = false;
            lTrailSide.SetActive(false);
            rTrailSide.SetActive(false);
        }
    }
}
