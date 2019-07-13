using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct TransformAndIndex
{
    Vector3 position;
    Quaternion rotation;
    int index;

    public Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    public Quaternion Rotation
    {
        get
        {
            return rotation;
        }
        set
        {
            rotation = value;
        }
    }

    public int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }
    
}

public class CreatePath : MonoBehaviour
{
    public int index = 0;
    public GameObject dropObject;

    bool isCarMoving = false;
    public bool isGameStarted = false;
    public bool isGameLost = false;
    bool isTimerStarted = false;

    public TransformAndIndex[] locationPoints;
    public GameObject pointPrefab;


    void Start()
    {
        locationPoints = new TransformAndIndex[200];
        locationPoints[0].Position = transform.position;
        locationPoints[0].Rotation = transform.rotation;
        locationPoints[0].Index = index;
        index++;
        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"), LoadSceneMode.Additive);
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"),LoadSceneMode.Additive);
        }
            
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level",1);
    }


    void Update()
    {
        float magnetude = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        print(magnetude);
        if (magnetude >= 0.7f && Vector3.Distance(locationPoints[index - 1].Position, gameObject.transform.position) > 4f && index < locationPoints.Length)
        {
            locationPoints[index].Position = transform.position;
            locationPoints[index].Rotation = transform.rotation;
            locationPoints[index].Index = index;
            GameObject point = Instantiate(pointPrefab, locationPoints[index].Position, locationPoints[index].Rotation) as GameObject;
            point.name = index.ToString();
            point.transform.parent = GameObject.FindGameObjectWithTag("path").transform;
            index++;
        }
        if (magnetude < 1.5f && isGameLost == false && isGameStarted == true)
        {
             print("not moving");
            isCarMoving = false;
            if (isTimerStarted == false)
            {
                StartCoroutine(timer());
                isTimerStarted = true;
            }
        }
        else
        {
            isCarMoving = true;
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(5);
        if (isCarMoving == false)
        {
            GameObject obsticle = Instantiate(dropObject, GameObject.FindGameObjectWithTag("playerCar").transform.position + new Vector3(0, 15, 0), Quaternion.identity) as GameObject;
            obsticle.GetComponent<Rigidbody>().velocity = new Vector3(0, -100, 0);
            isGameLost = true;
            isTimerStarted = false;
        }
    }
    public void StartGame()
    {
        isGameStarted = true;
    }
}
