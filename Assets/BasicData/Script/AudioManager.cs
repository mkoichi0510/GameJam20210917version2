using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public AudioSource seAudio;
    public AudioSource bgmAudio;
    
    void Start()
    {
        bgmAudio = GameObject.Find("BGMSource").GetComponent<AudioSource>();
        seAudio = GameObject.Find("SESource").GetComponent<AudioSource>();
    }

    public void SetSeVolume()
    {
        seAudio.volume = UIManager.GetSESliderVal();
    }

    public float GetSeVolume()
    {
        return seAudio.volume;
    }

    public void SetBgmVolume()
    {
        bgmAudio.volume = UIManager.GetBGMSliderVal();
    }

    public float GetBgmVolume()
    {
        return bgmAudio.volume;
    }

    public void PlayBGM()
    {
        bgmAudio.Play();
    }

    public void PlaySE()
    {
        seAudio.Play();
    }

    IEnumerator FadeOutBGM()
    {
        while (bgmAudio.volume > 0)
        {
            bgmAudio.volume -= 1f * Time.deltaTime;
            yield return null;
        }
    }

    public void StopBGM()
    {
        StartCoroutine(FadeOutBGM());
    }

    public void SetBGM(AudioClip clip)
    {
        bgmAudio.clip = clip;
    }

    public void SetSE(AudioClip clip)
    {
        seAudio.clip = clip;
    }
}
