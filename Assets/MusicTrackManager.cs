using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTrackManager : MonoBehaviour
{
    public static MusicTrackManager instance;

    public List<RectTransform> tracks;

    [SerializeField] private GameObject trackPrefab;
    [SerializeField] private RectTransform newTrackButton;

    [SerializeField] private Scrollbar scrollbar;
    RectTransform rectTransform;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void NewTrack()
    {
        RectTransform newTrack = Instantiate(trackPrefab, transform).GetComponent<RectTransform>();
        tracks.Add(newTrack);
    }

    public void RemoveTrack(int track)
    {
        Destroy(tracks[track].gameObject);
        tracks.Remove(tracks[track]);
    }

    void Update()
    {
        for (int i = 0; i < tracks.Count; i++)
        {
            tracks[i].anchoredPosition = new Vector3(0, -80 * i, 0);
        }
        newTrackButton.anchoredPosition = new Vector3(0, -80 * tracks.Count, 0);
        rectTransform.anchoredPosition = new Vector3(0, 100 + (80 * (tracks.Count - 1) * scrollbar.value), 0);
    }
}
