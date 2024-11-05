using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVPInputChords : MonoBehaviour
{
    public MVPControls controls;

    [SerializeField] private float horizontalInput;
    private float horizontalInputLastFrame;
    private int chord;

    public extOSC.Examples.SendNoteOnOver[] notes;

    public AudioClip[] audioClips;   
    public AudioSource[] audioSources;
    private int currentSource;

    private void Awake()
    {
        controls = new MVPControls();

        controls.Gameplay.ButtonA.performed += context => Button(0);
        controls.Gameplay.ButtonB.performed += context => Button(1);
        controls.Gameplay.ButtonX.performed += context => Button(2);
        controls.Gameplay.ButtonY.performed += context => Button(3);
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
            notes[chord].PlayNote();

            audioSources[currentSource].Play();
            currentSource += 1;
            if (currentSource >= 8)
            {
                currentSource = 0;
            }
        }
        horizontalInputLastFrame = horizontalInput;

        /*
        if (Input.GetMouseButtonDown(0))
        {
            notes[chord].PlayNote();

            audioSources[currentSource].Play();
            currentSource += 1;
            if (currentSource >= audioSources.Length)
            {
                currentSource = 0;
            }
        }
        */
    }

    void Button(int chordInput)
    {
        chord = chordInput;
        for (int i = 0; i < notes.Length; i++)
        {
            audioSources[i].clip = audioClips[chord];
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
