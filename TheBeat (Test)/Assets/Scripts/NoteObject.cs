using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    ButtonControl BC;
    public ButtonLights buttonTouched;

    // Update is called once per frame
    void Update()
    {

         if (canBePressed)
         {
            if (buttonTouched.isTouched == true)
            {
                gameObject.SetActive(false);
                GameManager.instance.noteHit();
            }
         }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.noteMiss();
        }
    }

}
