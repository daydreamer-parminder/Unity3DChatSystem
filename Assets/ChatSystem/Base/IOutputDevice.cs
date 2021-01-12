

namespace AudioChat.Base
{
    public interface IOutputDevice
    {
        void init();
        void onProcessData(byte[] data);
    }
}