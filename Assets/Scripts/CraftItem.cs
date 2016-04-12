using UnityEngine;
using System.Collections;

public enum CraftType {BOTTLE, EMPTY};

public class CraftItem : MonoBehaviour {

	public CraftType ctype;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

	public void requiredMaterials(){
		switch (ctype) {
		case CraftType.BOTTLE:
			Debug.Log ("I need 5 vines and 1 wood.");
			break;
		case CraftType.EMPTY:
			Debug.Log ("No crafting item selected.");
			break;
		}
	}
}
