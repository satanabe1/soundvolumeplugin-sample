#if UNITY_ANDROID
using UnityEngine;

partial class SoundVolumePlugin
{
    private const string PluginClassName = "jp.qualiarts.soundvolumeplugin.SoundVolumePlugin";

    private static void SoundVolumePlugin_setVolume(float volume)
    {
        using var plugin = new AndroidJavaClass(PluginClassName);
        plugin.CallStatic("setVolume", volume);
    }

    private static float SoundVolumePlugin_getVolume()
    {
        using var plugin = new AndroidJavaClass(PluginClassName);
        return plugin.CallStatic<float>("getVolume");
    }
}
#endif