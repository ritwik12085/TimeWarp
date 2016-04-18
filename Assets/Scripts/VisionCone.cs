using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class VisionCone : MonoBehaviour {
	public GameObject player;
	public float farVisionCone;
	public float farDistance;
	public float closeVisionCone;
	public float closeDistance;
	private Boolean canSee;
	private Boolean canAttack;
	private Vector3 direction;
    private float HP;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
	void Update() {
		Vector3 targetDir = player.transform.position - transform.position;
        if(player.GetComponent<PlayerAttack> ().getEnemyClicked() && (Vector3.Distance(this.transform.position, player.transform.position) < player.GetComponent<Stats>().getAttackRange()) ){
            direction = player.transform.position;
        }
        else{
             direction = this.gameObject.GetComponent<AIMovementType1>().getDirection();
        }
		float distance = Vector3.Distance(player.transform.position, transform.position);
		float angle = Vector3.Angle(targetDir, direction);
		if (angle <= closeVisionCone && distance <= closeDistance) {
			canAttack = true;
			canSee = true;
		} else if (angle <= farVisionCone && distance <= farDistance) {
			canSee = true;
			canAttack = false;
		} 
		else {
			canSee = false;
			canAttack = false;
		}
	}
	public Boolean getCanAttack(){
		return canAttack;
	}
	public Boolean getCanSee(){
		return canSee;
	}
}
