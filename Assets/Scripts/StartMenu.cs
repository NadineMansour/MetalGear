using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour {

    public Text muteText;
    public GameObject howtoplay;
    public GameObject credits;
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
        audioSource.PlayOneShot(buttonClicked);
        if (!credits.gameObject.activeInHierarchy)
        {
            credits.gameObject.SetActive(true);
            //buttons.gameObject.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void howToPlay()
    {
        audioSource.PlayOneShot(buttonClicked);
        if (!howtoplay.gameObject.activeInHierarchy)
        {
            howtoplay.gameObject.SetActive(true);
        }
        EventSystem.current.SetSelectedGameObject(null);
		
    }

    public void exit()
    {
		audioSource.PlayOneShot (buttonClicked);
        StartCoroutine(waiting(0.7f));

        #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void startGame()
    {
		audioSource.PlayOneShot(buttonClicked);
        StartCoroutine(waiting(0.7f));
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


    IEnumerator waiting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

}

