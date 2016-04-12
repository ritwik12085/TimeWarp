using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
	public float speed = 1.0f;
	private Vector3 target;
	private Animator animator;
	private int lastState;

	public Inventory inventory;

	void Start()
	{
		animator = this.GetComponent<Animator>();
		animator.SetInteger ("Direction", 4);
		//lastState = 4;
		target = transform.position;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) {
			if (EventSystem.current.IsPointerOverGameObject () == false && Inventory.HoverObject == null) {
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				target.z = transform.position.z;
			}
		}

		var vertical = target.y - transform.position.y;
		//var horizontal = Input.GetAxis ("Horizontal");

		if (vertical > 0) {
			animator.SetInteger ("Direction", 2);
		} else if (vertical < 0) {
			animator.SetInteger ("Direction", 0);
		}
		if (target == transform.position) {
			animator.SetInteger ("Direction", 4);
		}

		/*float upDown = target.y - transform.position.y;
		float leftRight = target.x - transform.position.x;

		if(upDown > 0 && Mathf.Abs(upDown) >= Mathf.Abs(leftRight))
		{
			animator.SetInteger("Direction", 2);
			//lastState = 2;
		}
		else if (upDown < 0 && Mathf.Abs(upDown) >= Mathf.Abs(leftRight))
		{
			animator.SetInteger("Direction", 0);
			//lastState = 0;
		}
		else if (leftRight > 0 && Mathf.Abs(upDown) < Mathf.Abs(leftRight))
		{
			animator.SetInteger("Direction", 1);
			//lastState = 1;
		}
		else if (leftRight < 0 && Mathf.Abs(upDown) < Mathf.Abs(leftRight))
		{
			animator.SetInteger("Direction", 3);
			//lastState = 3;
		}
		else if (target == transform.position)
		{
			animator.SetInteger ("Direction", 4);
			//lastState = 4;
		}*/

		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

	}

	private void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Tree") {
			target = transform.position;
			animator.SetInteger ("Direction", 4);
			//lastState = 4;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Item") {
			inventory.AddItem (other.GetComponent<Item> ());
		}
	}
}