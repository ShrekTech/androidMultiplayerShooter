using UnityEngine;
using System.Collections;

public class Enemy : DamageReceiver {
	
	void Start () {
	
	}

	void Update () {
	
	}


	public override void TakeDamage (float damageReceived)
	{
		Destroy (gameObject);
	}

}
