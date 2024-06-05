using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace extOSC.Examples
{
    public class SendNoteOnOver : MonoBehaviour
    {

        public bool OnMouseEnterActive = false;

        public int pitch;
        public int velocity;

        public string SendAddress = "/hand0";
       

        public string ReceiveNote = "/Note1";
        public string ReceiveVelocity = "/Velocity1";
        public GuideBall GuideBall;

        [Header("OSC Settings")]
        public OSCTransmitter Transmitter;
        public OSCReceiver Receiver;

        public int LastReceivedVelocity = 0;
        public Renderer IdleObject;
        public Renderer GuideObject;

        protected virtual void Start()
        {
            Receiver.Bind(ReceiveNote, ReceivedNote);
            Receiver.Bind(ReceiveVelocity, ReceivedVelocity);
        }

        public void PlayNote()
        {
            SendMidiNote(pitch, velocity);
        }

        public void StopNote()
        {
            SendMidiNote(pitch, 0);
        }


        /// <summary>
        /// Helper function to simulate eyetracking interactiuon in editor
        /// </summary>
        private void OnMouseEnter()
        {
            if (!OnMouseEnterActive) return;

            SendMidiNote(pitch, velocity);
            changeColorTo(Color.red);

        }

        /// <summary>
        /// Helper function to simulate eyetracking interactiuon in editor
        /// </summary>
        private void OnMouseExit()
        {
            if (!OnMouseEnterActive) return;

            SendMidiNote(pitch, 0);
            changeColorTo(Color.gray);

        }

        private OSCMessage CreateMidiNote(int pitch, int velocity)
        {
            var message = new OSCMessage(SendAddress);
            message.AddValue(OSCValue.Int(pitch));
            message.AddValue(OSCValue.Int(velocity));
            return message;
        }

        private void SendMidiNote(int pitch, int velocity)
        {
            OSCMessage message = CreateMidiNote(pitch, velocity);
            Transmitter.Send(message);
        }

        private void changeColorTo (Color toColor)
        {
            // Get the Renderer component from the new cube
            var cubeRenderer = GetComponent<Renderer>();

            // Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", toColor);
        }

        private void ChangeIdleObjectColorTo (Color toColor)
        {
            IdleObject.material.SetColor("_Color", toColor);
        }

        private void ChangeGuideObjectColorTo(Color toColor)
        {
            GuideObject.material.SetColor("_Color", toColor);
        }

        //Receiving messages code
        //Velocity first, then note

        private Dictionary<int, int> pitchToIndexMap = new Dictionary<int, int>()
{
    {72, 0}, // Map pitch 72 to index 0
    {76, 1}  // Map pitch 76 to index 1
};

        private void ReceivedNote(OSCMessage message)
        {
            //Debug.LogFormat("Received: {0}", message);

            int NoteValue;
            if (message.ToInt(out NoteValue))
            {
                if (pitchToIndexMap.ContainsKey(NoteValue))
                {
                    int index = pitchToIndexMap[NoteValue];
                    if (LastReceivedVelocity > 0)
                    {
                        ChangeGuideObjectColorTo(Color.green);
                        //changeColorTo(Color.green);
                        //ChangeIdleObjectColorTo(Color.gray);
                        // Move the guiding ball to the position corresponding to the note
                        GuideBall.MoveToPosition(index); // Modified code
                        Debug.Log("Received note value: " + NoteValue); // Lauri Code
                    }
                    else
                    {
                        //changeColorTo(Color.gray);
                        ChangeGuideObjectColorTo(Color.gray);
                        //ChangeIdleObjectColorTo(Color.yellow);
                    }
                }
            }
        }

        private void ReceivedVelocity(OSCMessage message)
        {
            //Debug.LogFormat("Received: {0}", message);

            int VelocityValue;
            if (message.ToInt(out VelocityValue))
            {
                LastReceivedVelocity = VelocityValue;
            }
        }
    }
}