using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
	private Stats stats;
	private Vector3 offset;
	private float fillAmount;
	[SerializeField]
	private Image content;
	public GameObject healthPrefab;
	public GameObject healthPanel;
	// Use this for initialization
	void Start () {
		healthPanel = Instantiate (healthPrefab) as GameObject;
		healthPanel.transform.SetParent (this.transform);
		offset = new Vector3(0,5,0);
		healthPanel.transform.position = this.transform.position + offset;
		stats = this.GetComponent<Stats> ();
		content = GameObject.FindWithTag ("Health Bar Content").GetComponent<Image> () as Image;
	}
	
	// Update is called once per frame
	void Update () {
		healthPanel.transform.position = this.transform.position + offset;
		fillAmount = Map (stats.getHP (), 0, stats.getMaxHP (), 0, 1); 
		HandleBar ();
	}
	void HandleBar (){
		if (fillAmount != content.fillAmount) {
			content.fillAmount = fillAmount;
		}
	}
	float Map(float currHealth, float minHealth, float maxHealth, float minScale, float maxScale){
		return (currHealth - minHealth) * (maxScale - minScale) / (maxHealth - minHealth) + minScale;
	}
}

