using System;
using UnityEngine;

public class CameraBorderChanger : MonoBehaviour
{
    public Vector2 newMin, newMax, playerOffset;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position += new Vector3(playerOffset.x, playerOffset.y, 0f);
            Camera.main.GetComponent<CameraFollowPlayer>().ChangeBounds(newMin, newMax);
        }
    }
}
