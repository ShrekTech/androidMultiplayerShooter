using UnityEngine;
using System.Collections;
using ChargedAttack;

public class ChargedAttackWeapon : MonoBehaviour {

	public Rigidbody projectile;
	public float speed;

	private ChargeGunState gunState;

	void Start () {
		gunState = new IdleState();
	}

	void Update () {
		gunState = gunState.handleInput ();
		gunState.update (this);
	}

}
