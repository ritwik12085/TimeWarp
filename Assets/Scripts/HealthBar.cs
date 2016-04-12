using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	private float health;
	private GameObject HPText;

	void Start(){
		HPText = new GameObject ();
		HPText.AddComponent<TextMesh> ();
		HPText.GetComponent<TextMesh> ().anchor = TextAnchor.MiddleCenter;
		HPText.GetComponent<TextMesh> ().fontSize = 100;
		HPText.transform.localScale = new Vector3(.05f,.05f,1f);
		HPText.GetComponent<TextMesh> ().color = Color.green;
		HPText.GetComponent<TextMesh> ().fontStyle = FontStyle.Bold;
		HPText.AddComponent<Shadow> ();
		HPText.GetComponent<Shadow> ().effectColor = Color.black;
		HPText.GetComponent<Shadow> ().effectDistance = new Vector2 (2, 2);
	}
	void Update () {
		HPText.transform.position = gameObject.transform.position + new Vector3 (0, -2, 0);
		health = gameObject.GetComponent<Stats> ().HP;
		HPText.GetComponent<TextMesh> ().text = health.ToString ();
	}
}
