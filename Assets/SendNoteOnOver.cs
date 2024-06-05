using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace extOSC.Examples
{
    public class SendNoteOnOver : MonoBehaviour
    {

        public bool OnMouseEnterActive = false;
        public GameObject bigCube;
        public int pitch;
        public int velocity;

        public string SendAddress = "/hand0";


        public string ReceiveNote = "/Note1";
        public string ReceiveVelocity = "/Velocity1";

        [Header("OSC Settings")]
        public OSCTransmitter Transmitter;
        public OSCReceiver Receiver;

        public int LastReceivedVelocity = 0;
        public Renderer IdleObject;
        public Renderer GuideObject;

        public VideoClip videoClip;
        public VideoPlayer videoPlayer;
        public Renderer targetRenderer;
        


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
            //changeColorTo(Color.red);
            //videoPlayer = bigCube.AddComponent<VideoPlayer>();

            videoPlayer.renderMode = VideoRenderMode.MaterialOverride;


            videoPlayer.Play();

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

        private void changeColorTo(Color toColor)
        {
            // Get the Renderer component from the new cube

            var cubeRenderer = GetComponent<Renderer>();
            var bigCubeRenderer = bigCube.GetComponent<Renderer>();
           


            // Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", toColor);
            bigCubeRenderer.material.SetColor("_Color", toColor);
        }

        private void ChangeIdleObjectColorTo(Color toColor)
        {
            IdleObject.material.SetColor("_Color", toColor);


        }

        private void ChangeGuideObjectColorTo(Color toColor)
        {
            GuideObject.material.SetColor("_Color", toColor);



        }
        private void ChangeMainCubeColor(Color toColor)

        {
            targetRenderer.material.SetColor("_Color", toColor);
        }

        private void StartGuideAnim()
        {
            //videoPlayer = gameObject.AddComponent<VideoPlayer>();
            //videoPlayer.playOnAwake = false; 
            //videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
           
        }

        //Receiving messages code
        //Velocity first, then note

        private void ReceivedNote(OSCMessage message)
        {
            //Debug.LogFormat("Received: {0}", message);

            int NoteValue;
            if (message.ToInt(out NoteValue))
            {
                if (NoteValue == pitch)
                {
                    if (LastReceivedVelocity > 0)
                    {
                        ChangeGuideObjectColorTo(Color.green);
                        videoPlayer = bigCube.GetComponent<VideoPlayer>();
                        videoPlayer.Play();


                        //bigCube.GetComponent<VideoPlayer>();
                        //bigCube.GetComponent<Renderer>().material.mainTexture.Play();
                        //movie.Play();
                        //changeColorTo(Color.green);
                        //ChangeIdleObjectColorTo(Color.gray);
                    }
                    else
                    {
                        videoPlayer.Stop();
                        //changeColorTo(Color.gray);
                        ChangeGuideObjectColorTo(Color.gray);
                       // ChangeMainCubeColor(Color.white);
                       //movie.Pause();
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