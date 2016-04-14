using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private float attackSpeed;
	private float damage;
	private float nextAttack;
	private Color color;
	private Camera mainCamera;
	private GameObject enemy;
	private bool enemyClicked;
    private Healing heal;
	void Start () {
		nextAttack = 0;
		mainCamera = GetComponentInChildren<Camera> ();
        heal = this.GetComponent<Healing>();
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
				} 
			}
		}
		if (enemyClicked) {
			if (enemy.GetComponent<Stats> ().getHP () <= 0) {
				enemyClicked = false;
				return;
			}
            heal.setTime(Time.time);
			float distance = Vector3.Distance (enemy.transform.position, transform.position);
			if (Input.GetMouseButtonDown (0)) {
				float toTarget = Vector2.Distance (enemy.transform.position,mainCamera.ScreenToWorldPoint(Input.mousePosition));
				if(distance <= toTarget) {
                    //if (distance > this.GetComponent<Stats> ().getAttackRange()&& distance <= toTarget ) {
                    enemyClicked = false;
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
					}
					nextAttack = Time.time + 1 / attackSpeed;
				}
			} 
		}
	}
	float Crit(float damage){
		return damage * (1 + UnityEngine.Random.Range (this.GetComponent<Stats> ().getCritRangeLow(), this.GetComponent<Stats> ().getCritRangeHigh()));
	}
    public bool getEnemyClicked(){
        return enemyClicked;
    }
}
