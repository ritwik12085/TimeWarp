using UnityEngine;
using System.Collections;
using System;
using UnityEditor;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
	private VisionCone vision;
	private GameObject player;
	private float damage;
	private float attackSpeed;
	private float nextAttack;
	private GameObject hitText;
	private Vector3 textPos;
	private Color color;
	void Start(){
		hitText = new GameObject ();
		textPos = new Vector3(0f,2f,0f); 
		vision = this.GetComponent<VisionCone> ();
		player = vision.player;
		nextAttack = 0.0f;
		hitText.AddComponent<TextMesh> ();
		hitText.GetComponent<TextMesh> ().anchor = TextAnchor.MiddleCenter;
		hitText.GetComponent<TextMesh> ().fontSize = 100;
		hitText.GetComponent<TextMesh> ().fontStyle = FontStyle.Bold;
		hitText.transform.localScale = new Vector3(.05f,.05f,1f);
		hitText.GetComponent<TextMesh> ().color = Color.red;
		color = hitText.GetComponent<TextMesh> ().color;
		color.a = 0;
		hitText.GetComponent<TextMesh> ().color = color;
		hitText.SetActive (true);
	}
	void Update () {
		hitText.transform.position = player.transform.position + textPos;
		if (vision.getCanAttack ()) {
			attackSpeed = this.GetComponent<Stats> ().getAttackSpeed();
			damage = this.GetComponent<Stats> ().getAttack() - player.GetComponent<Stats> ().getDefense();
			if (player.GetComponent<Stats> ().getHP() > 0 && Time.time > nextAttack) {
				if (UnityEngine.Random.value <= this.GetComponent<Stats> ().getAccuracy()) {
					if (UnityEngine.Random.value <= this.GetComponent<Stats> ().getCritChance()) {
						damage = Crit (damage);
					}
					player.GetComponent<Stats> ().setHP (damage);
					hitText.GetComponent<TextMesh> ().text = damage.ToString ();
					hitText.transform.position = player.transform.position + textPos;
					color.a = 100;
					hitText.GetComponent<TextMesh> ().color = color;
				} else {
					hitText.GetComponent<TextMesh> ().text = "Miss";
					hitText.transform.position = player.transform.position + textPos;
					color.a = 100;
					hitText.GetComponent<TextMesh> ().color = color;
				}
				nextAttack = Time.time + 1 / attackSpeed;
			}
		} 
	}
	float Crit(float damage){
		return damage * (1 + UnityEngine.Random.Range (this.GetComponent<Stats> ().getCritRangeLow(), this.GetComponent<Stats> ().getCritRangeHigh()));
	}
}
