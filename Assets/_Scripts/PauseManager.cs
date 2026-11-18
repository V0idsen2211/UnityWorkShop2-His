using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool paused;

    private InputSystem_Actions inputActions;

    public static PauseManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
        inputActions.Player.Pause.performed += PauseGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseGame(InputAction.CallbackContext ctx)
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("AudioUI", LoadSceneMode.Additive);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("AudioUI");

        }
    }
}
