using UnityEngine;
using System.Collections;
using ChargedAttack;

public class ChargedAttackWeapon : MonoBehaviour {

	public Rigidbody projectile;
	public float speed;

	private IChargeGunState gunState;

	void Start () {
		gunState = new IdleState();
	}

	void Update () {
		gunState = gunState.HandleInput ();
		gunState.Update (this);
	}

}
