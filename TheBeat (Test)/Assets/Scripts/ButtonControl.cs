using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public GameObject circleTouch;
    public List<TouchLocation> touches = new List<TouchLocation>();

    //public BoxCollider2D buttons;
    //private ButtonLights lights;

    void Start()
    {
        //lights = buttons.GetComponent<ButtonLights>();

    }

    void Update()
    {
        buttonPress();
    }

     public void buttonPress()
    {
        if(Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);

                if (t.phase == TouchPhase.Began)
                {
                    //Debug.Log("Began");
                    Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 3.0f));
                    touches.Add(new TouchLocation(t.fingerId, pressSprite(t), pos));

                    //Debug.Log(pos);
                }

                else if(t.phase == TouchPhase.Ended)
                {
                    //Debug.Log("Ended");
                    TouchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchID == t.fingerId);
                    Destroy(thisTouch.circle);
                    touches.RemoveAt(touches.IndexOf(thisTouch));
                }

                else if (t.phase == TouchPhase.Moved)
                {
                    //Debug.Log("Moved");
                    TouchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchID == t.fingerId);
                    Destroy(thisTouch.circle);
                    touches.RemoveAt(touches.IndexOf(thisTouch));
                    thisTouch.circle.transform.position = getTouchPos(t.position);
                    touches.Add(new TouchLocation(t.fingerId, pressSprite(t), getTouchPos(t.position)));
                    //Debug.Log(getTouchPos(t.position));
                }
            }
        }
    }

    public Vector3 getTouchPos(Vector3 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 3.0f));
    }

    public GameObject pressSprite(Touch t)
    {
        GameObject c = Instantiate(circleTouch) as GameObject;
        c.name = "Touch" + t.fingerId;
        c.transform.position = getTouchPos(t.position);
        c.tag = "Touch";
        c.layer = 10;
        CircleCollider2D circleBox = c.gameObject.AddComponent<CircleCollider2D>();
        circleBox.radius = 0.3f;
        circleBox.isTrigger = true;
        return c;
    }





    //if(Input.touchCount != 0)
    //{
    //    for(int touchIndex = 0; touchIndex < Input.touches.Length; touchIndex ++)
    //    {
    //        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[touchIndex].position);

    //        if (Input.touches[touchIndex].phase == TouchPhase.Began && areaTouched.bounds.Contains(touchPosition))
    //        {
    //            sr.sprite = pressedImage;
    //            Debug.Log(Input.touches.Length);
    //        }

    //        if (Input.touches[touchIndex].phase == TouchPhase.Moved)
    //        {
    //            Vector2 newTouchPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.touches[touchIndex].position.x, Input.touches[touchIndex].position.y));
    //            BoxCollider2D newDraggedArea = new BoxCollider2D();
    //            newDraggedArea = GetComponent<BoxCollider2D>();
    //            if (Mathf.Abs(Input.touches[touchIndex].deltaPosition.x) > 2.5)
    //            {
    //                sr.sprite = defaultImage;
    //                if (newDraggedArea.bounds.Contains(newTouchPos))
    //                {
    //                    sr.sprite = pressedImage;
    //                }
    //            }
    //        }

    //        if (Input.touches[touchIndex].phase == TouchPhase.Ended)
    //        {
    //            sr.sprite = defaultImage;
    //        }


    //}
    //}

}
