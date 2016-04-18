using UnityEngine;
using System.Collections;

public enum EquipType {SWORD, HAMMER, HELMET, BOOT, ARMOR, EMPTY};

public class EquipmentItem : MonoBehaviour {

	public EquipType etype;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

	public float hp, attack, defense, accuracy, atkSpeed, atkRange, critDamage, critChance;

	public string itemName;

	public Quality quality;

	public string description;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
