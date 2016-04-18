using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipSlot : MonoBehaviour {

	public EquipmentItem theItem;

	public Equipment equipment;

	public Sprite slotNeutral;
	public Sprite slotHighlight;

	//private GameObject player;

	// Use this for initialization
	void Awake(){
		/**/
	}

	void Start () {
		//player = GameObject.FindWithTag ("Player");

		theItem.etype = EquipType.EMPTY;
		theItem.spriteNeutral = slotNeutral;
		theItem.spriteHighlighted = slotHighlight;
		theItem.itemName = "";
		theItem.description = "";
		theItem.hp = 0f;
		theItem.attack = 0f;
		theItem.defense = 0f;
		theItem.atkSpeed = 0f;
		theItem.atkRange = 0f;
		theItem.accuracy = 0f;
		theItem.critDamage = 0f;
		theItem.critChance = 0f;
		GetComponent<Image> ().sprite = theItem.spriteNeutral;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (theItem.etype == EquipType.EMPTY) {
			theItem.etype = EquipType.EMPTY;
			theItem.spriteNeutral = slotNeutral;
			theItem.spriteHighlighted = slotHighlight;
			theItem.itemName = "";
			theItem.description = "";
			theItem.hp = 0f;
			theItem.attack = 0f;
			theItem.defense = 0f;
			theItem.atkSpeed = 0f;
			theItem.atkRange = 0f;
			theItem.accuracy = 0f;
			theItem.critDamage = 0f;
			theItem.critChance = 0f;
			GetComponent<Image> ().sprite = theItem.spriteNeutral;
		}*/
	}

	public void EquipSword(){
		theItem.etype = EquipType.SWORD;
		theItem.spriteNeutral = equipment.swordNeutral;
		theItem.spriteHighlighted = equipment.swordHighlight;
		theItem.itemName = "Sword";
		theItem.description = "Use this to kick some butt!";
		theItem.attack = 10f;
		theItem.atkSpeed = 0.1f;
		theItem.atkRange = 1f;
		theItem.accuracy = 0.1f;
		theItem.critChance = 0.1f;
		GetComponent<Image> ().sprite = theItem.spriteNeutral;

		//updateStatWindow ();
		GameObject thePlayer = GameObject.FindWithTag ("Player");

		Debug.Log (thePlayer.GetComponent<Stats>().getHP());
		thePlayer.GetComponent<Stats>().updateTheStats(theItem);

	}

	public void EquipHammer(){
		theItem.etype = EquipType.HAMMER;
		theItem.spriteNeutral = equipment.hammerNeutral;
		theItem.spriteHighlighted = equipment.hammerHighlight;
		theItem.itemName = "Hammer";
		theItem.description = "Use this to kick some SERIOUS butt!";
		theItem.attack = 20f;
		theItem.atkSpeed = -0.2f;
		theItem.atkRange = 2f;
		theItem.accuracy = -0.2f;
		theItem.critDamage = 0.1f;
		GetComponent<Image> ().sprite = theItem.spriteNeutral;
	}

	public void EquipHelmet(){
		theItem.etype = EquipType.HELMET;
		theItem.spriteNeutral = equipment.helmetNeutral;
		theItem.spriteHighlighted = equipment.helmetHighlight;
		theItem.itemName = "Helmet";
		theItem.description = "Used to protect your cranium.";
		theItem.defense = 10f;
		theItem.hp = 10f;
		GetComponent<Image> ().sprite = theItem.spriteNeutral;
	}

	public void EquipArmor(){
		theItem.etype = EquipType.ARMOR;
		theItem.spriteNeutral = equipment.armorNeutral;
		theItem.spriteHighlighted = equipment.armorHighlight;
		theItem.itemName = "Armor";
		theItem.description = "Heavy defense boost!";
		theItem.defense = 15f;
		theItem.hp = 20f;
		GetComponent<Image> ().sprite = theItem.spriteNeutral;
	}

	public void EquipBoots(){
		theItem.etype = EquipType.BOOT;
		theItem.spriteNeutral = equipment.bootNeutral;
		theItem.spriteHighlighted = equipment.bootHighlight;
		theItem.itemName = "Pair of Boots";
		theItem.description = "Well you can't go barefoot, right?";
		theItem.defense = 5f;
		theItem.hp = 5f;
		GetComponent<Image> ().sprite = theItem.spriteNeutral;
	}

	/*private void updateStatWindow(){
		GameObject thePlayer = GameObject.FindWithTag ("Player");

		Debug.Log (thePlayer.GetComponent<Stats>().getHP());
		thePlayer.GetComponent<Stats>().updateTheStats(theItem);
	}*/
}
