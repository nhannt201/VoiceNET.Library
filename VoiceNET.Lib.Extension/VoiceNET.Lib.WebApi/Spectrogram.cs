using System;

namespace Spectrogram
{
    [Obsolete("it has been renamed to SpectrogramGenerator")]
     class Spectrogram : SpectrogramGenerator
    {
        public Spectrogram(int sampleRate, int fftSize, int stepSize, double minFreq = 0, double maxFreq = double.PositiveInfinity, int? fixedWidth = null, int offsetHz = 0) :
            base(sampleRate, fftSize, stepSize, minFreq, maxFreq, fixedWidth, offsetHz)
        { }
    }
}
