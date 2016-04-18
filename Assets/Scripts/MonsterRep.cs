using UnityEngine;
using System.Collections;

public class MonsterRep : MonoBehaviour {

    public int repPoints;
    private Reputation reputation;
    public GameObject me;
    private bool updated;
    void Start()
    {
        reputation = GameObject.FindWithTag("Player").GetComponent<Reputation>();
        updated = false;
    }
	void Update () {
	    if(!me.activeSelf && reputation.getReputation() < 100 && !updated){
            reputation.addRep(repPoints);
            updated = true;
        }
	}
}
