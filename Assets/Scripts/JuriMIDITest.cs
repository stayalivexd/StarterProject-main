using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

public class JuriMIDITest : MonoBehaviour
{
    private OutputDevice outputDevice;
    // Start is called before the first frame update
    void Start()
    {
        outputDevice = OutputDevice.GetByName("LoopBe Internal MIDI");

        if (outputDevice != null)
        {
            Debug.Log("LoopBe1 MIDI device found.");
        }
        else
        {
            Debug.LogError("LoopBe1 MIDI device not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (outputDevice != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var noteOnMessage = new NoteOnEvent((Melanchall.DryWetMidi.Common.SevenBitNumber)60, (Melanchall.DryWetMidi.Common.SevenBitNumber)100);
                outputDevice.SendEvent(noteOnMessage);
                Debug.Log("Sending event Note On");
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                var noteOffMessage = new NoteOffEvent((Melanchall.DryWetMidi.Common.SevenBitNumber)60, (Melanchall.DryWetMidi.Common.SevenBitNumber)0);
                outputDevice.SendEvent(noteOffMessage);
                Debug.Log("Sending event Note Off");
            }
        }
    }

    void OnApplicationQuit()
    {
        if (outputDevice != null)
        {
            outputDevice.Dispose(); 
        }
    }


}
