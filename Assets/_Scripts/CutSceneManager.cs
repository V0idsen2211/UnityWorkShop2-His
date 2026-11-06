using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
