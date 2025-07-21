// ------------------------------------------------------------
// @file       AudioExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-16 00:11:41
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.AudioKit.Example._0.Basic
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class AudioExample : MonoBehaviour
    {
        private Button _btnPlaySound;
        private Button _btnPlayMusic;
        private Button _btnPlayNarration;
        private Button _btnStopAllSound;

        private Slider _sldMusicVolume;
        private Slider _sldNarrationVolume;
        private Slider _sldSoundVolume;

        private Toggle _togMusicOn;
        private Toggle _togNarrationOn;
        private Toggle _togSoundOn;

        private void Awake()
        {
            // AudioKit.SoundMode = SoundMode.IgnoreSameSoundInSoundFrames;
            
            _btnPlaySound     = GameObject.Find("Canvas/BtnPlaySound").GetComponent<Button>();
            _btnPlayMusic     = GameObject.Find("Canvas/BtnPlayMusic").GetComponent<Button>();
            _btnPlayNarration = GameObject.Find("Canvas/BtnPlayNarration").GetComponent<Button>();
            _btnStopAllSound  = GameObject.Find("Canvas/BtnStopAllSound").GetComponent<Button>();

            _sldMusicVolume     = GameObject.Find("Canvas/Music/Slider").GetComponent<Slider>();
            _sldNarrationVolume = GameObject.Find("Canvas/Narration/Slider").GetComponent<Slider>();
            _sldSoundVolume     = GameObject.Find("Canvas/Sound/Slider").GetComponent<Slider>();

            _togMusicOn     = GameObject.Find("Canvas/Music/Toggle").GetComponent<Toggle>();
            _togNarrationOn = GameObject.Find("Canvas/Narration/Toggle").GetComponent<Toggle>();
            _togSoundOn     = GameObject.Find("Canvas/Sound/Toggle").GetComponent<Toggle>();

            _btnPlaySound.onClick.AddListener(() =>
            {
                AudioKit.PlaySound(
                    "ButtonClicked",
                    onPlayFinish: player =>
                    {
                        Debug.Log("Sound play finish: " + player.AudioClipName);
                    }
                );
            });
            _btnPlayMusic.onClick.AddListener(() =>
            {
                AudioKit.PlayMusic(
                    "PillowTalk",
                    onPlayFinish: repeatCount =>
                    {
                        Debug.Log("Music play finish");
                    });
            });
            _btnPlayNarration.onClick.AddListener(() =>
            {
                AudioKit.PlayNarration(
                    "HomeBg",
                    onPlayFinish: repeatCount =>
                    {
                        Debug.Log("Narration play finish");
                    });
            });
            _btnStopAllSound.onClick.AddListener(() =>
            {
                AudioKit.StopAllSound();
            });

            _sldMusicVolume.onValueChanged.AddListener((value) =>
            {
                AudioKit.Setting.MusicVolume.Value = value;
            });
            _sldNarrationVolume.onValueChanged.AddListener((value) =>
            {
                AudioKit.Setting.NarrationVolume.Value = value;
            });
            _sldSoundVolume.onValueChanged.AddListener((value) =>
            {
                AudioKit.Setting.SoundVolume.Value = value;
            });

            _togMusicOn.onValueChanged.AddListener((value) =>
            {
                AudioKit.Setting.IsMusicOn.Value = value;
            });
            _togNarrationOn.onValueChanged.AddListener((value) =>
            {
                AudioKit.Setting.IsNarrationOn.Value = value;
            });
            _togSoundOn.onValueChanged.AddListener((value) =>
            {
                AudioKit.Setting.IsSoundOn.Value = value;
            });
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
    }
}