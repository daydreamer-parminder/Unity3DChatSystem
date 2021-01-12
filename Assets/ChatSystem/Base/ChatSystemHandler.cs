using UnityEngine;

namespace AudioChat.Base
{

    public class ChatSystemHandler : MonoBehaviour, IInputDeviceListener, ITransmissionListener
    {
        protected IInputDevice m_inputDevice;
        protected ITransmissionSystem m_transmissionSystem;
        protected IOutputDevice m_outputDevice;
      
        public void onSetInputDevice(IInputDevice inputDevice) {
            m_inputDevice = inputDevice;
            m_inputDevice.init(this);
        }

        public void onSetTransmissionSystem(ITransmissionSystem transmissionSystem) {
            m_transmissionSystem = transmissionSystem;
            m_transmissionSystem.init(this);
        }

        public void onSetOutputDevice(IOutputDevice outputDevice) {
            m_outputDevice = outputDevice;
            m_outputDevice.init();
        }

        #region IInputDeviceListener
        public void onInputUpdated(int id, byte[] data)
        {
            m_transmissionSystem?.emit(id, data);
        }
        #endregion

        #region ITransmissionListener
        public void onTransmissionRecieved(IClient client, byte[] data)
        {
            m_outputDevice?.onProcessData(data);
        }
        public void onTransmissionRecieved(int id, byte[] data)
        {
            m_outputDevice?.onProcessData(data);
        }
        #endregion
    }
}