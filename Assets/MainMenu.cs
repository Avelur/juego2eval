using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private GameObject controlsScreen;
    void Start()
    {
        controlsScreen = GameObject.Find("controls");
        controlsScreen.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame(){
        SceneManager.LoadScene("game");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void showControls(){
        controlsScreen.SetActive(true);
    }

    public void BackToMenu(){
        controlsScreen.SetActive(false);
    }
}
