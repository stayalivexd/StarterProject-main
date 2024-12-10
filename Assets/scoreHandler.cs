using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreHandler : MonoBehaviour
{
    public AudioClip note;
    public KeyCode key;
    bool isTriggered = false;
    public string listenToTag = "Note";

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

        if (Input.GetKeyDown(key) && isTriggered)
        {
            ScoreTracker.instance.score++;
            isTriggered = false;

        }

    }
    
}
