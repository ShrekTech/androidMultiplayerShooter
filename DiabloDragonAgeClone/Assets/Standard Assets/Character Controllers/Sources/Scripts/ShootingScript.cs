using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public Rigidbody projectile;
	public float speed;
	public float reloadInterval;

	private GunState previousGunState;
	private float reloadIntervalElapsed;

	void Start () {
		previousGunState = GunState.IDLE;
		reloadIntervalElapsed = 0;
	}
	
	void Update () {

		GunState currentGunState = DetermineGunState ();

		switch (currentGunState) {
			case GunState.IDLE : 
				if (previousGunState.Equals(GunState.RELOADING)) {
					reloadIntervalElapsed = 0;
				}
				break;
			case GunState.FIRING :
				if (previousGunState.Equals(GunState.RELOADING)) {
					reloadIntervalElapsed = 0;
				}
				Rigidbody projectileClone = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
				projectileClone.velocity = transform.TransformDirection(new Vector3 (0, 0, speed));
				Destroy (projectileClone.gameObject, 3);
				break;
			case GunState.RELOADING : 
				reloadIntervalElapsed += Time.deltaTime;
				break;
			default:
				throw new UnityException("unknown gun state: " + previousGunState);
		}

		previousGunState = currentGunState;

	}

	GunState DetermineGunState ()
	{
		switch (previousGunState) {
			case GunState.IDLE : 
				if (Input.GetButton ("Fire1")) {
					return GunState.FIRING;
				} else {
					return GunState.IDLE;
				}
			case GunState.FIRING : 
				return GunState.RELOADING;
			case GunState.RELOADING : 
			if (reloadIntervalElapsed < reloadInterval) {
					return GunState.RELOADING;
				} else if (Input.GetButton ("Fire1")) {
					return GunState.FIRING;
				} else {
				return GunState.IDLE;
				}
			default:
				throw new UnityException("unknown gun state: " + previousGunState);
		}
	}

	private enum GunState {
		IDLE,
		FIRING,
		RELOADING
	}
}
