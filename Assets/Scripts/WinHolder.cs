using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHolder : MonoBehaviour
{
    public GameObject winHolder;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
