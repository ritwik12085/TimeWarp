using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private float attackSpeed;
	private float damage;
	private float nextAttack;
	private GameObject hitText;
	private Color color;
	private Camera mainCamera;
	private GameObject enemy;
	private bool enemyClicked;
	void Start () {
		hitText = new GameObject ();
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
		nextAttack = 0;
		mainCamera = GetComponentInChildren<Camera> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				if (hit.transform.tag == "Enemy") {
					enemy = hit.collider.transform.parent.gameObject;
					enemyClicked = true;
					print ("I'm an enemy");
				}
			}
		}
		if (enemyClicked) {
			float distance = Vector3.Distance (enemy.transform.position, transform.position);
			damage = this.GetComponent<Stats> ().Attack - enemy.GetComponent<Stats> ().Defense;
			if (damage < 0) {
				damage = 0;
			}
			if (distance <= this.GetComponent<Stats> ().AttackRange) {
				attackSpeed = this.GetComponent<Stats> ().AttackSpeed;
				if (enemy.GetComponent<Stats> ().HP > 0 && Time.time > nextAttack) {
					if (UnityEngine.Random.value <= this.GetComponent<Stats> ().Accuracy) {
						if (UnityEngine.Random.value <= this.GetComponent<Stats> ().critChance) {
							damage = Crit (damage);
						}
						enemy.GetComponent<Stats> ().HP -= damage;
						print (enemy.GetComponent<Stats> ().HP);
						hitText.GetComponent<TextMesh> ().text = damage.ToString ();
						hitText.transform.position = enemy.transform.position + new Vector3(0,3,0);
						color.a = 100;
						hitText.GetComponent<TextMesh> ().color = color;
					} else {
						hitText.GetComponent<TextMesh> ().text = "Miss";
						hitText.transform.position = enemy.transform.position + new Vector3(0,3,0);
						color.a = 100;
						hitText.GetComponent<TextMesh> ().color = color;
					}
					nextAttack = Time.time + 1 / attackSpeed;
				}
			}
		}
	}
	float Crit(float damage){
		return damage * (1 + UnityEngine.Random.Range (this.GetComponent<Stats> ().critRangeLow, this.GetComponent<Stats> ().critRangeHigh));
	}
}
