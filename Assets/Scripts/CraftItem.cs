using UnityEngine;
using System.Collections;

public enum CraftType {BOTTLE, SWORD, HAMMER, EMPTY};

public class CraftItem : MonoBehaviour {

	public CraftType ctype;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

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
}
