using UnityEngine;
using System;
public class Coin : MonoBehaviour
{
    public static Action OnCoinCollected;
    public GameObject coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OnCoinCollected?.Invoke();
        }
        Instantiate(coinSound, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
