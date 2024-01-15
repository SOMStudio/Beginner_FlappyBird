using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int completeLevel = 0; 
        
    public static GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        if (completeLevel == 0 && PlayerPrefs.HasKey("CompleteLevel"))
        {
            completeLevel = PlayerPrefs.GetInt("CompleteLevel");
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void CompleteLevel()
    {
        completeLevel += 1;
        
        PlayerPrefs.SetInt("CompleteLevel", completeLevel);
    }

    public void ResetGame()
    {
        completeLevel = 0;   
        PlayerPrefs.SetInt("CompleteLevel", 0);
    }
}
