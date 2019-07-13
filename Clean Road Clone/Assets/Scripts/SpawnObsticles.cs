using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticles : MonoBehaviour
{
    int childCount;
    bool activated = false;
    public GameObject dropObject;
    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "shovel" && activated == false)
        {
            StartCoroutine(DropObsticles());
            activated = true;
        }
    }

    IEnumerator DropObsticles()
    {
        for (int i = 0; i < childCount; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject obsticle = Instantiate(dropObject,transform.GetChild(i).transform.position + new Vector3(0,15,0),Quaternion.identity) as GameObject;
            obsticle.GetComponent<Rigidbody>().velocity = new Vector3(0,-100,0);
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
