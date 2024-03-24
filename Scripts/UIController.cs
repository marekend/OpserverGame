using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Slider _musicSlider;

    public void AudioVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        AudioManager.Instance.SFXVolume(_musicSlider.value);
    }

}
