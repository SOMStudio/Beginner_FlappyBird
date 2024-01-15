using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int score;
    public float delayLoadTime = 3f;

    public void AddScore(int addScore)
    {
        score = score + addScore;
    }

    public int GetScore()
    {
        return score;
    }
    
    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    private void LoadLevelList()
    {
        LoadLevel("LevelList");
    }
    
    public void LoadLevelListWithDelay()
    {
        Invoke(nameof(LoadLevelList), delayLoadTime);
    }
}
