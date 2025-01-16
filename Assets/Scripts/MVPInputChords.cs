using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MVPInputChords : MonoBehaviour
{
    public static MVPInputChords instance;

    public MVPControls controls;
    public EventSystem eventSystem;

    bool playingInstrument;
    GameObject selectedGameObject;

    [SerializeField] private float horizontalInput;
    private float horizontalInputLastFrame;
    public int chord;

    public extOSC.Examples.SendNoteOnOver[] notes;

    public AudioClip[] audioClips;   
    public AudioSource[] audioSources;
    private int currentSource;

    public MusicTrack recordingTrack;
    public bool isRecording;

    public bool isStrumming;

    private void Awake()
    {
        instance = this;

        controls = new MVPControls();

        controls.Gameplay.ButtonA.performed += context => Button(0);
        controls.Gameplay.ButtonB.performed += context => Button(1);
        controls.Gameplay.ButtonX.performed += context => Button(2);
        controls.Gameplay.ButtonY.performed += context => Button(3);
        controls.Gameplay.ButtonStart.performed += context => PlayMode();
    }

    // Start is called before the first frame update
    void Start()
    {
        Button(0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = controls.Gameplay.Stick.ReadValue<float>();
        transform.position = new Vector3(horizontalInput, 1.5f, 0f);

        if (horizontalInput > 0.01f && horizontalInputLastFrame < 0.01f || horizontalInput < -0.01f && horizontalInputLastFrame > -0.01f)
        {
            Strum();
        }
        horizontalInputLastFrame = horizontalInput;
        
    }

    void Strum()
    {
        isStrumming = true;
        Invoke("NoStrum", 0.1f);
        if (isRecording)
        {
            recordingTrack.AddNote(chord);
        }

        notes[chord].PlayNote();

        audioSources[currentSource].Play();
        currentSource += 1;
        if (currentSource >= audioSources.Length)
        {
            currentSource = 0;
        }
    }

    void NoStrum()
    {
        isStrumming = false;
    }

    void Button(int chordInput)
    {
        chord = chordInput;
        for (int i = 0; i < notes.Length; i++)
        {
            audioSources[i].clip = audioClips[chord];
        }
    }

    void PlayMode()
    {
        playingInstrument =! playingInstrument;
        if (!playingInstrument)
        {
            selectedGameObject = eventSystem.currentSelectedGameObject;
            eventSystem.SetSelectedGameObject(null);
        }
        else
        {
            eventSystem.SetSelectedGameObject(selectedGameObject);
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
