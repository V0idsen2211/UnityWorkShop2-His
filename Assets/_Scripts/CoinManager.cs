using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI winText;
    
    private int coinsCollected;
    private int totalCoins;
    private float timer;
    private void Start()
    {
        totalCoins = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        
    }

    private void Update()
    {
       
        if (coinsCollected == totalCoins)
        {
            winText.text = $"Time taken:{timer.ToString("0.00")}s";
            StartCoroutine(RestartScene());
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

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

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
