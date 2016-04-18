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
	private bool helmetFire;
	private bool helmetStone;
	private bool helmetVines;
	private bool bootVines;
	private bool bootWood;
	private bool bootWater;
	private bool armorVines;
	private bool armorStone;
	private bool armorFire;
	private bool shipPart1Helmet;
	private bool shipPart1Hammer;
	private bool shipPart1Fire;

	public CraftSlot bottle;
	public CraftSlot sword;
	public CraftSlot hammer;
	public CraftSlot helmet;
	public CraftSlot boot;
	public CraftSlot armor;
	public CraftSlot shipPart1;

	// Use this for initialization
	void Start () {
		
	}
		
	
	// Update is called once per frame
	void Update () {
		
			
	}

	private void Craft(){
		foreach (GameObject slot in theBag.AllSlots) {
			Slot stmp = slot.GetComponent<Slot> ();

			if (!stmp.IsEmpty) {
				if (stmp.CurrentItem.type == ItemType.VINE /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						bottleVines = true;
					} else {
						bottleVines = false;
					}
					if (stmp.Items.Count >= 1) {
						helmetVines = true;
					} else {
						helmetVines = false;
					}
					if (stmp.Items.Count >= 1) {
						bootVines = true;
					} else {
						bootVines = false;
					}
					if (stmp.Items.Count >= 1) {
						armorVines = true;
					} else {
						armorVines = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.WOOD /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						bottleWood = true;
					} else {
						bottleWood = false;
					}
					if (stmp.Items.Count >= 1) {
						swordWood = true;
					} else {
						swordWood = false;
					}
					if (stmp.Items.Count >= 1) {
						hammerWood = true;
					} else {
						hammerWood = false;
					}
					if (stmp.Items.Count >= 1) {
						bootWood = true;
					} else {
						bootWood = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.STONE /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						swordStone = true;
					} else {
						swordStone = false;
					}
					if (stmp.Items.Count >= 1) {
						hammerStone = true;
					} else {
						hammerStone = false;
					}
					if (stmp.Items.Count >= 1) {
						helmetStone = true;
					} else {
						helmetStone = false;
					}
					if (stmp.Items.Count >= 1) {
						armorStone = true;
					} else {
						armorStone = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.FIRE /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						swordFire = true;
					} else {
						swordFire = false;
					}
					if (stmp.Items.Count >= 1) {
						hammerFire = true;
					} else {
						hammerFire = false;
					}
					if (stmp.Items.Count >= 1) {
						helmetFire = true;
					} else {
						helmetFire = false;
					}
					if (stmp.Items.Count >= 1) {
						armorFire = true;
					} else {
						armorFire = false;
					}
					if (stmp.Items.Count >= 1) {
						shipPart1Fire = true;
					} else {
						shipPart1Fire = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.WATER /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						bootWater = true;
					} else {
						bootWater = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.HELMET /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						shipPart1Helmet = true;
					} else {
						shipPart1Helmet = false;
					}
				} else if (stmp.CurrentItem.type == ItemType.HAMMER /*&& stmp.Items.Count > 0*/) {
					if (stmp.Items.Count >= 1) {
						shipPart1Hammer = true;
					} else {
						shipPart1Hammer = false;
					}
				}
			}
		}

		/*if(craftItems.ctype == CraftType.BOTTLE){
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
		if(craftItems.ctype == CraftType.HELMET){
			if (helmetVines == true && helmetFire == true && helmetStone==true) {
				GetComponent<Image> ().color = Color.white;
			} else {
				GetComponent<Image> ().color = Color.gray;
			}
		}
		if(craftItems.ctype == CraftType.BOOT){
			if (bootVines == true && bootWater == true && bootWood ==true) {
				GetComponent<Image> ().color = Color.white;
			} else {
				GetComponent<Image> ().color = Color.gray;
			}
		}
		if(craftItems.ctype == CraftType.ARMOR){
			if (armorVines == true && armorFire == true && armorStone ==true) {
				GetComponent<Image> ().color = Color.white;
			} else {
				GetComponent<Image> ().color = Color.gray;
			}
		}
		if(craftItems.ctype == CraftType.SHIPPART1){
			if (shipPart1Fire == true && shipPart1Hammer == true && shipPart1Helmet ==true) {
				GetComponent<Image> ().color = Color.white;
			} else {
				GetComponent<Image> ().color = Color.gray;
			}
		}*/

		Debug.Log (hammerStone);





		if (craftItems.ctype == CraftType.BOTTLE && bottleVines == true && bottleWood == true) {
			//take out used materials
			int vineToTake = 1;
			int woodToTake = 1;
			//if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.VINE && ttmp.Items.Count >= vineToTake) {
							ttmp.decreaseFromCraft(vineToTake);
							bottleVines = false;
							helmetVines = false;
							bootVines = false;
							armorVines = false;

						} else if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake) {
							ttmp.decreaseFromCraft(woodToTake);
							bottleWood = false;
							swordWood = false;
							hammerWood = false;
							bootWood = false;

						}
					}
					/*if (bottleVines == false || bottleWood == false) {
						GetComponent<Image> ().color = Color.gray;

					}*/
				}
			//}
			//appear in bag
			Item newBottle = gameObject.AddComponent<Item>();
			newBottle.type = ItemType.BOTTLE;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newBottle.spriteNeutral = theState.pressedSprite;
			newBottle.spriteHighlighted = theState.highlightedSprite;
			newBottle.maxSize = 99;
			newBottle.itemName = "Bottle";
			newBottle.description = "A bottle you can use to hold water.";
			newBottle.quality = Quality.QUESTITEM;
			theBag.AddItem(newBottle);


		}

		if (craftItems.ctype == CraftType.SWORD && swordWood == true && swordFire == true && swordStone == true) {
			//take out used materials
			int stoneToTake = 1;
			int woodToTake = 1;
			int fireToTake = 1;
			//if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.STONE && ttmp.Items.Count >= stoneToTake) {
							ttmp.decreaseFromCraft(stoneToTake);
							swordStone = false;
							hammerStone = false;
							helmetStone = false;
							armorStone = false;

						} else if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake) {
							ttmp.decreaseFromCraft(woodToTake);
							swordWood = false;
							bottleWood = false;
							hammerWood = false;
							bootWood = false;

						} else if (ttmp.CurrentItem.type == ItemType.FIRE && ttmp.Items.Count >= fireToTake) {
							ttmp.decreaseFromCraft(fireToTake);
							swordFire = false;
							helmetFire = false;
							hammerFire = false;
							armorFire = false;
							shipPart1Fire = false;

						}
					}
					/*if (swordStone == false || swordWood == false || swordFire == false) {
						GetComponent<Image> ().color = Color.gray;
					}*/
				}
			//}
			//appear in bag
			Item newSword = gameObject.AddComponent<Item>();
			newSword.type = ItemType.SWORD;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newSword.spriteNeutral = theState.pressedSprite;
			newSword.spriteHighlighted = theState.highlightedSprite;
			newSword.maxSize = 99;
			newSword.itemName = "Sword";
			newSword.description = "Use this to kick some butt!";
			newSword.attack = 10f;
			newSword.atkSpeed = 0.1f;
			newSword.atkRange = 1f;
			newSword.accuracy = 0.1f;
			newSword.critChance = 0.1f;
			newSword.quality = Quality.COMMON;
			theBag.AddItem(newSword);

			Debug.Log (hammerStone);

		}

		if (craftItems.ctype == CraftType.HAMMER && hammerWood == true && hammerFire == true && hammerStone == true) {
			//take out used materials
			int stoneToTake = 1;
			int woodToTake = 1;
			int fireToTake = 1;
			//if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.STONE && ttmp.Items.Count >= stoneToTake) {
							ttmp.decreaseFromCraft(stoneToTake);
							hammerStone = false;
							swordStone = false;
							//hammerStone = false;
							helmetStone = false;
							armorStone = false;

						} else if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake) {
							ttmp.decreaseFromCraft(woodToTake);
							hammerWood = false;
							swordWood = false;
							bottleWood = false;
							//hammerWood = false;
							bootWood = false;

						} else if (ttmp.CurrentItem.type == ItemType.FIRE && ttmp.Items.Count >= fireToTake) {
							ttmp.decreaseFromCraft(fireToTake);
							hammerFire = false;
							helmetFire = false;
							swordFire = false;
							//hammerFire = false;
							armorFire = false;
							shipPart1Fire = false;

						}
					}
					/*if (hammerStone == false || hammerWood == false || hammerFire == false) {
						GetComponent<Image> ().color = Color.gray;
					}*/
				}
			//}
			//appear in bag
			Item newHammer = gameObject.AddComponent<Item>();
			newHammer.type = ItemType.HAMMER;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newHammer.spriteNeutral = theState.pressedSprite;
			newHammer.spriteHighlighted = theState.highlightedSprite;
			newHammer.maxSize = 99;
			newHammer.itemName = "Hammer";
			newHammer.description = "Use this to kick some SERIOUS butt!";
			newHammer.attack = 20f;
			newHammer.atkSpeed = -0.2f;
			newHammer.atkRange = 2f;
			newHammer.accuracy = -0.2f;
			newHammer.critDamage = 0.1f;
			newHammer.quality = Quality.COMMON;
			theBag.AddItem(newHammer);
		}

		if (craftItems.ctype == CraftType.HELMET && helmetVines == true && helmetFire == true && helmetStone == true) {
			//take out used materials
			int stoneToTake = 1;
			int vineToTake = 1;
			int fireToTake = 1;
			//if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.STONE && ttmp.Items.Count >= stoneToTake) {
							ttmp.decreaseFromCraft(stoneToTake);
							helmetStone = false;
							swordStone = false;
							hammerStone = false;
							//helmetStone = false;
							armorStone = false;

						} else if (ttmp.CurrentItem.type == ItemType.VINE && ttmp.Items.Count >= vineToTake) {
							ttmp.decreaseFromCraft(vineToTake);
							helmetVines = false;
							bottleVines = false;
							bootVines = false;
							armorVines = false;

						} else if (ttmp.CurrentItem.type == ItemType.FIRE && ttmp.Items.Count >= fireToTake) {
							ttmp.decreaseFromCraft(fireToTake);
							helmetFire = false;
							hammerFire = false;
							swordFire = false;
							armorFire = false;
							shipPart1Fire = false;

						}
					}
					/*if (helmetStone == false || helmetVines == false || helmetFire == false) {
						GetComponent<Image> ().color = Color.gray;
					}*/
				}
			//}
			//appear in bag
			Item newHelmet = gameObject.AddComponent<Item>();
			newHelmet.type = ItemType.HELMET;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newHelmet.spriteNeutral = theState.pressedSprite;
			newHelmet.spriteHighlighted = theState.highlightedSprite;
			newHelmet.maxSize = 99;
			newHelmet.itemName = "Helmet";
			newHelmet.description = "Used to protect your cranium.";
			newHelmet.defense = 10f;
			newHelmet.hp = 10f;
			newHelmet.quality = Quality.COMMON;
			theBag.AddItem(newHelmet);
		}

		if (craftItems.ctype == CraftType.BOOT && bootVines == true && bootWater == true && bootWood == true) {
			//take out used materials
			int woodToTake = 1;
			int vineToTake = 1;
			int waterToTake = 1;
			//if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.WOOD && ttmp.Items.Count >= woodToTake) {
							ttmp.decreaseFromCraft(woodToTake);
							bootWood = false;
							hammerWood = false;
							swordWood = false;
							bottleWood = false;

						} else if (ttmp.CurrentItem.type == ItemType.VINE && ttmp.Items.Count >= vineToTake) {
							ttmp.decreaseFromCraft(vineToTake);
							helmetVines = false;
							bottleVines = false;
							bootVines = false;
							armorVines = false;

						} else if (ttmp.CurrentItem.type == ItemType.WATER && ttmp.Items.Count >= waterToTake) {
							ttmp.decreaseFromCraft(waterToTake);
							bootWater = false;

						}
					}
					/*if (bootWood == false || bootVines == false || bootWater == false) {
						GetComponent<Image> ().color = Color.gray;
					}*/
				}
			//}
			//appear in bag
			Item newBoot = gameObject.AddComponent<Item>();
			newBoot.type = ItemType.BOOT;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newBoot.spriteNeutral = theState.pressedSprite;
			newBoot.spriteHighlighted = theState.highlightedSprite;
			newBoot.maxSize = 99;
			newBoot.itemName = "Pair of Boots";
			newBoot.description = "Well you can't go barefoot, right?";
			newBoot.defense = 5f;
			newBoot.hp = 5f;
			newBoot.quality = Quality.COMMON;
			theBag.AddItem(newBoot);
		}

		if (craftItems.ctype == CraftType.ARMOR && armorVines == true && armorFire == true && armorStone == true) {
			//take out used materials
			int stoneToTake = 1;
			int vineToTake = 1;
			int fireToTake = 1;
			//if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.STONE && ttmp.Items.Count >= stoneToTake) {
							ttmp.decreaseFromCraft(stoneToTake);
							armorStone = false;
							helmetStone = false;
							swordStone = false;
							hammerStone = false;

						} else if (ttmp.CurrentItem.type == ItemType.VINE && ttmp.Items.Count >= vineToTake) {
							ttmp.decreaseFromCraft (vineToTake);
							helmetVines = false;
							bottleVines = false;
							bootVines = false;
							armorVines = false;

						} else if (ttmp.CurrentItem.type == ItemType.FIRE && ttmp.Items.Count >= fireToTake) {
							ttmp.decreaseFromCraft(fireToTake);
							armorFire = false;
							helmetFire = false;
							hammerFire = false;
							swordFire = false;
							shipPart1Fire = false;

						}
					}
					/*if (armorStone == false || armorVines == false || armorFire == false) {
						GetComponent<Image> ().color = Color.gray;
					}*/
				}
			//}
			//appear in bag
			Item newArmor = gameObject.AddComponent<Item>();
			newArmor.type = ItemType.ARMOR;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newArmor.spriteNeutral = theState.pressedSprite;
			newArmor.spriteHighlighted = theState.highlightedSprite;
			newArmor.maxSize = 99;
			newArmor.itemName = "Armor";
			newArmor.description = "Heavy defense boost!";
			newArmor.defense = 15f;
			newArmor.hp = 20f;
			newArmor.quality = Quality.COMMON;
			theBag.AddItem(newArmor);
		}

		if (craftItems.ctype == CraftType.SHIPPART1 && shipPart1Fire == true && shipPart1Hammer == true && shipPart1Helmet == true) {
			//take out used materials
			int helmetToTake = 1;
			int hammerToTake = 1;
			int fireToTake = 1;
			//if (GetComponent<Image> ().color == Color.white) {
				foreach (GameObject slot in theBag.AllSlots) {
					Slot ttmp = slot.GetComponent<Slot> ();
					if(!ttmp.IsEmpty){
						if (ttmp.CurrentItem.type == ItemType.HELMET && ttmp.Items.Count >= helmetToTake) {
							ttmp.decreaseFromCraft(helmetToTake);
							shipPart1Helmet = false;

						} else if (ttmp.CurrentItem.type == ItemType.HAMMER && ttmp.Items.Count >= hammerToTake) {
							ttmp.decreaseFromCraft(hammerToTake);
							shipPart1Hammer = false;

						} else if (ttmp.CurrentItem.type == ItemType.FIRE && ttmp.Items.Count >= fireToTake) {
							ttmp.decreaseFromCraft(fireToTake);
							shipPart1Fire = false;
							armorFire = false;
							helmetFire = false;
							hammerFire = false;
							swordFire = false;

						}
					}
					/*if (shipPart1Fire == false || shipPart1Hammer == false || shipPart1Helmet == false) {
						GetComponent<Image> ().color = Color.gray;
					}*/
				}
			//}
			//appear in bag
			Item newShipPart1 = gameObject.AddComponent<Item>();
			newShipPart1.type = ItemType.SHIPPART1;
			SpriteState theState = GetComponent<Button> ().spriteState;
			newShipPart1.spriteNeutral = theState.pressedSprite;
			newShipPart1.spriteHighlighted = theState.highlightedSprite;
			newShipPart1.maxSize = 99;
			newShipPart1.itemName = "Inconceivable Power Source";
			newShipPart1.description = "Don't know how you made it, but maybe you can go home now!";
			newShipPart1.quality = Quality.FORSHIP;
			theBag.AddItem(newShipPart1);
		}


	}

	public void OnPointerClick(PointerEventData eventData){
		if (eventData.button == PointerEventData.InputButton.Right && Crafting.CraftPanelGroup.alpha > 0) {
			Craft();
		}
	}
}
