
namespace AudioChat.Base
{
    public interface ITransmissionSystem
    {
        void init(ITransmissionListener transmissionListener);
        void onSetTransmissionState(bool state);
        void emit(int id, byte[] data);
        void emit(IClient client, byte[] data);
    }
    public interface ITransmissionListener 
    {
        void onTransmissionRecieved(IClient client, byte[] data);
        void onTransmissionRecieved(int id, byte[] data);
    }
}