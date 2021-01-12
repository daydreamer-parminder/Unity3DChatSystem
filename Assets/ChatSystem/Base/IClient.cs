
namespace AudioChat.Base
{
    public interface IClient
    {
        int m_id { get; set; }
        IInputDevice m_inputDevice {get; set;}
        ITransmissionSystem m_transmissionSystem { get; set; }
        IOutputDevice m_outputDevice { get; set; }
    }
}