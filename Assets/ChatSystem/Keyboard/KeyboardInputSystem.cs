
using AudioChat.Base;
using UnityEngine;

namespace AudioChat
{
    public class KeyboardInputSystem : MonoBehaviour, IInputDevice
    {
        protected IInputDeviceListener m_inputDeviceListener;
        public bool m_state;
        public int id;
        public byte[] currentData;

        public void init(IInputDeviceListener inpuDeviceListener)
        {
            m_inputDeviceListener = inpuDeviceListener;
        }

        public void onSetState(bool state)
        {
            m_state = state;
        }

        private void Update()
        {
            m_inputDeviceListener?.onInputUpdated(id, currentData);
        }
    }
}