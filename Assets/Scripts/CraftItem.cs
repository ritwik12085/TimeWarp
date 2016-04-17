using UnityEngine;
using System.Collections;

public enum CraftType {BOTTLE, SWORD, HAMMER, HELMET, BOOT, ARMOR, SHIPPART1, EMPTY};
public enum CQuality {COMMON, QUESTITEM, FORSHIP}

public class CraftItem : MonoBehaviour {

	public CraftType ctype;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

	public double hp, attack, defense, accuracy, atkSpeed, atkRange, critDamage, critChance;

	public string itemName;

	public CQuality quality;

	public string description;

	public void requiredMaterials(){
		switch (ctype) {
		case CraftType.BOTTLE:
			Debug.Log ("I need 5 vines and 1 wood.");
			break;
		case CraftType.SWORD:
			Debug.Log ("I need 10 stone, 5 wood, and 1 fire.");
			break;
		case CraftType.HAMMER:
			Debug.Log ("I need 15 stone, 15 wood, and 2 fire.");
			break;
		case CraftType.EMPTY:
			Debug.Log ("No crafting item selected.");
			break;
		}
	}

	public string cGetTooltip(){
		string stats = string.Empty;
		string color = string.Empty;
		string newLine = string.Empty;

		if (description != string.Empty) {
			newLine = "\n";
		}

		switch (quality) {
		case CQuality.COMMON:
			color = "white";
			break;
		case CQuality.QUESTITEM:
			color = "magenta";
			break;
		case CQuality.FORSHIP:
			color = "lime";
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
