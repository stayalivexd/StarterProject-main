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
    float length;

    public List<MusicTrack> tracks;
    List<float> trackDurations;

    private Slider slider;

    [SerializeField] private InputField bpmInput;
    [SerializeField] private InputField lengthInput;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
        bpmInput.text = bpm.ToString();
        length = duration / (bpm / 60);
        lengthInput.text = length.ToString();
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
            MVPInputChords.instance.isRecording = false;
        }

        bpm = float.Parse(bpmInput.text);
        duration = float.Parse(lengthInput.text);

        if (currentTime >= duration || slider.value == 1)
        {
            isPlaying = false;
            currentTime = 0;
            slider.value = 0;
        }

        /*
        trackDurations.Clear();
        for (int i = 0; i < tracks.Count; i++)
        {
            trackDurations.Add(i);
            trackDurations[i] = tracks[i].duration;
        }
        duration = Mathf.Max(trackDurations.ToArray());
        */
    }

    public void Play(bool play)
    {
        isPlaying = play;
        
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
        slider.value = currentTime / duration;
    }
}
