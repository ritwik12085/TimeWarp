using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	private float fillAmount;
	[SerializeField]
	private Image content;
	public Stats stats;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
