using UnityEngine;
using System.Collections;

public class enemy2AIMovement : MonoBehaviour {

	public GameObject player;
	public float speed;
	private enemy2visioncone vision;
	private Animator animator;
	private Attack attack;
	private Vector3 pos;
	private bool atTarget;
	private Vector3 target;
	private float nextPath;
	private Vector3 direction;
	void Start () {
		vision = this.GetComponent<enemy2visioncone> ();
		attack = this.GetComponent<Attack> ();
		atTarget = true;
		target = new Vector3 (0, 0, 0);
		nextPath = Time.time;
	}

	void Update () {
		float rand = Random.value;
		animator = this.GetComponent<Animator>();

		if (!this.gameObject.GetComponent<Rigidbody2D> ().IsAwake ()) {
			pos = this.transform.position;
		}
		if(vision.getCanSee ()){
			target = player.transform.position;
			nextPath = Time.time + 2;
		}
		else if(rand <= .25 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (0, 5, 0);
			atTarget = false;
			nextPath = Time.time + 2;
			direction = transform.up;
			animator.SetInteger ("Dirc", 1);
		}
		else if(rand <= .50 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (5, 0, 0);
			atTarget = false;
			nextPath = Time.time + 2;
			direction = transform.right;
			animator.SetInteger ("Dirc", 2);
		}
		else if(rand <= .75 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (0, -5, 0);
			atTarget = false;
			nextPath = Time.time + 2;
			direction = -transform.up;
			animator.SetInteger ("Dirc", -1);
		}
		else if(rand <= 1.0 && !this.gameObject.GetComponent<Rigidbody2D> ().IsAwake () && Time.time > nextPath) {
			target = pos + new Vector3 (-5, 0, 0);
			atTarget = false;
			nextPath = Time.time + 2;
			direction = -transform.right;
			animator.SetInteger ("Dirc", -2);
		}
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
	public Vector3 getDirection(){
		return direction;
	}

}
