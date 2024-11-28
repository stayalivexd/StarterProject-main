using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] private float bpm;
    private bool isPlaying;
    private bool isEnabled;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Enable()
    {
        isEnabled =! isEnabled;
    }

    public void Play()
    {
        isPlaying =! isPlaying;
        Beat();
    }

    void Beat()
    {
        if (isPlaying && isEnabled)
        {
            audioSource.Play();
            Invoke("Beat", 60 / bpm);
        }
    }
}
