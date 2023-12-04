#if UNITY_IOS
using System.Runtime.InteropServices;

partial class SoundVolumePlugin
{
    private const string DllName = "__Internal";

    [DllImport(DllName)]
    private static extern void SoundVolumePlugin_setVolume(float volume);

    [DllImport(DllName)]
    private static extern float SoundVolumePlugin_getVolume();
}
#endif