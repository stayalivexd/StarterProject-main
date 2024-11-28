using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    public int chord;
    public float timing;

    public AudioSource audioSource;

    private MusicTrack track;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        track = GetComponentInParent<MusicTrack>();
    }

    public void PlayNote(AudioClip note, float time)
    {
        if (track.isPlaying)
        {
            audioSource.clip = note;
            Invoke("Sound", timing - time);
        }
    }

    void Sound()
    {
        audioSource.Play();
    }
}
