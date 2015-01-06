using UnityEngine;
using System.Collections;

public class Enemy : DamageReceiver {

	public float health = 20.0f;
	public GameObject explosion;

	void Start () {
	
	}

	void Update () {
	
	}


	public override void TakeDamage (float damageReceived)
	{
		health -= damageReceived;
		if (health < 0) {
			MonoBehaviour.Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

}
