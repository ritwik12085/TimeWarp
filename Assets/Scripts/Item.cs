using UnityEngine;
using System.Collections;

public enum ItemType {VINE, STONE, FIRE, WOOD, WATER, BOTTLE, SWORD, HAMMER, HELMET, BOOT, ARMOR, SHIPPART1}
public enum Quality {COMMON, QUESTITEM, FORSHIP}

public class Item : MonoBehaviour {

	public ItemType type;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

	public int maxSize;

	public float hp, attack, defense, accuracy, atkSpeed, atkRange, critDamage, critChance;

	public string itemName;

	public Quality quality;

	public string description;

	private void Start(){
		maxSize = 99;
	}

	public void Use()
	{
		switch (type) {
		case ItemType.VINE:
			//Debug.Log ("I just used a vine.");
			break;
		case ItemType.STONE:
			//Debug.Log ("I just used a stone.");
			break;
		case ItemType.FIRE:
			//Debug.Log ("I just used fire.");
			break;
		case ItemType.WOOD:
			//Debug.Log ("I just used some wood.");
			break;
		case ItemType.WATER:
			//Debug.Log ("I just used water.");
			break;
		case ItemType.BOTTLE:
			//Debug.Log ("I just used a bottle.");
			break;
		case ItemType.SWORD:
			//Debug.Log ("I just used a sword.");
			break;
		}
	}

	public string GetTooltip(){
		string stats = string.Empty;
		string color = string.Empty;
		string newLine = string.Empty;

		if (description != string.Empty) {
			newLine = "\n";
		}

		switch (quality) {
			case Quality.COMMON:
				color = "white";
				break;
			case Quality.QUESTITEM:
				color = "magenta";
				break;
			case Quality.FORSHIP:
				color = "blue";
				break;
		}

		if (hp > 0) {
			stats += "\n+" + hp.ToString () + "HP";
		}
		if (attack > 0) {
			stats += "\n+" + attack.ToString () + "Attack";
		}
		if (defense > 0) {
			stats += "\n+" + defense.ToString () + "Defense";
		}
		if (accuracy > 0) {
			stats += "\n+" + accuracy.ToString () + "Accuracy";
		}
		if (atkSpeed > 0) {
			stats += "\n+" + atkSpeed.ToString () + "Attack Speed";
		}
		if (atkRange > 0) {
			stats += "\n+" + atkRange.ToString () + "Attack Range";
		}
		if (critDamage > 0) {
			stats += "\n+" + critDamage.ToString () + "Crit Damage";
		}
		if (critChance > 0) {
			stats += "\n+" + critChance.ToString () + "Crit Chance";
		}

		return string.Format ("<color=" + color + "><size=16>{0}</size></color><size=14><i><color=lime>" + newLine + "{1}</color></i>{2}</size>", itemName, description, stats);
	}
}
