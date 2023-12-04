package jp.qualiarts.soundvolumeplugin;

import android.content.Context;
import android.media.AudioManager;

import com.unity3d.player.UnityPlayer;

@SuppressWarnings("unused")
public class SoundVolumePlugin {
    public static float getVolume() {
        AudioManager audioManager = getAudioManager();
        return audioManager.getStreamVolume(AudioManager.STREAM_MUSIC)
                / (float) audioManager.getStreamMaxVolume(AudioManager.STREAM_MUSIC);
    }

    public static void setVolume(float volume) {
        AudioManager audioManager = getAudioManager();
        volume = Math.min(1.0f, Math.max(0.0f, volume));
        volume = volume * audioManager.getStreamMaxVolume(AudioManager.STREAM_MUSIC);
        audioManager.setStreamVolume(AudioManager.STREAM_MUSIC, Math.round(volume), 0);
    }

    private static AudioManager getAudioManager() {
        return (AudioManager) UnityPlayer.currentActivity.getSystemService(Context.AUDIO_SERVICE);
    }
}
