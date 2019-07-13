using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSideShow : MonoBehaviour
{
    public GameObject snow;
    public CarMovement car;


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        if(car.isCarInSnow == true)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(snow, transform.position, Random.rotation);
        }
    }
}
