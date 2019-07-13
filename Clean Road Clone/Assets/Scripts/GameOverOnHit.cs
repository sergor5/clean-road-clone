using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnHit : MonoBehaviour
{
    CarMovement carMovement;
    GameObject lostText;
    SetLevel setLevel;
    public int level = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playerCar")
        {
            GameObject playerCar = GameObject.FindGameObjectWithTag("shovel");
            playerCar.GetComponent<CarMovement>().enabled = false;
            Rigidbody rb = gameObject.transform.parent.GetComponent<Rigidbody>();
            transform.parent.transform.SetParent(GameObject.FindGameObjectWithTag("playerCar").transform);
            lostText = GameObject.FindGameObjectWithTag("lostText").transform.GetChild(0).gameObject;
            lostText.SetActive(true);
            StartCoroutine(reloadScene());
        }
    }
    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(2);
        setLevel = GameObject.FindGameObjectWithTag("setLevel").GetComponent<SetLevel>();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
