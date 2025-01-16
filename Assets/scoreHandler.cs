using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreHandler : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip note;
    
    bool isTriggered = false;
    public string listenToTag = "Note";

    public int chord;

    public AudioSource[] audioSources;
    private int currentSource;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
     
    }
    // Update is called once per frame
    void Update()
    {

        if (MVPInputChords.instance.isStrumming && MVPInputChords.instance.chord == chord && isTriggered)
        {
            ScoreTracker.instance.score++;
            isTriggered = false;
            audioSources[currentSource].Play();
            currentSource += 1;
            if (currentSource >= audioSources.Length)
            {
                currentSource = 0;
            }

        }

    }
    
}
