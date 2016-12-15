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
	public AudioClip buttonClicked;
	public AudioSource audioSource;

    void Update()
    {
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
		audioSource.PlayOneShot (buttonClicked);
    }

    public void howToPlay()
    {
        if (!howtoplay.gameObject.activeInHierarchy)
        {
            howtoplay.gameObject.SetActive(true);
            //buttons.gameObject.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
		audioSource.PlayOneShot (buttonClicked);
    }

    public void exit()
    {
		audioSource.PlayOneShot (buttonClicked);
        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void startGame()
    {
		audioSource.PlayOneShot (buttonClicked);
        Application.LoadLevel("Level3");
    }

    public void mute()
    {
		audioSource.PlayOneShot (buttonClicked);
        AudioListener.volume = 1 - AudioListener.volume;
		Debug.Log (muteText.text);
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
		audioSource.PlayOneShot (buttonClicked);
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

