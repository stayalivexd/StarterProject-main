using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicNote : MonoBehaviour
{
    public int chord;
    public float timing;

    public AudioSource audioSource;

    private RectTransform rectTransform;
    
    private MusicTrack track;
    private RectTransform trectTransform;

    private float uiTrackWidth;
    private float uiTrackHeight;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rectTransform = GetComponent<RectTransform>();
        track = GetComponentInParent<MusicTrack>();
        trectTransform = track.GetComponent<RectTransform>();
    }

    private void Update()
    {
        uiTrackWidth = trectTransform.sizeDelta.x - (rectTransform.sizeDelta.x * 2);
        uiTrackHeight = trectTransform.sizeDelta.y - (rectTransform.sizeDelta.y * 2);

        rectTransform.anchoredPosition = new Vector3((uiTrackWidth * -0.5f) + (uiTrackWidth * (timing / track.duration)),
            (uiTrackHeight * -0.5f) + (uiTrackHeight * chord / 3));
        
        audioSource.clip = track.noteSounds[chord];
    }

    public void PlayNote()
    {
        if (MusicPlayer.instance.isPlaying)
        {
            audioSource.Play();
        }
    }

    /*
    void Sound()
    {
        audioSource.Play();
    }
    */
}
