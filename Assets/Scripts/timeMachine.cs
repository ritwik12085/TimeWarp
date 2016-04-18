using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class timeMachine : MonoBehaviour {

	public Inventory inventory;
	public Text endLevelText;
	public Canvas endLevel1Canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		bool isLevelDone = inventory.endLevel1Check ();
		Debug.Log (isLevelDone);
		if (isLevelDone) {
			endLevel1Canvas.GetComponent<CanvasGroup> ().alpha = 1;
			endLevel1Canvas.GetComponent<CanvasGroup> ().interactable = true;
			endLevel1Canvas.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}
}
