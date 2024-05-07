using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace extOSC.Examples
{
    public class SendNoteOnOver : MonoBehaviour
    {
        #region Public Vars

        public string Address = "/hand0";
        public int pitch;
        public int velocity;

        [Header("OSC Settings")]
        public OSCTransmitter Transmitter;

        #endregion

        #region Unity Methods

        protected virtual void Start()
        {
            //Invoke("playNote1",1.0f);
        }

        void playNote1()
        {
            OSCMessage message = CreateLeapNote(80, 50);
            Transmitter.Send(message);
            Invoke("playNote2", 1.0f);
        }

        void playNote2()
        {
            OSCMessage message = CreateLeapNote(90, 30);
            Transmitter.Send(message);
            Invoke("playNote1", 1.0f);
        }

        private void OnMouseEnter()
        {
            SendMidiNote(pitch, velocity);

            // Get the Renderer component from the new cube
            var cubeRenderer = GetComponent<Renderer>();

            // Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.red);

        }

        private void OnMouseExit()
        {
            SendMidiNote(pitch, 0);

            // Get the Renderer component from the new cube
            var cubeRenderer = GetComponent<Renderer>();

            // Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.blue);
        }

        private OSCMessage CreateLeapNote(int pitch, int velocity)
        {
            var message = new OSCMessage(Address);
            message.AddValue(OSCValue.Int(0)); //not used
            message.AddValue(OSCValue.Int(0)); //not used
            message.AddValue(OSCValue.Int(0)); //not used
            message.AddValue(OSCValue.Int(velocity));
            message.AddValue(OSCValue.Int(pitch));

            return message;
        }

        private OSCMessage CreateMidiNote(int pitch, int velocity)
        {
            var message = new OSCMessage(Address);
            message.AddValue(OSCValue.Int(pitch));
            message.AddValue(OSCValue.Int(velocity));
            return message;
        }

        private void SendMidiNote(int pitch, int velocity)
        {
            OSCMessage message = CreateMidiNote(pitch, velocity);
            Transmitter.Send(message);
        }

        #endregion
    }
}