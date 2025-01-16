using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTrack : MonoBehaviour
{
    public List <MusicNote> musicNotes;
    Transform[] notes;
    //public float bpm;
    public float duration;
    public float volume;

    public AudioClip[] noteSounds;

    public float startTime;
    public GameObject notePrefab;

    [SerializeField] private Transform parent;

    [SerializeField] private Slider volumeSlider;

    //public bool isPlaying;
    //public float currentTime;

    private void Start()
    {
        //UpdateNotes();
    }

    void Update()
    {
        UpdateNotes();

        //duration = musicNotes[musicNotes.Count - 1].timing;
        duration = MusicPlayer.instance.duration;
        volume = volumeSlider.value;
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

    public void AddNote(int chord)
    {
        MusicNote newNote = Instantiate(notePrefab, transform).GetComponent<MusicNote>();
        newNote.chord = chord;
        newNote.timing = MusicPlayer.instance.currentTime;
    }

    public void Record()
    {
        if (!Metronome.instance.countdownMode && !MVPInputChords.instance.isRecording)
        {
            Metronome.instance.countdownMode = true;
            Metronome.instance.Play(true);
            Invoke("StartRecording", 240 / MusicPlayer.instance.bpm);
            Metronome.instance.Invoke("Beat", 60 / MusicPlayer.instance.bpm);
        }
        else if (MVPInputChords.instance.isRecording)
        {
            Metronome.instance.countdownMode = false;
            MusicPlayer.instance.Play(false);
            MVPInputChords.instance.isRecording = false;
        }
    }

    void StartRecording()
    {
        Metronome.instance.countdownMode = false;
        MusicPlayer.instance.Play(!MVPInputChords.instance.isRecording);
        if (!MVPInputChords.instance.isRecording)
        {
            MVPInputChords.instance.recordingTrack = this;
            MVPInputChords.instance.isRecording = true;
        }
        else
        {
            MVPInputChords.instance.isRecording = false;
        }
    }

    public void DeleteTrack()
    {
        MusicTrackManager.instance.RemoveTrack(parent.GetSiblingIndex() - 1);
    }

    /*
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
    */
}
