#import <MediaPlayer/MediaPlayer.h>

extern "C" {
    float SoundVolumePlugin_getVolume();
    void SoundVolumePlugin_setVolume(const float volume);
}

float SoundVolumePlugin_getVolume() {
    return AVAudioSession.sharedInstance.outputVolume;
    // return [MPMusicPlayerController applicationMusicPlayer].volume; でも可
}

void SoundVolumePlugin_setVolume(const float volume) {
    // 一番単純な方法。しかし、非推奨API
    // [[MPMusicPlayerController applicationMusicPlayer] setVolume:clampedValue];
    // 割と単純でかつ、コンパイル時、非推奨警告が出なくなる方法。しかしprivateアクセス
    // [[MPMusicPlayerController systemMusicPlayer] setValue:@(clampedValue) forKey:@"volumePrivate"];
    // そこそこ正当だけど一番ごちゃつく
    MPVolumeView *volumeView = [[MPVolumeView alloc] init];
    for(UIView *view in [volumeView subviews])
    {
        if([NSStringFromClass(view.class) isEqualToString:@"MPVolumeSlider"] )
        {
            dispatch_after(dispatch_time(DISPATCH_TIME_NOW, (int64_t)(0.01 * NSEC_PER_SEC)), dispatch_get_main_queue(), ^{
                UISlider *volumeSlider = (UISlider *)view;
                volumeSlider.value = MIN(MAX(0, volume), 1);
            });
            return;
        }
    }
}
