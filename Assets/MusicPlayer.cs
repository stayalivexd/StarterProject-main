using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    public bool isPlaying;
    public float currentTime;
    public float bpm;
    public float duration;

    public List<MusicTrack> tracks;
    List<float> trackDurations;

    private Slider slider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (isPlaying)
        {
            currentTime += Time.deltaTime * bpm / 60;
            slider.value = currentTime / duration;
        }
        else
        {
            currentTime = slider.value * duration;
        }

        trackDurations.Clear();
        for (int i = 0; i < tracks.Count; i++)
        {
            trackDurations.Add(i);
            trackDurations[i] = tracks[i].duration;
        }
        duration = Mathf.Max(trackDurations.ToArray());
    }

    public void Play()
    {
        isPlaying = !isPlaying;
        
        /*
        if (isPlaying)
        {
            for (int j = 0; j < tracks.Count; j++)
            {
                for (int i = 0; i < tracks[j].musicNotes.Count; i++)
                {
                    tracks[j].musicNotes[i].PlayNote(tracks[j].noteSounds[tracks[j].musicNotes[i].chord], currentTime + tracks[j].startTime);
                }
            }
        }
        */
    }

    public void SetTime(float time)
    {
        currentTime = time;
    }
}
