using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	public float HP;
	public float Defense;
	public float Attack;
	public float Accuracy;
	public float AttackSpeed;
	public float critRangeLow;
	public float critRangeHigh;
	public float critChance;
	public float AttackRange;
	void Update () {
		if (HP <= 0) {
			print ("You are dead GG EZ");
		}
	}
}
