using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class Stats : MonoBehaviour {

	public float CurrHP;
	public float BaseDefense;
	public float BaseAttack;
	public float BaseAccuracy;
	public float BaseAttackSpeed;
	public float BaseCritRangeLow;
	public float BaseCritRangeHigh;
	public float BaseCritChance;
	public float BaseAttackRange;
	public Text statsText;
	private float MaxHP;
	private float HP;
	private float Defense;
	private float Attack;
	private float Accuracy;
	private float AttackSpeed;
	private float critRangeLow;
	private float critRangeHigh;
	private float critChance;
	private float AttackRange;
    public Equipment equip;
    void Start(){
		MaxHP = CurrHP;
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
        if(HP > MaxHP)
        {
            HP = MaxHP;
            UpdateStats(0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
	}
	public void UpdateStats(float HP, float Defense, float Attack, float Accuracy, float AttackSpeed, float critRangeLow, float critRangeHigh, float critChance, float AttackRange){
		this.HP = CurrHP + HP;
		this.Defense = Defense + BaseDefense;
		this.Attack = Attack + BaseAttack;
		this.Accuracy = Accuracy + BaseAccuracy;
		this.AttackSpeed = AttackSpeed + BaseAttackSpeed;
		this.critRangeLow = critRangeLow + BaseCritRangeLow;
		this.critRangeHigh = critRangeHigh + BaseCritRangeHigh;
		this.critChance = critChance + BaseCritChance;
		this.AttackRange = AttackRange + BaseAttackRange;
		this.MaxHP = MaxHP + HP; 
		if(this.CompareTag ("Player")){
			statsText.text = string.Format ("HP: {0}/{1}\nAttack: {2}\nDefense: {3}\nAccuracy: {4}\n" +
				"Attack Speed: {5}\nAttack Range {6}\nCrit Damage: {7}-{8}\nCrit Change: {9}", 
				this.HP, this.MaxHP, this.Attack, this.Defense, this.Accuracy, this.AttackSpeed, 
				this.AttackRange, this.critRangeLow, this.critRangeHigh, this.critChance);
		}
	}

	public float getHP(){
		return this.HP;
	}
	public void setHP(float damage){
		CurrHP -= damage;
		UpdateStats (0,0,0,0,0,0,0,0,0);
	}
    public void heal(float amount){
        CurrHP += amount;
        UpdateStats(0, 0, 0, 0, 0, 0, 0, 0, 0);
    }
    public void capHP(){
        CurrHP = MaxHP;
        HP = MaxHP;
        UpdateStats(0, 0, 0, 0, 0, 0, 0, 0, 0);
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
	public float getMaxHP(){
		return this.MaxHP;
	}
    public void equipUpdate()
    {
        float equipHP = equip.armorEquipSlot.theItem.hp + equip.weaponEquipSlot.theItem.hp + equip.headEquipSlot.theItem.hp + equip.feetEquipSlot.theItem.hp;
        float equipAttack = equip.armorEquipSlot.theItem.attack + equip.weaponEquipSlot.theItem.attack + equip.headEquipSlot.theItem.attack + equip.feetEquipSlot.theItem.attack;
        float equipDefense = equip.armorEquipSlot.theItem.defense + equip.weaponEquipSlot.theItem.defense + equip.headEquipSlot.theItem.defense + equip.feetEquipSlot.theItem.defense;
        float equipAccuracy = equip.armorEquipSlot.theItem.accuracy + equip.weaponEquipSlot.theItem.accuracy + equip.headEquipSlot.theItem.accuracy + equip.feetEquipSlot.theItem.accuracy;
        float equipAttackSpeed = equip.armorEquipSlot.theItem.atkSpeed + equip.weaponEquipSlot.theItem.atkSpeed + equip.headEquipSlot.theItem.atkSpeed + equip.feetEquipSlot.theItem.atkSpeed;
        float equipAttackRange = equip.armorEquipSlot.theItem.atkRange + equip.weaponEquipSlot.theItem.atkRange + equip.headEquipSlot.theItem.atkRange + equip.feetEquipSlot.theItem.atkRange;
        float equipDamage = equip.armorEquipSlot.theItem.critDamage + equip.weaponEquipSlot.theItem.critDamage + equip.headEquipSlot.theItem.critDamage + equip.feetEquipSlot.theItem.critDamage;
        float equipCritChance = equip.armorEquipSlot.theItem.critChance + equip.weaponEquipSlot.theItem.critChance + equip.headEquipSlot.theItem.critChance + equip.feetEquipSlot.theItem.critChance;

        UpdateStats(equipHP, equipDefense, equipAttack, equipAccuracy, equipAttackSpeed, equipDamage, equipDamage, equipCritChance, equipAttackRange);
    }
}
