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
	private bool swordStone;
	private bool swordWood;
	private bool swordFire;
	private bool hammerStone;
	private bool hammerWood;
	private bool hammerFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject slot in theBag.AllSlots) {
			Slot stmp = slot.GetComponent<Slot> ();

			if(!stmp.IsEmpty){
				if (stmp.CurrentItem.type == ItemType.VINE /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 5) {
						bottleVines = true;
					} else {
						bottleVines = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.WOOD /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						bottleWood = true;
					} else {
						bottleWood = false;
					}
					if (stmp.Items.Count >= 5) {
						swordWood = true;
					} else {
						swordWood = false;
					}
					if (stmp.Items.Count >= 15) {
						hammerWood = true;
					} else {
						hammerWood = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.STONE /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 10) {
						swordStone = true;
					} else {
						swordStone = false;
					}
					if (stmp.Items.Count >= 15) {
						hammerStone = true;
					} else {
						hammerStone = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.FIRE /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						swordFire = true;
					} else {
						swordFire = false;
					}
					if (stmp.Items.Count >= 2) {
						hammerFire = true;
					} else {
						hammerFire = false;
					}
				}
			}
		}

		if(craftItems.ctype == CraftType.BOTTLE){
			if (bottleWood == true && bottleVines == true) {
				GetComponent<Image> ().color = Color.white;
			} else {
				GetComponent<Image> ().color = Color.gray;
			}
		}
		if(craftItems.ctype == CraftType.SWORD){
			if (swordWood == true && swordFire == true && swordStone==true) {
				GetComponent<Image> ().color = Color.white;
			} else {
				GetComponent<Image> ().color = Color.gray;
			}
		}
		if(craftItems.ctype == CraftType.HAMMER){
			if (hammerWood == true && hammerFire == true && hammerStone==true) {
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
						if (ttmp.CurrentItem.type == ItemType.VINE && ttmp.Items.Count >= vineToTake) {
							ttmp.decreaseFromCraft(vineToTake);
							bottleVines = false;
						} else if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake) {
							ttmp.decreaseFromCraft(woodToTake);
							bottleWood = false;
						}
					}
					if (bottleVines == false || bottleWood == false) {
						GetComponent<Image> ().color = Color.gray;
					}
				}
			}
			//appear in bag
			Item newBottle = gameObject.AddComponent<Item>();
			newBottle.type = ItemType.BOTTLE;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newBottle.spriteNeutral = theState.pressedSprite;
			newBottle.spriteHighlighted = theState.highlightedSprite;
			newBottle.maxSize = 99;
			theBag.AddItem(newBottle);
		}

		if (craftItems.ctype == CraftType.SWORD && swordWood == true && swordFire == true && swordStone == true) {
			//take out used materials
			int stoneToTake = 10;
			int woodToTake = 5;
			int fireToTake = 1;
			if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.STONE && ttmp.Items.Count >= stoneToTake) {
							ttmp.decreaseFromCraft(stoneToTake);
							swordStone = false;
						} else if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake) {
							ttmp.decreaseFromCraft(woodToTake);
							swordWood = false;
						} else if (ttmp.CurrentItem.type == ItemType.FIRE && ttmp.Items.Count >= fireToTake) {
							ttmp.decreaseFromCraft(fireToTake);
							swordFire = false;
						}
					}
					if (swordStone == false || swordWood == false || swordFire == false) {
						GetComponent<Image> ().color = Color.gray;
					}
				}
			}
			//appear in bag
			Item newSword = gameObject.AddComponent<Item>();
			newSword.type = ItemType.SWORD;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newSword.spriteNeutral = theState.pressedSprite;
			newSword.spriteHighlighted = theState.highlightedSprite;
			newSword.maxSize = 99;
			theBag.AddItem(newSword);
		}

		if (craftItems.ctype == CraftType.HAMMER && hammerWood == true && hammerFire == true && hammerStone == true) {
			//take out used materials
			int stoneToTake = 15;
			int woodToTake = 15;
			int fireToTake = 2;
			if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.STONE && ttmp.Items.Count >= stoneToTake) {
							ttmp.decreaseFromCraft(stoneToTake);
							hammerStone = false;
						} else if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake) {
							ttmp.decreaseFromCraft(woodToTake);
							hammerWood = false;
						} else if (ttmp.CurrentItem.type == ItemType.FIRE && ttmp.Items.Count >= fireToTake) {
							ttmp.decreaseFromCraft(fireToTake);
							hammerFire = false;
						}
					}
					if (hammerStone == false || hammerWood == false || hammerFire == false) {
						GetComponent<Image> ().color = Color.gray;
					}
				}
			}
			//appear in bag
			Item newHammer = gameObject.AddComponent<Item>();
			newHammer.type = ItemType.HAMMER;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newHammer.spriteNeutral = theState.pressedSprite;
			newHammer.spriteHighlighted = theState.highlightedSprite;
			newHammer.maxSize = 99;
			theBag.AddItem(newHammer);
		}
	}

	public void OnPointerClick(PointerEventData eventData){
		if (eventData.button == PointerEventData.InputButton.Right && Crafting.CraftPanelGroup.alpha > 0) {
			Craft();
		}
	}
}
