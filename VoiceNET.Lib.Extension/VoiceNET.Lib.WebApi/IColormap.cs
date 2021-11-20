
namespace Spectrogram
{
    interface IColormap
    {
        (byte r, byte g, byte b) GetRGB(byte value);
    }
}
