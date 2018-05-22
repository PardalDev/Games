using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{

    private Button[] buttons;
    private GameObject panel;

    void Awake()
    {
        // Get the buttons
        buttons = FindObjectsOfType<Button>();

        // Disable them
        HideButtons();
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }
    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        // Reload the level
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        // Reload the level
        SceneManager.LoadScene("Level1");
    }
}