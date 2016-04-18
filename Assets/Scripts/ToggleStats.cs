using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleStats : MonoBehaviour {

	public CanvasGroup statCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleTheStats(){
		if (statCanvas.alpha == 0) {
			statCanvas.alpha = 1;
			//statCanvas.interactable = true;
			//statCanvas.blocksRaycasts = true;
		} else if(!GameObject.Find("Hover")){
			statCanvas.alpha = 0;
			//statCanvas.interactable = false;
			//statCanvas.blocksRaycasts = false;
		}
	}
}
