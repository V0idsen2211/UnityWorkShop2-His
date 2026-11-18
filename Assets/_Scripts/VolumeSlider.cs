using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    private void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(AudioManager.Instance.ChangeMasterVolume);
    }

    private void OnDisable()
    {
        
    }
}
