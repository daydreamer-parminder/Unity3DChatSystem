
namespace AudioChat.Base
{
    public interface IInputDevice
    {
        void init(IInputDeviceListener inpuDeviceListener);
        void onSetState(bool state);
    }
    public interface IInputDeviceListener 
    {
        void onInputUpdated(int id, byte[] data);
    }
}