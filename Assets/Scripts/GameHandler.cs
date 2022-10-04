using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public bool gameStart;
    public static GameHandler gameHandlerSington;
    [SerializeField] private GameObject panelStart;

    void Awake()
    {
        gameStart = false;
        gameHandlerSington = this;    
    }
    void Update()
    {
        switch (gameStart)
        {
            case true:
                panelStart.SetActive(false);
                break;
            case false:
                panelStart.SetActive(true);
                break;
        }
    }

    public void StartGame(bool isStarting)
    {
        switch (isStarting)
        {
            case true:
                gameStart = true;
                break;

            case false:
                gameStart = false;
                break;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
