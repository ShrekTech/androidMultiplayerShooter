using UnityEngine;
using System.Collections;

public class ChargedAttackShooter : MonoBehaviour {

	public Rigidbody projectile;
	public float speed;
	public float chargeInterval;
	public float cooldownInterval;

	private GunState previousGunState;
	private float chargeIntervalElapsed;
	private float cooldownIntervalElapsed;



	void Start () {
		previousGunState = GunState.IDLE;
		chargeIntervalElapsed = 0;
		cooldownIntervalElapsed = 0;
	}

	GunState DetermineGunState ()
	{
		switch (previousGunState) {
			case GunState.IDLE : 
				if (Input.GetButton ("Fire2")) {
					return GunState.CHARGING;
				}
				return GunState.IDLE;
			case GunState.CHARGING : 
				if (chargeIntervalElapsed < chargeInterval) {
					return GunState.CHARGING;
				}
				return GunState.FIRING;
			case GunState.FIRING : 
				return GunState.COOLDOWN;
			case GunState.COOLDOWN : 
				if (cooldownIntervalElapsed < cooldownInterval) {
					return GunState.COOLDOWN;
				}
				if (Input.GetButton ("Fire2")) {
					return GunState.CHARGING;
				}
				return GunState.IDLE;
			default:
				throw new UnityException("unknown gun state: " + previousGunState);
		}
	}

	void Update () {
		GunState currentGunState = DetermineGunState ();

		switch (currentGunState) {
				case GunState.IDLE: 
					break;
				case GunState.CHARGING:
					if(previousGunState.Equals(GunState.IDLE)||(previousGunState.Equals(GunState.COOLDOWN))) {
						chargeIntervalElapsed = 0;
						break;
					}
					chargeIntervalElapsed += Time.deltaTime;
					break;
				case GunState.FIRING:
					for (int i = 0; i < 10; i++ ) {
						Rigidbody projectileClone = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
						projectileClone.velocity = transform.TransformDirection(new Vector3 (0, 0, speed));
						Destroy (projectileClone.gameObject, 3);
					}
					break;
				case GunState.COOLDOWN: 
					if (previousGunState.Equals(GunState.FIRING)) {
						cooldownIntervalElapsed = 0;
					}
					cooldownIntervalElapsed += Time.deltaTime;
					break;
				default:
					throw new UnityException ("unknown gun state: " + previousGunState);
				}

		previousGunState = currentGunState;
	}

	private enum GunState {
		IDLE,
		CHARGING,
		FIRING,
		COOLDOWN
	}

}
