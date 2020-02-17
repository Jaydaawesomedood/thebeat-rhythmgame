using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation
{
    public int touchID;
    public GameObject circle;
    public Vector2 touchPos;

    public TouchLocation(int newTouchID, GameObject touchArea, Vector2 touchPosition)
    {
        touchID = newTouchID;
        circle = touchArea;
        touchPos = touchPosition;
    }

}
