using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Transform collectablesPanel;
    public GameObject prefabButton, pausemenu, gameovermenu;
	public GameObject player;

	private List<string> collected;
	private List<GameObject> buttons;
	private bool showCollectables;

	private int index = 0;
	private int max;

	private bool activeGun, activeRifle, activeKey;

	// Use this for initialization
	void Start () {
		max = 0;
		showCollectables = false;
		collected = new List<string>();
		buttons = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("left")){
			// left
			index --;
			if(index == -1)
				index = max-1;
		}
		if (Input.GetKeyUp("right")){
			// right
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
			if(collected[index].Equals("Gun")){
				((PlayerController)player.GetComponent(typeof(PlayerController))).pistolSelected();
			} else if(collected[index].Equals("Rifle")) {
				((PlayerController)player.GetComponent(typeof(PlayerController))).rifleSelected();
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
            pausemenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausemenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {

        if (!gameovermenu.gameObject.activeInHierarchy)
        {
            gameovermenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
