using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject sound;
    public void PlaySound()
    {
        Instantiate(sound);
        
    }
}
