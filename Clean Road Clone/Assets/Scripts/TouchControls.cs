using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    Vector3 firstPos;
    Vector3 secondPos;
    Vector3 clampedFirstPos;
    Vector3 clampedSecondPos;
    public Vector3 direction;
    public bool firstTouch = false;

    private LineRenderer line;
    public Material material;
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch newTouch = Input.GetTouch(0);
            if (newTouch.phase == TouchPhase.Began)
            {
                if (line == null)
                {
                    //create the line
                    //createLine();
                }
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(newTouch.position);
                if(Physics.Raycast(ray,out hit) && firstTouch == false){
                    firstPos = hit.point;
                    clampedFirstPos = hit.transform.InverseTransformPoint(firstPos);
                    
                    secondPos = hit.point;
                    

                    //line.SetPosition(0, firstPos);
                    //line.SetPosition(1, secondPos);
                    firstTouch = true;
                }
            }
            if(newTouch.phase == TouchPhase.Moved)
            {
                RaycastHit hit2;
                Ray ray2 = Camera.main.ScreenPointToRay(newTouch.position);
                if (Physics.Raycast(ray2, out hit2) && firstTouch == true)
                {
                    secondPos = hit2.point;
                    clampedSecondPos = hit2.transform.InverseTransformPoint(secondPos);
                    Vector3 offset;
                    offset = clampedSecondPos - clampedFirstPos;
                    direction = Vector3.ClampMagnitude(offset,3.0f);
                    float X, Y, Z;
                    X = Mathf.Round(direction.x * 100) / 100;
                    Y = Mathf.Round(direction.y * 100) / 100;
                    Z = Mathf.Round(direction.z * 100) / 100;
                    direction = new Vector3(X,Y,Z);
                    if (direction.y <= 0)
                    {
                        direction.y = 0;
                    }

                    //print(direction);
                    //line.SetPosition(1, secondPos);
                }
            }
            if (newTouch.phase == TouchPhase.Ended)
            {
                firstTouch = false;
            }
        }
    }
    private void createLine()
    {
        //create a new empty gameobject and line renderer component
        line = new GameObject("Line").AddComponent<LineRenderer>();
        //assign the material to the line
        line.material = material;
        //set the number of points to the line
        line.SetVertexCount(2);
        //set the width
        line.SetWidth(0.15f, 0.15f);
        //render line to the world origin and not to the object's position
        line.useWorldSpace = true;

    }
}
