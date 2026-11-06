using System;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private int coinsCollected;

    private void OnEnable()
    {
        Coin.OnCoinCollected += CollectCoin;
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= CollectCoin;
    }

    private void CollectCoin()
    {
        coinsCollected++;
        coinText.text = $":{coinsCollected}";
    }
}
