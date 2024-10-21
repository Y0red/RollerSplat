using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private GroundPiece[] allGroundPieces;

    [SerializeField]AudioSource audioSFX;
    GameObject winText;

    public int lastScene = 8;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SetupNewLevel();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
    }
    private void SetupNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
        winText = FindObjectOfType<WinHolder>().winHolder;
    }
    public void CheckComplete()
    {
        bool isFinished = true;

        for (int i = 0; i < allGroundPieces.Length; i++)
        {
            if (allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if (isFinished)
            NextLevel();
    }
    private void NextLevel()
    {
        StartCoroutine(StartNextLevel());
    }
    IEnumerator StartNextLevel()
    {
        winText.SetActive(true);
        audioSFX.Play();
        yield return new WaitForSeconds(2f);
        if(SceneManager.GetActiveScene().buildIndex >= lastScene)SceneManager.LoadScene(1);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
