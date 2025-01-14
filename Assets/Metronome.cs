using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public static Metronome instance;

    public bool countdownMode;
    private bool isEnabled;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Enable()
    {
        isEnabled =! isEnabled;
    }

    public void Play(bool play)
    {
        Beat();
    }

    void Beat()
    {
        if (MusicPlayer.instance.isPlaying && isEnabled || countdownMode)
        {
            audioSource.Play();
            Invoke("Beat", 60 / MusicPlayer.instance.bpm);
        }
    }
}
