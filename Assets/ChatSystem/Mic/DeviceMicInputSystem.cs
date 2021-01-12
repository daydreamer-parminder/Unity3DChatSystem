
using AudioChat.Base;
using UnityEngine;

namespace AudioChat
{
    public class DeviceMicInputSystem : MonoBehaviour, IInputDevice
    {
        protected IInputDeviceListener m_inputDeviceListener;
        public bool m_state;
        public int m_id;
        public int m_frequency;
        public string m_deviceName;
        // An empty AudioClip that we'll write to when the player triggers it
        private AudioClip clipToTransmit;
        // Set as the last point in the AudioClip that we sent data for
        private int lastSampleOffset;

        public void init(IInputDeviceListener inpuDeviceListener)
        {
            m_inputDeviceListener = inpuDeviceListener;
        }

        public void onSetState(bool state)
        {
            m_state = state;
            if (state)
            {

            }
            else
            {
                // Stop recording from the default microphone
                Microphone.End(null);
                // Send the StopSendingAudio event
                //AudioTransmissionWriter.Send(new AudioTransmission.Update().AddStopSendingAudio(new StopSendingAudio()));
            }
        }


        private void Update()
        {
            if (m_state)
            {
                // Start recording from the default microphone
                clipToTransmit = Microphone.Start(m_deviceName, true, 10, m_frequency);
                // Reset the offset to 0, as we're starting the clip again
                lastSampleOffset = 0;
            }
        }

        private void FixedUpdate()
        {
            // Check where the microphone is at in the sample list
            int currentMicSamplePosition = Microphone.GetPosition(null);
            // Find out how many samples we need to send in this update
            int samplesToTransmit = CalculateSampleTransmissionCount(currentMicSamplePosition);
            if (samplesToTransmit > 0)
            {
                // Send the samples, and update the offset
                TransmitSamples(samplesToTransmit);
                lastSampleOffset = currentMicSamplePosition;
            }
        }
        private int CalculateSampleTransmissionCount(int currentMicrophoneSample)
        {
            // Work out how many samples to send in this transmission
            int sampleCountToTransmit = currentMicrophoneSample - lastSampleOffset;
            if (sampleCountToTransmit < 0) // lastSampleOffset overflew the microphone buffer.
            {
                sampleCountToTransmit = (clipToTransmit.samples - lastSampleOffset) + currentMicrophoneSample;
            }
            return sampleCountToTransmit;
        }
        private void TransmitSamples(int sampleCountToTransmit)
        {
            float[] samplesToTransmit = new float[sampleCountToTransmit * clipToTransmit.channels];
            clipToTransmit.GetData(samplesToTransmit, lastSampleOffset);
            m_inputDeviceListener?.onInputUpdated(m_id, currentData);
            //AudioTransmissionWriter.Send(new AudioTransmission.Update().AddSendAudio(new SendAudio(new List<float>(samplesToTransmit))));
        }
    }
}