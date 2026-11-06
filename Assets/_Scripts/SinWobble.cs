using UnityEngine;

public class SinWobble : MonoBehaviour
{
    public float magnitude, frequency;
    private Vector2 originalPos;

    private int rand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = transform.position;
        rand = Random.Range(0, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originalPos + (Vector2.up * magnitude * Mathf.Sin(frequency * Time.time + rand));
    }
}
