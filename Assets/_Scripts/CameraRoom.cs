using UnityEngine;

public class CameraRoom : MonoBehaviour
{
    public Vector2 size;
    
    public LayerMask player;
    bool playerInRange;
    CameraFollowPlayer cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapBox(transform.position, size, 0, player);
        if (playerInRange && cam.enabled)
        {
            Vector2 min = new Vector2(transform.position.x + (-size.x / 2) + 27, transform.position.y + (-size.y / 2) + 15);
            Vector2 max = new Vector2(transform.position.x + (size.x / 2) - 27, transform.position.y + (size.y / 2) - 15);
            if (min.y > max.y)
            {
                float mid = transform.position.y;
                min.y = mid;
                max.y = mid;
            }
            cam.ChangeBounds(min, max);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

}
