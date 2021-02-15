using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public class Audio
{
    public string audioName;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    [Header("Sound")]
    public AudioMixer masterMixer;
    public Slider sfxSlider;
    public Slider bgmSlider;
    public Audio[] sfxAudioes;
    public Audio[] bgmAudioes;
    public AudioSource sfxPlayer;
    public AudioSource bgmPlayer;

    float fades = 0f;
    float time = 0f;

    [Header("Button")]
    public Button newGameBtn;
    public Button optionBtn;
    public Button exitBtn;

    // SFX Controll
    public void SfxControll()
    {
        float sfxVol = sfxSlider.value * 4;
        if (sfxVol == -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sfxVol);
        ClickPlay();
    }
    // BGM Controll
    public void BgmControll()
    {
        float bgmVol = bgmSlider.value * 4;
        if (bgmVol == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", bgmVol);
    }

    // BGM
    public void BgmPlay()
    {
        bgmPlayer.clip = bgmAudioes[0].clip;
        bgmPlayer.Play();
    }

    public void BgmFadeOut()
    {
        float bgmVol = bgmSlider.value * 4;
        time += Time.deltaTime;
        if (fades >= 0f && time >= 0.05f)
        {
            fades += 1f;
            masterMixer.SetFloat("BGM", bgmVol - fades);
            time = 0;
        }
        else if (bgmVol - fades == -80f)
        {   
            masterMixer.SetFloat("BGM", -80f);
            time = 0;
        }
    }

    // Highlight
    public void HighlightPlay()
    {
        if (newGameBtn.interactable == true && optionBtn.interactable == true && exitBtn.interactable == true)
        {
            sfxPlayer.clip = sfxAudioes[0].clip;
            sfxPlayer.Play();
        }
    }

    // Click
    public void ClickPlay()
    {
        sfxPlayer.clip = sfxAudioes[1].clip;
        sfxPlayer.Play();
    }

    public void NextScenePlay()
    {
        sfxPlayer.clip = sfxAudioes[2].clip;
        sfxPlayer.Play();
    }
}
