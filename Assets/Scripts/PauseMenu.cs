using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public GameObject pausemenu;
    public Text muteText;

    public void mute()
    {
        AudioListener.volume = 1 - AudioListener.volume;
        if (muteText.text == "Mute")
        {
            muteText.text = "UnMute";
        }
        else
        {
            muteText.text = "Mute";
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() 
    {
        Time.timeScale = 1;
        Application.LoadLevel("StartScene");
    }

    public void Pause()
    {

        if (!pausemenu.gameObject.activeInHierarchy)
        {
            pausemenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausemenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
