
namespace AudioChat.Base
{
    public interface ITransmissionSystem
    {
        void init(ITransmissionListener transmissionListener);
        void onSetTransmissionState(bool state);
        void emit(byte[] data);
    }
    public interface ITransmissionListener 
    {
        void onTransmissionRecieved(int id, byte[] data);
    }
}