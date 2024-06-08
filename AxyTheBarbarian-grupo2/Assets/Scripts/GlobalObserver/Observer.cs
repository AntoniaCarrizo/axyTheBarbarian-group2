using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalListener : MonoBehaviour
{
    public static GlobalListener Instance { get; private set; }

    private bool isWinning = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerWinSequence()
    {
        if (!isWinning)
        {
            isWinning = true;
            ReloadLevel();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TriggerWallSound()
    {

    }
}