using UnityEngine;
using System.Collections;
using Application;

public class ChargedAttackWeapon : MonoBehaviour {

	public Rigidbody projectile;
	public float speed;
//	public float chargeInterval;
//	public float cooldownInterval;

	private ChargeGunState gunState;

	void Start () {
		gunState = new IdleState();
	}

	void Update () {
		gunState = gunState.handleInput ();
		gunState.update (this);
	}

}
