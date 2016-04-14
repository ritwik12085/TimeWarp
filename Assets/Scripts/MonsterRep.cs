using UnityEngine;
using System.Collections;

public class MonsterRep : MonoBehaviour {

    public int repPoints;
    public Reputation reputation;
    public GameObject me;
    private bool updated;
    void Start()
    {
        updated = false;
    }
	void Update () {
	    if(!me.activeSelf && reputation.getReputation() < 100 && !updated){
            reputation.addRep(repPoints);
            updated = true;
        }
	}
}
