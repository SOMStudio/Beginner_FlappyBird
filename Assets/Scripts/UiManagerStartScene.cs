using UnityEngine;
using UnityEngine.UI;

public class UiManagerStartScene : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        UpdateLevelButtons();
    }

    public void UpdateLevelButtons()
    {
        int completeLevel = GameManager.gameManager.completeLevel;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < completeLevel + 1)
                levelButtons[i].interactable = true;
            else
                levelButtons[i].interactable = false;
        }
    }
}
