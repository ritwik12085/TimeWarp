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
	public Canvas helmetMaterialsStatus;
	public Canvas bootMaterialsStatus;
	public Canvas armorMaterialsStatus;
	public Canvas shipPart1MaterialsStatus;

	private static GameObject ctooltip;
	public GameObject ctooltipObject;
	private static Text csizeText;
	public Text csizeTextObject;
	private static Text cvisualText;
	public Text cvisualTextObject;

	// Use this for initialization
	void Start () {
		ctooltip = ctooltipObject;
		csizeText = csizeTextObject;
		cvisualText = cvisualTextObject;
		craftPanelGroup = transform.parent.GetComponent<CanvasGroup>();
		craftPanelGroup.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showToolTip(GameObject slot){
		CraftSlot tmpSlot = slot.GetComponent<CraftSlot> ();

		if(tmpSlot.CraftItems.ctype != CraftType.EMPTY){
			cvisualText.text = tmpSlot.CraftItems.cGetTooltip ();
			csizeText.text = cvisualText.text;

			Vector3 slotPos = slot.transform.position;
			slotPos.y = slotPos.y + 1;
			ctooltip.transform.position = slotPos;

			ctooltip.SetActive (true);
		}

	}

	public void hideToolTip(){
		ctooltip.SetActive (false);
	}

	public void toggleTheCraft(){
		if (craftPanelGroup.alpha == 0) {
			craftPanelGroup.alpha = 1;
			craftPanelGroup.interactable = true;
			craftPanelGroup.blocksRaycasts = true;
		} else if(!GameObject.Find("Hover")){
			craftPanelGroup.alpha = 0;
			craftPanelGroup.interactable = false;
			craftPanelGroup.blocksRaycasts = false;
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
		if (selectCanvas.CompareTag("Helmet M Canvas") && helmetMaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = helmetMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = helmetMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
		if (selectCanvas.CompareTag("Boots M Canvas") && bootMaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = bootMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = bootMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
		if (selectCanvas.CompareTag("Armor M Canvas") && armorMaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = armorMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = armorMaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
		if (selectCanvas.CompareTag("Ship Part 1 M Canvas") && shipPart1MaterialsStatus.GetComponent<CanvasGroup> ().alpha == 0) {
			CanvasGroup materialsPanelGroup = shipPart1MaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 1;
		} else {
			CanvasGroup materialsPanelGroup = shipPart1MaterialsStatus.GetComponent<CanvasGroup> ();
			materialsPanelGroup.alpha = 0;
		}
	}
		
}
