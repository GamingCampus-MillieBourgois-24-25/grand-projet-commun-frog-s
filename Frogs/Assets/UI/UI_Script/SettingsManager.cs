using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static bool isVibrate;

    public TMP_Dropdown graphicsDropdown;
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;
    public Toggle vibrateToggle;

    private const float clampThreshold = -80f;
    private const float muteDb = -1000f;

    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    public void ChangeMasterVolume()
    {
        ApplyVolume("MasterVol", masterVol.value);
    }

    public void ChangeMusicVolume()
    {
        ApplyVolume("MusicVol", musicVol.value);
    }

    public void ChangeSfxVolume()
    {
        ApplyVolume("SfxVol", sfxVol.value);
    }

    private void ApplyVolume(string parameter, float sliderValue)
    {
        // Si le slider descend à –80 dB ou moins, on mute à –1000 dB
        float db = sliderValue <= clampThreshold ? muteDb : sliderValue;
        mainAudioMixer.SetFloat(parameter, db);
    }

    public void ChangeVibrate()
    {
        isVibrate = vibrateToggle.isOn;
    }

    void Start()
    {
        isVibrate = true;

        // Initialiser sliders sur les valeurs actuelles du mixer (optionnel)
        if (mainAudioMixer.GetFloat("MasterVol", out float mv)) masterVol.value = mv;
        if (mainAudioMixer.GetFloat("MusicVol", out float musv)) musicVol.value = musv;
        if (mainAudioMixer.GetFloat("SfxVol", out float sfxv)) sfxVol.value = sfxv;
    }
}
