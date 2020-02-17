using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLights : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public BoxCollider2D areaTouched;

    public bool isTouched;

    NoteObject note;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        areaTouched = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isTouched)
        {
            sr.sprite = pressedImage;

        }
        else
        {
            sr.sprite = defaultImage;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Touch")
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Touch")
        {
            isTouched = false;
        }
    }






}
