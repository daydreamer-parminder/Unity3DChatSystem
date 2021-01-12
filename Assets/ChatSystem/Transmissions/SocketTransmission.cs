using AudioChat.Base;
using UnityEngine;

namespace AudioChat
{
    public class SocketTransmission : MonoBehaviour, ITransmissionSystem
    {
        protected ITransmissionListener m_transmissionListener;
        public bool m_state;

        public void init(ITransmissionListener transmissionListener)
        {
            m_transmissionListener = transmissionListener;
        }

        public void onSetTransmissionState(bool state)
        {
            m_state = state;
        }

        public void emit(byte[] data)
        {

        }
    }
}