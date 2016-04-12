using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Crafting : MonoBehaviour {

	//Variables
	private static CanvasGroup craftPanelGroup;

	public static CanvasGroup CraftPanelGroup
	{
		get { return Crafting.craftPanelGroup; }
	}

	// Use this for initialization
	void Start () {
		craftPanelGroup = transform.parent.GetComponent<CanvasGroup>();
		craftPanelGroup.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggleTheCraft(){
		if (craftPanelGroup.alpha == 0) {
			craftPanelGroup.alpha = 1;
			craftPanelGroup.interactable = true;
		} else if(!GameObject.Find("Hover")){
			craftPanelGroup.alpha = 0;
			craftPanelGroup.interactable = false;
		}
	}

	public void SeeMaterialsNeeded(Canvas bottleMaterialsStatus){
		if (bottleMaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = bottleMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = bottleMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
		/*if (Cclicked.CraftItems.ctype != CraftType.EMPTY) {
			if(Cclicked.CraftItems.ctype == CraftType.BOTTLE){
				Debug.Log ("I need 5 vines and 1 wood.");
			}
		} else {
			Debug.Log ("No crafting item selected.");
		}
		Cclicked = null;*/
	}
		
}
