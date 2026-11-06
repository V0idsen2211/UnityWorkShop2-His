using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioClip clip = sounds[Random.Range(0, sounds.Length)];
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        Destroy(gameObject, clip.length);
    }
}
    
