using UnityEngine;
using System.Collections;

public class Reputation : MonoBehaviour {
    private int reputation;
    private int repStatus;
	// Use this for initialization
	void Start () {
        reputation = 50;
	}
    void Update(){
        if (reputation <= 70){
            repStatus = 0;
        }
        /*else if (reputation <= 66){
            repStatus = 1;
        }*/
        else if(reputation <= 100){
            repStatus = 1;
        }
        if(reputation > 100)
        {
            reputation = 100;
        }
    }
    public void addRep(int rep){
        reputation += rep;
    }
    public void subRep(int rep){
        reputation -= rep;
		Debug.Log (reputation);
    }
    public int getRepStatus(){
        return repStatus;
    }
    public int getReputation(){
        return reputation;
    }
}
