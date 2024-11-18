using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Text songName;
    [SerializeField] private Text artistName;

    private int currentSong;
    bool isPlaying;

    public AudioClip[] songs;
    public string[] songNames;
    public string[] artistNames;

    void Start()
    {
        ChangeSong(0);
    }

    public void PlaySong()
    {
        if (!isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        isPlaying =! isPlaying;
    }

    public void ChangeSong(int change)
    {
        audioSource.Stop();

        if (change > 0 && currentSong >= songs.Length - 1)
        {
            currentSong = 0;
        }
        else if (change < 0 && currentSong <= 0)
        {
            currentSong = songs.Length - 1;
        }
        else
        {
            currentSong += change;
        }

        audioSource.clip = songs[currentSong];
        songName.text = songNames[currentSong];
        artistName.text = artistNames[currentSong];

        if (isPlaying)
        {
            audioSource.Play();
        }
    }
}
