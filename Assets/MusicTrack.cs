using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{
    public List <MusicNote> musicNotes;
    Transform[] notes;
    public float bpm;
    public float duration;

    [SerializeField] private AudioClip[] noteSounds;

    public bool isPlaying;
    public float currentTime;

    private void Start()
    {
        //UpdateNotes();
    }

    void Update()
    {
        UpdateNotes();

        duration = musicNotes[musicNotes.Count - 1].timing;

        if (isPlaying)
        {
            currentTime += Time.deltaTime * bpm / 60;
        }       
    }

    public void UpdateNotes()
    {
        notes = GetComponentsInChildren<Transform>();
        musicNotes.Clear();
        for (int i = 0; i < notes.Length; i++)
        {
            musicNotes.Add(notes[i].GetComponent<MusicNote>());
        }
        musicNotes.Remove(musicNotes[0]);
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
