// Create a Global Listener object to act as the observer.
// Make the Global Listener a public static instance so it can be accessed from any game object.
// Call the Global Listener object on win or lose collision conditions to track winning state.


using UnityEngine;




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

    public void SetWinningState(bool isWin)
    {
        isWinning = isWin;
        Debug.Log("Observer vio que paso algo");
    }

    public bool IsWinning()
    {
        return isWinning;
    }
}