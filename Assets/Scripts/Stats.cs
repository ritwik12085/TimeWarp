using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class Stats : MonoBehaviour {

	public float BaseHP;
	public float BaseDefense;
	public float BaseAttack;
	public float BaseAccuracy;
	public float BaseAttackSpeed;
	public float BaseCritRangeLow;
	public float BaseCritRangeHigh;
	public float BaseCritChance;
	public float BaseAttackRange;
	public Text statsText;
	private float HP;
	private float Defense;
	private float Attack;
	private float Accuracy;
	private float AttackSpeed;
	private float critRangeLow;
	private float critRangeHigh;
	private float critChance;
	private float AttackRange;
	void Start(){
		UpdateStats (0,0,0,0,0,0,0,0,0);
	}
	void Update () {
		if (HP <= 0) {
			if (this.CompareTag ("Enemy")) {
				this.gameObject.SetActive (false);
			} 
			else {
				Debug.Log ("Game Over");
			}
		}
	}
	public void UpdateStats(float HP, float Defense, float Attack, float Accuracy, float AttackSpeed, float critRangeLow, float critRangeHigh, float critChance, float AttackRange){
		this.HP = HP + BaseHP;
		this.Defense = Defense + BaseDefense;
		this.Attack = Attack + BaseAttack;
		this.Accuracy = Accuracy + BaseAccuracy;
		this.AttackSpeed = AttackSpeed + BaseAttackSpeed;
		this.critRangeLow = critRangeLow + BaseCritRangeLow;
		this.critRangeHigh = critRangeHigh + BaseCritRangeHigh;
		this.critChance = critChance + BaseCritChance;
		this.AttackRange = AttackRange + BaseAttackRange;

		if(this.CompareTag ("Player")){
			statsText.text = string.Format ("HP: {0}\nAttack: {1}\nDefense: {2}\nAccuracy: {3}\n" +
				"Attack Speed: {4}\nAttack Range {5}\nCrit Damage: {6}-{7}\nCrit Change: {8}", 
				this.HP, this.Attack, this.Defense, this.Accuracy, this.AttackSpeed, 
				this.AttackRange, this.critRangeLow, this.critRangeHigh, this.critChance);
		}
	}

	public float getHP(){
		return this.HP;
	}
	public void setHP(float damage){
		BaseHP -= damage;
		UpdateStats (0,0,0,0,0,0,0,0,0);
	}
	public float getAttack(){
		return this.Attack;
	}
	public float getDefense(){
		return this.Defense;
	}
	public float getAccuracy(){
		return this.Accuracy;
	}
	public float getAttackSpeed(){
		return this.AttackSpeed;
	}
	public float getAttackRange(){
		return this.AttackRange;
	}
	public float getCritRangeLow(){
		return this.critRangeLow;
	}
	public float getCritRangeHigh(){
		return this.critRangeHigh;
	}
	public float getCritChance(){
		return this.critChance;
	}
}
