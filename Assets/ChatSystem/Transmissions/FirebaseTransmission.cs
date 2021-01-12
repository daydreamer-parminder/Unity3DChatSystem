using UnityEngine;
using AudioChat.Base;

namespace AudioChat
{
    public class FirebaseTransmission : MonoBehaviour, ITransmissionSystem
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