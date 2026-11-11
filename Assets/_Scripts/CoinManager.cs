using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI winText;
    public GameObject winSound;
    
    private int coinsCollected;
    private int totalCoins;
    private float timer;
    private Coroutine restartCoroutine;
    private void Start()
    {
        totalCoins = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        restartCoroutine = null;
    }

    private void Update()
    {
       
        if (coinsCollected == totalCoins && restartCoroutine == null && Vector2.Distance(transform.position, PlayerMovement.Instance.transform.position) < 5f)
        {
            winText.text = $"Time taken:{timer.ToString("0.00")}s";
            restartCoroutine = StartCoroutine(RestartScene());
        }
        
        if(coinsCollected != totalCoins)
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
        Instantiate(winSound, transform.position, transform.rotation);
        yield return new WaitForSeconds(5f);
        winText.text = $"Try for a better time";
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
