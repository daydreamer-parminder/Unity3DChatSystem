using AudioChat;
using AudioChat.Base;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public enum DeviceInputSystem { 
        Mic,
        Keyboard,
        Camera
    }
    public enum TransmisionSystem { 
        Photon,
        FireBase,
        Socket
    }

    public DeviceInputSystem deviceInputSystem;
    public TransmisionSystem transmisionSystem;
    public ChatSystemHandler chatSystemHandler;

    private void Start()
    {
        IInputDevice ind = null;
        IOutputDevice iod = null;
        ITransmissionSystem ts = null;
        switch (deviceInputSystem)
        {
            case DeviceInputSystem.Mic:
                ind = FindObjectOfType<DeviceMicInputSystem>();
                iod = FindObjectOfType<DeviceSpeakerOutputSystem>();
                if (ind == null)
                    ind = new GameObject("DeviceMicInputSystem").AddComponent<DeviceMicInputSystem>();
                if (iod == null)
                    iod = new GameObject("DeviceSpeakerOutputSystem").AddComponent<DeviceSpeakerOutputSystem>();
                break;
            case DeviceInputSystem.Keyboard:
                ind = FindObjectOfType<KeyboardInputSystem>();
                iod = FindObjectOfType<TextChatOutputSystem>();
                if (ind == null)
                    ind = new GameObject("KeyboardInputSystem").AddComponent<KeyboardInputSystem>();
                if (iod == null)
                    iod = new GameObject("TextChatOutputSystem").AddComponent<TextChatOutputSystem>();
                break;
            case DeviceInputSystem.Camera:
                ind = FindObjectOfType<DeviceCameraInputSystem>();
                iod = FindObjectOfType<DeviceCameraOutputSystem>();
                if (ind == null)
                    ind = new GameObject("DeviceCameraInputSystem").AddComponent<DeviceCameraInputSystem>();
                if (iod == null)
                    iod = new GameObject("DeviceCameraOutputSystem").AddComponent<DeviceCameraOutputSystem>();
                break;
            default:
                break;
        }
        switch (transmisionSystem)
        {
            case TransmisionSystem.Photon:
                ts = FindObjectOfType<PhotonTransmission>();
                if (ts == null)
                    ts = new GameObject("PhotonTransmission").AddComponent<PhotonTransmission>();
                break;
            case TransmisionSystem.FireBase:
                ts = FindObjectOfType<FirebaseTransmission>();
                if (ts == null)
                    ts = new GameObject("FirebaseTransmission").AddComponent<FirebaseTransmission>();
                break;
            case TransmisionSystem.Socket:
                ts = FindObjectOfType<SocketTransmission>();
                if (ts == null)
                    ts = new GameObject("SocketTransmission").AddComponent<SocketTransmission>();
                break;
            default:
                break;
        }

        chatSystemHandler.onSetInputDevice(ind);
        chatSystemHandler.onSetOutputDevice(iod);
        chatSystemHandler.onSetTransmissionSystem(ts);
    }
}
