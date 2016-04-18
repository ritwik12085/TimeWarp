using UnityEngine;
using System.Collections;
using System;
using UnityEditor;
using UnityEngine.UI;

public class enemyattack : MonoBehaviour {

	private enemy2visioncone vision;
	private GameObject player;
	private float damage;
	private float attackSpeed;
	private float nextAttack;
	private Vector3 textPos;
	private Color color;
	private Animator animator;
	void Start(){
		vision = this.GetComponent<enemy2visioncone> ();
		player = vision.player;
		nextAttack = 0.0f;
	}
	void Update () {
		animator = this.GetComponent<Animator>();
		if (vision.getCanAttack ()) {
			attackSpeed = this.GetComponent<Stats> ().getAttackSpeed ();
			damage = this.GetComponent<Stats> ().getAttack () - player.GetComponent<Stats> ().getDefense ();
			if (animator.GetInteger ("Dirc") == 1) {
				Debug.Log ("hellooooo");
				animator.SetInteger ("Dirc", -10);
			}
			if (player.GetComponent<Stats> ().getHP () > 0 && Time.time > nextAttack) {
				if (UnityEngine.Random.value <= this.GetComponent<Stats> ().getAccuracy ()) {
					if (UnityEngine.Random.value <= this.GetComponent<Stats> ().getCritChance ()) {
						damage = Crit (damage);
					}
					player.GetComponent<Stats> ().setHP (damage);
				}
				nextAttack = Time.time + 1 / attackSpeed;
			}
		}
	}
	float Crit(float damage){
		return damage * (1 + UnityEngine.Random.Range (this.GetComponent<Stats> ().getCritRangeLow(), this.GetComponent<Stats> ().getCritRangeHigh()));
	}
}
