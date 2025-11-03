// ------------------------------------------------------------
// @file       AudioExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-16 00:11:41
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.AudioKit.Example._0.Basic
{
    using PoolKit;
    using UnityEngine;
    using UnityEngine.UI;

    public class AudioExample : MonoBehaviour
    {
        private Slider _sldMusicVolume;
        private Slider _sldNarrationVolume;
        private Slider _sldSoundVolume;

        private Toggle _togMusicOn;
        private Toggle _togNarrationOn;
        private Toggle _togSoundOn;

        private void Awake()
        {
            // 使用 ResourcesAudioLoader 作为音频加载器
            AudioKit.AudioLoaderPool.SetObjectFactory(new CustomObjectFactory<IAudioLoader>(() => new ResourcesAudioLoader()));

            _sldMusicVolume     = GameObject.Find("Canvas/Music/Slider").GetComponent<Slider>();
            _sldNarrationVolume = GameObject.Find("Canvas/Narration/Slider").GetComponent<Slider>();
            _sldSoundVolume     = GameObject.Find("Canvas/Sound/Slider").GetComponent<Slider>();

            _togMusicOn     = GameObject.Find("Canvas/Music/Toggle").GetComponent<Toggle>();
            _togNarrationOn = GameObject.Find("Canvas/Narration/Toggle").GetComponent<Toggle>();
            _togSoundOn     = GameObject.Find("Canvas/Sound/Toggle").GetComponent<Toggle>();
        }

        private void Start()
        {
            _sldMusicVolume.value     = AudioKit.Setting.MusicVolume;
            _sldNarrationVolume.value = AudioKit.Setting.NarrationVolume;
            _sldSoundVolume.value     = AudioKit.Setting.SoundVolume;

            _togMusicOn.isOn     = AudioKit.Setting.IsMusicOn;
            _togNarrationOn.isOn = AudioKit.Setting.IsNarrationOn;
            _togSoundOn.isOn     = AudioKit.Setting.IsSoundOn;
        }

        public void PlayMusic()
        {
            Debug.Log("Playing Music...");
            AudioKit.PlayMusic(
                "Music/PillowTalk",
                onPlayFinish: repeatCount =>
                {
                    Debug.Log("Music play finished.");
                });
        }
        
        public void PlayNarration()
        {
            Debug.Log("Playing Narration...");
            AudioKit.PlayNarration(
                "Music/HomeBg",
                onPlayFinish: repeatCount =>
                {
                    Debug.Log("Narration play finished.");
                });
        }
        
        public void PlaySound()
        {
            Debug.Log("Playing Sound...");
            AudioKit.PlaySound(
                "Sound/ButtonClicked",
                onPlayFinish: player =>
                {
                    Debug.Log("Sound play finished: " + player.AudioClipName);
                });
        }
        
        public void StopAllSound()
        {
            Debug.Log("Stopping All Sound...");
            AudioKit.StopAllSound();
        }
        
        public void SetMusicVolume(float volume)
        {
            AudioKit.Setting.MusicVolume.Value = volume;
            Debug.Log("Music Volume set to: " + volume);
        }
        
        public void SetNarrationVolume(float volume)
        {
            AudioKit.Setting.NarrationVolume.Value = volume;
            Debug.Log("Narration Volume set to: " + volume);
        }
        
        public void SetSoundVolume(float volume)
        {
            AudioKit.Setting.SoundVolume.Value = volume;
            Debug.Log("Sound Volume set to: " + volume);
        }
        
        public void ToggleMusic(bool isOn)
        {
            AudioKit.Setting.IsMusicOn.Value = isOn;
            Debug.Log("Music toggled: " + isOn);
        }
        
        public void ToggleNarration(bool isOn)
        {
            AudioKit.Setting.IsNarrationOn.Value = isOn;
            Debug.Log("Narration toggled: " + isOn);
        }
        
        public void ToggleSound(bool isOn)
        {
            AudioKit.Setting.IsSoundOn.Value = isOn;
            Debug.Log("Sound toggled: " + isOn);
        }
    }
}