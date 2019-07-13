using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    int health = 100;
    public int damage = 25;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "shovel")
        {
            health -= damage;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
