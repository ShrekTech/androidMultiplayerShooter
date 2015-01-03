using System;
using UnityEngine;

namespace Damage
{
	public class DamageAdministerer : MonoBehaviour
	{
		public float damageAdministered;
		public GameObject explosion;

		void OnCollisionEnter(Collision entity) {
			Debug.Log ("This was hit: " + entity.gameObject.name);
			DamageReceiver recipientOfDamage = entity.collider.GetComponent<DamageReceiver> ();
			if (recipientOfDamage != null && entity.gameObject.name.Contains("Horse")) {
				recipientOfDamage.TakeDamage (damageAdministered);
				MonoBehaviour.Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
			}
		}
	}
}

