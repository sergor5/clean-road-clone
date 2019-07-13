using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlsV2 : MonoBehaviour
{
    Touch initTouch;
    public Vector2 direction;

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase == TouchPhase.Began)
            {
                initTouch = Input.touches[0];
            }else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                direction = new Vector2(-deltaX,-deltaY);

                direction.Normalize();
                print(direction);
            }else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
