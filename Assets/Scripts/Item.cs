using UnityEngine;
using System.Collections;

public enum ItemType {VINE, STONE, FIRE, WOOD, WATER, BOTTLE};

public class Item : MonoBehaviour {

	public ItemType type;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;

	public int maxSize;

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
		}
	}
}
