using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
    public List <MusicNote> musicNotes;
    public float bpm;

    [SerializeField] private AudioClip[] noteSounds;

    public bool isPlaying;
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            currentTime += Time.deltaTime * bpm / 60;
        }
    }

    public void Play()
    {
        isPlaying =! isPlaying;
        if (isPlaying)
        {
            for (int i = 0; i < musicNotes.Count; i++)
            {
                musicNotes[i].PlayNote(noteSounds[musicNotes[i].chord], currentTime);
            }
        }
    }

    public void SetTime(float time)
    {
        currentTime = time;
    }
}
