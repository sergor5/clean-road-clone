using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOutOfSight : MonoBehaviour
{
    GameObject camera;
    private void Start()
    {
        camera = Camera.main.transform.parent.gameObject;
    }

    void Update()
    {
        if((camera.transform.position.z - transform.position.z) > 30)
        {
            Destroy(gameObject);
        }
    }
}
