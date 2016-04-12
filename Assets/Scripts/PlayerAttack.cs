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
				Debug.Log (hit.transform.tag);
				if (hit.transform.tag == "Enemy") {
					enemy = hit.collider.transform.parent.gameObject;
					enemyClicked = true;
					print ("I'm an enemy");
				} 
			}
		}
		if (enemyClicked) {
			hitText.transform.position = enemy.transform.position + new Vector3 (0, 3, 0);
			if (enemy.GetComponent<Stats> ().getHP () <= 0) {
				hitText.SetActive (false);
			}
			if (enemy.GetComponent<Stats> ().getHP () <= 0) {
				enemyClicked = false;
				return;
			}
			float distance = Vector3.Distance (enemy.transform.position, transform.position);
			if (Input.GetMouseButtonDown (0)) {
				float toTarget = Vector2.Distance (enemy.transform.position,mainCamera.ScreenToWorldPoint(Input.mousePosition));
				if (distance > this.GetComponent<Stats> ().getAttackRange()&& distance <= toTarget ) {
					Debug.Log ("Distance: " + distance);
					Debug.Log ("To Target: " + toTarget);
					enemyClicked = false;
					Debug.Log ("Enemy out of range");
				}
			}
			damage = this.GetComponent<Stats> ().getAttack() - enemy.GetComponent<Stats> ().getDefense();
			if (damage < 0) {
				damage = 0;
			}
			if (distance <= this.GetComponent<Stats> ().getAttackRange()) {
				attackSpeed = this.GetComponent<Stats> ().getAttackSpeed();
				if (enemy.GetComponent<Stats> ().getHP() > 0 && Time.time > nextAttack) {
					if (UnityEngine.Random.value <= this.GetComponent<Stats> ().getAccuracy()) {
						if (UnityEngine.Random.value <= this.GetComponent<Stats> ().getCritChance()) {
							damage = Crit (damage);
						}
						enemy.GetComponent<Stats> ().setHP (damage);
						print (enemy.GetComponent<Stats> ().getHP());
						hitText.GetComponent<TextMesh> ().text = damage.ToString ();
						hitText.transform.position = enemy.transform.position + new Vector3 (0, 3, 0);
						color.a = 100;
						hitText.GetComponent<TextMesh> ().color = color;
					} else {
						hitText.GetComponent<TextMesh> ().text = "Miss";
						hitText.transform.position = enemy.transform.position + new Vector3 (0, 3, 0);
						color.a = 100;
						hitText.GetComponent<TextMesh> ().color = color;
					}
					nextAttack = Time.time + 1 / attackSpeed;
				}
			} 
		}
	}
	float Crit(float damage){
		return damage * (1 + UnityEngine.Random.Range (this.GetComponent<Stats> ().getCritRangeLow(), this.GetComponent<Stats> ().getCritRangeHigh()));
	}
}
