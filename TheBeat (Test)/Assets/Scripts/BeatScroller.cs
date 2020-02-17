using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float bpm;
    public bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        bpm = bpm / 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, bpm * Time.deltaTime, 0f);
        }
    }
}
