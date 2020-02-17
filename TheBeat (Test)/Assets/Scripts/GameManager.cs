using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller BS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Time.time > 2)
            {
                BS.hasStarted = true;
                startPlaying = true;

                music.Play();
            }
        }
    }

    public void noteHit()
    {
        Debug.Log("Note Hit!");
        currentScore += scorePerNote;
        scoreText.text = currentScore.ToString();
    }

    public void noteMiss()
    {
        Debug.Log("Note Missed!");
    }
}
