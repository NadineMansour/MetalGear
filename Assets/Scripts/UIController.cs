using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Transform collectablesPanel;
    public GameObject prefabButton, pausemenu, gameovermenu;
	public GameObject player;
	public GameObject barrel;
    public GameObject door;
    public AudioSource audioSource, PauseAudioSource;
    public AudioClip gameoverMusic, menuAppear,selected, hover;

	private List<string> collected;
	private List<GameObject> buttons;
	private bool showCollectables;
    private bool activeBarrel, activeCollectablesMenu;
    private DoorController doorController;

	private int index = 0;
	private int max;

	private bool activeGun, activeRifle, activeKey;

	// Use this for initialization
	void Start () {
		max = 0;
		showCollectables = false;
		collected = new List<string>();
		buttons = new List<GameObject>();
		barrel.SetActive (false);
		collectItem ("Barrel");
        doorController = ((DoorController)door.GetComponent(typeof(DoorController)));
    }

    // Update is called once per frame
    void Update () {
		barrel.transform.position = player.transform.position;
        if (Input.GetKeyUp(KeyCode.M)) {
            activeCollectablesMenu = !activeCollectablesMenu;
        }
		if (Input.GetKeyUp("left") && activeCollectablesMenu && max > 1){
            // left
            audioSource.PlayOneShot(hover);
			index --;
			if(index == -1)
				index = max-1;
		}
		if (Input.GetKeyUp("right") && activeCollectablesMenu && max > 1){
            // right
            audioSource.PlayOneShot(hover);
            index ++;
			if(index == max)
				index = 0;
		}
		for (int i = 0; i<max; i++) {
			GameObject currentButton = buttons[i];
			if(i == index){
				currentButton.GetComponent<Image>().color = Color.red;
			} else{
				currentButton.GetComponent<Image>().color = Color.white;
			}
		}

		if (Input.GetKeyUp(KeyCode.Return)){
            audioSource.PlayOneShot(selected);
            if (collected[index].Equals("Gun")){
				((PlayerController)player.GetComponent(typeof(PlayerController))).pistolSelected();
			} else if(collected[index].Equals("Rifle")) {
				((PlayerController)player.GetComponent(typeof(PlayerController))).rifleSelected();
			} else if (collected[index].Equals("Barrel")){
				activeBarrel = !activeBarrel;
				player.gameObject.SetActive (!activeBarrel);
				barrel.gameObject.SetActive (activeBarrel);
			} else if (collected[index].Equals("Key"))
            {
                Debug.Log("enter");
                doorController.setCanOpen(true);
            }
        }

	}

	public void collectItem(string tag){
		collected.Add(tag);
		max = collected.Count;
		RectTransform panelRectTransform = collectablesPanel.GetComponent<RectTransform>();
		panelRectTransform.sizeDelta = new Vector2((max*100)+40, panelRectTransform.sizeDelta.y);
		GameObject button = (GameObject)Instantiate(prefabButton);
		button.transform.SetParent(panelRectTransform, false);
        button.transform.localScale = new Vector3(1, 1, 1);
		Vector3 pos = button.transform.localPosition;
 		pos.x = (((max-1)*50));
 		button.transform.localPosition = pos;
		button.GetComponent<Button>().GetComponentsInChildren<Text>()[0].text = tag;
		buttons.Add(button);
	}

	public void displayCollectables(){
		showCollectables = !showCollectables;
		collectablesPanel.gameObject.SetActive(showCollectables);
	}

    public void Pause()
    {

        if (!pausemenu.gameObject.activeInHierarchy)
        {
            audioSource.Pause();
            audioSource.PlayOneShot(menuAppear);
            PauseAudioSource.Play();
            pausemenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseAudioSource.Stop();
            audioSource.Play();
            pausemenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {

        if (!gameovermenu.gameObject.activeInHierarchy)
        {
            audioSource.Stop();
            //audioSource.PlayOneShot(menuAppear);
            audioSource.PlayOneShot(gameoverMusic);
            gameovermenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
