using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftSlot : MonoBehaviour, IPointerClickHandler {

	//Variables
	public CraftItem craftItems;

	public CraftItem CraftItems
	{
		get { return craftItems; }
		set { craftItems = value; }
	}

	public Inventory theBag;

	private bool bottleVines;
	private bool bottleWood;

	//materials text for bottle
	public Text tVines;
	public Text tWood;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int vineInBag = 0;
		int woodInBag = 0;
		foreach (GameObject slot in theBag.AllSlots) {
			Slot stmp = slot.GetComponent<Slot> ();

			if(!stmp.IsEmpty){
				if (stmp.CurrentItem.type == ItemType.VINE && stmp.Items.Count > 0) {
					vineInBag = vineInBag + stmp.Items.Count;
					if (vineInBag >= 5) {
						bottleVines = true;
					} else {
						bottleVines = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.WOOD && stmp.Items.Count > 0) {
					woodInBag = woodInBag + stmp.Items.Count;
					if (woodInBag >= 1) {
						bottleWood = true;
					} else {
						bottleWood = false;
					}
				}
			}
		}
		if(craftItems.ctype == CraftType.BOTTLE){
			if (bottleWood == true) {
				tWood.color = Color.green;
			} else {
				tWood.color = Color.white;
			}
			if(bottleVines == true){
				tVines.color = Color.green;
			} else {
				tVines.color = Color.white;
			}

			if (bottleWood == true && bottleVines == true) {
				GetComponent<Image> ().color = Color.white;
			} else {
				GetComponent<Image> ().color = Color.gray;
			}
		}
	}

	private void Craft(){
		if (craftItems.ctype == CraftType.BOTTLE && bottleVines == true && bottleWood == true) {
			//take out used materials
			int vineToTake = 5;
			int woodToTake = 1;
			if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();

					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.VINE && ttmp.Items.Count >= vineToTake && vineToTake != 0) {
							ttmp.decreaseFromCraft(vineToTake);
							vineToTake = vineToTake - ttmp.Items.Count;
							bottleVines = false;
						} else if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake && woodToTake != 0) {
							ttmp.decreaseFromCraft(woodToTake);
							woodToTake = woodToTake - ttmp.Items.Count;
							bottleWood = false;
						}
					}
					if (bottleVines == false && bottleWood == false) {
						GetComponent<Image> ().color = Color.gray;
					}
				}
			}

			//appear in bag
			//Item newBottle = new Item();
			Item newBottle = gameObject.AddComponent<Item>();
			newBottle.type = ItemType.BOTTLE;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newBottle.spriteNeutral = theState.pressedSprite;
			newBottle.spriteHighlighted = theState.highlightedSprite;
			newBottle.maxSize = 99;
			theBag.AddItem(newBottle);
		}
	}

	public void OnPointerClick(PointerEventData eventData){
		if (eventData.button == PointerEventData.InputButton.Right && Crafting.CraftPanelGroup.alpha > 0) {
			Craft();
		}
	}
}
