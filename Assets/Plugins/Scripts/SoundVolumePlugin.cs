public static partial class SoundVolumePlugin
{
    public static void SetVolume(float volume)
    {
        SoundVolumePlugin_setVolume(volume);
    }

    public static float GetVolume()
    {
        return SoundVolumePlugin_getVolume();
    }
}