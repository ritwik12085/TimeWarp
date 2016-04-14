using UnityEngine;
using System.Collections;

public class Healing : MonoBehaviour {
    private Stats stat;
    private float healTime;
    private float healSpeed;
	// Use this for initialization
	void Start () {
        stat = this.GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
        if (stat.getHP() < stat.getMaxHP())
        {
            if (Time.time > healTime + 15)
            {
                if (Time.time > healSpeed)
                {
                    stat.heal(5);
                    healSpeed = Time.time + 3;
                }
            }
        }
        else if(stat.getHP() < stat.getMaxHP())
        {

        }
	}

    public void setTime(float time){
        healTime = time;
    }
}
