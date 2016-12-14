using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour {

    public Text muteText;
    public GameObject howtoplay;
    public GameObject credits;
    public GameObject buttons;

    void Update()
    {
        Debug.Log("in update");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("in esc");
            if (credits.gameObject.activeInHierarchy)
            {
                credits.gameObject.SetActive(false);
            }
            if (howtoplay.gameObject.activeInHierarchy)
            {
                howtoplay.gameObject.SetActive(false);
            }
        }
    }

    public void showCredits()
    {
        if (!credits.gameObject.activeInHierarchy)
        {
            credits.gameObject.SetActive(true);
            //buttons.gameObject.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void howToPlay()
    {
        if (!howtoplay.gameObject.activeInHierarchy)
        {
            howtoplay.gameObject.SetActive(true);
            //buttons.gameObject.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void exit()
    {
        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void startGame()
    {
        Application.LoadLevel("Level3");
    }

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

    public void Back() {

        EventSystem.current.SetSelectedGameObject(null);
        if (howtoplay.gameObject.activeInHierarchy)
        {
            howtoplay.gameObject.SetActive(false);
        }
        if (credits.gameObject.activeInHierarchy)
        {
            credits.gameObject.SetActive(false);
        }
    }

}

