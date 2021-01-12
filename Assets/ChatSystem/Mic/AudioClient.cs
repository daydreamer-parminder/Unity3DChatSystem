using AudioChat.Base;
using UnityEngine;

namespace AudioChat
{
    public class AudioClient : MonoBehaviour, IClient, IInputDeviceListener, ITransmissionListener
    {
        public int m_id { get ; set; }
        public IInputDevice m_inputDevice { get; set; }
        public ITransmissionSystem m_transmissionSystem { get; set; }
        public IOutputDevice m_outputDevice { get; set; }

        public void onInputUpdated(int id, byte[] data)
        {
           
        }

        public void onTransmissionRecieved(IClient client, byte[] data)
        {
     
        }
    }

}
