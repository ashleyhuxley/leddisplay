namespace LedDisplay.Graphics.Controller
{
    public interface ILedDisplayDriver
    {
        Task SendDataAsync(byte[] data);
    }
}
