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

	public Canvas bottleMaterialsStatus;
	public Canvas swordMaterialsStatus;
	public Canvas hammerMaterialsStatus;

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

	public void SeeMaterialsNeeded(Canvas selectCanvas){
		if (selectCanvas.CompareTag("Bottle M Canvas") && bottleMaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = bottleMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = bottleMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
		if (selectCanvas.CompareTag("Sword M Canvas") && swordMaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = swordMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = swordMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
		if (selectCanvas.CompareTag("Hammer M Canvas") && hammerMaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = hammerMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = hammerMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
	}
		
}
