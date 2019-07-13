using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescuedCarLogic : MonoBehaviour
{
    CreatePath createPath;
    Rigidbody rb;

    public float speed = 10.0f;


    bool gotToTarget = false;
    bool gotFirstIndex = false;
    int targetIndex,firstIndex;
    float interpolation = 0.0f;

    public int multiplier = 0;

    // Start is called before the first frame update
    void Start()
    {
        createPath = GameObject.FindGameObjectWithTag("shovel").GetComponent<CreatePath>();
        rb = gameObject.GetComponent<Rigidbody>();
        transform.parent = GameObject.FindGameObjectWithTag("rescuedCars").transform;
        transform.name = multiplier.ToString();
        firstIndex = createPath.index - 2;
        targetIndex = firstIndex;
        gotFirstIndex = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetMultiplier();
        if (createPath.index > 1 && gotToTarget == true && targetIndex < (createPath.index - ( 3 + multiplier*2)))
        {
            if (gotFirstIndex == false)
            {
                firstIndex = createPath.index - 2;
                targetIndex = firstIndex;
                gotFirstIndex = true;
            }
            else
            {
                targetIndex++;
                gotToTarget = false;
            }
        }
        if (gotToTarget == false && createPath.locationPoints[targetIndex].Position != null)
        {
            interpolation = 10f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, createPath.locationPoints[targetIndex].Position,interpolation);
            Vector3 lookAt = createPath.locationPoints[targetIndex+1].Position - transform.position;
            transform.forward = Vector3.Lerp(transform.forward, lookAt, 1f * Time.deltaTime);

            if (transform.position == createPath.locationPoints[targetIndex].Position)
            {
                gotToTarget = true;
                interpolation = 0.0f;
            }
        }
    }
    public void SetMultiplier()
    {
        multiplier = int.Parse(transform.name);
    }
}
