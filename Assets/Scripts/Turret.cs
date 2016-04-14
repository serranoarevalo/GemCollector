using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject Claw = null;
	public Animator AnimController_Gun = null;
	private bool isShooting = false;
	private LayerMask currentMask;

	public bool IsShooting{
		get { 
			return isShooting;
		}
	}

	void Update(){
		if (Input.GetButtonDown ("Fire1") && !isShooting) {
			LaunchClaw ();
		}
	}

	private void LaunchClaw() {
		isShooting = true;

		if (AnimController_Gun != null) {
			AnimController_Gun.speed = 0f
		}

		RaycastHit hit;

		Vector3 down = transform.TransformDirection(Vector3.down);

		if(Physics.Raycast(transform.position, 	down, out hit, 100f)) {
			
		}
	}


	public void CollectedObject(){
		isShooting = false;

		if (AnimController_Gun != null) {
			AnimController_Gun.speed = 1f;
		}
	}
}
