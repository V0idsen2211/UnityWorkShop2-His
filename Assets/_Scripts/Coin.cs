using UnityEngine;
using System;
public class Coin : MonoBehaviour
{
    public static Action OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OnCoinCollected?.Invoke();
        }
        Destroy(gameObject);
    }
}
