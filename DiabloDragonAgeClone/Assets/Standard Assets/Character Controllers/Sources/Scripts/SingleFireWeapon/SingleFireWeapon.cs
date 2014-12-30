using UnityEngine;
using System.Collections;
using SingleFire;

public class SingleFireWeapon : MonoBehaviour {

	public Rigidbody projectile;
	public float speed;
	public float reloadInterval;

	private SingleFireWeaponState gunState;

	void Start () {
		gunState = new IdleState ();
	}
	
	void Update () {
		gunState = gunState.handleInput ();
		gunState.update (this);
	}


}
