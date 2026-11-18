using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Range(0f, 1f)] public float masterVolume = 1f;
    public static AudioManager Instance {get; private set;}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMasterVolume(float t)
    {
        masterVolume = t;
    }
}
