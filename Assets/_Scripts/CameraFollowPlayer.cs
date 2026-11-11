using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollowPlayer : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 offset;
    public Transform target;
    public Vector2 cameraBoundsMin,  CameraBoundsMax;
    private InputSystem_Actions inputActions;

    private void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());  
        Vector3 targetPosition = Vector3.Lerp(target.position+ offset, mousePos, .3f) ;
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraBoundsMin.x, CameraBoundsMax.x),
           Mathf.Clamp(transform.position.y, cameraBoundsMin.y, CameraBoundsMax.y),
           transform.position.z);
    }

    public void ChangeCameraBounds(Vector2 min, Vector2 max)
    {
        cameraBoundsMin = min;
        CameraBoundsMax = max;
    }
}
