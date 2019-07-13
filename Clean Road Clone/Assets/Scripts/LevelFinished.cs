using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    CarMovement carMovement;
    public GameObject confetti;
    GameObject winText;
    bool startedLoading = false;
    void Start()
    {
        confetti = GameObject.Find("Confetti").transform.GetChild(0).gameObject;
        winText = GameObject.FindGameObjectWithTag("wintext").transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "shovel")
        {
            carMovement = other.gameObject.GetComponent<CarMovement>();
            carMovement.enabled = false;
            winText.SetActive(true);
            confetti.SetActive(true);
            StartCoroutine(loadScene());
            startedLoading = true;
        }
    }
    IEnumerator loadScene()
    {
        if(startedLoading == false)
        {
            yield return new WaitForSeconds(2);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") < 5 ? PlayerPrefs.GetInt("Level") + 1 : PlayerPrefs.GetInt("Level"));
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            
        }
    }
}
