using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public string paramete;

    [SerializeField]private AudioMixer audioMixer;
    [SerializeField] private float multiplier;

    public void SliderValue(float _value)
    {
        audioMixer.SetFloat(paramete, Mathf.Log10(_value)* multiplier);
    }

    public void LoadSlide(float _value)
    {
        if(_value >= 0.001f)
            slider.value = _value;
    }


}
