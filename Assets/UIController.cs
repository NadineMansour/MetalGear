using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public List<Button> buttons;

	private int index = 0;
	private int max;

	// Use this for initialization
	void Start () {
		max = buttons.Count;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp("left")){
			// left
			index --;
			if(index == -1)
				index = max-1;
			Debug.Log(index);
		}
		if (Input.GetKeyUp("right")){
			// right
			index ++;
			if(index == max)
				index = 0;
			Debug.Log(index);
		}
		for (int i = 0; i<max; i++) {
			Button currentButton = buttons[i];
			if(i == index){
				currentButton.GetComponent<Image>().color = Color.red;
			} else{
				currentButton.GetComponent<Image>().color = Color.white;
			}
		}
	}
}
