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
    }

    public void Play(bool play)
    {
        isPlaying = play;
    }

    public void SetTime(float time)
    {
        currentTime = time;
        slider.value = currentTime / duration;
    }
}
