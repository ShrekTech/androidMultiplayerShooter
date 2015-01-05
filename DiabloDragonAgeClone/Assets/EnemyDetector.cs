using UnityEngine;
using System.Collections;

public class EnemyDetector : MonoBehaviour {

	public delegate void EnemyDetectedHandler(Vector3 enemyPosition);
	public static event EnemyDetectedHandler enemyDetected;

	void Start () {
	
	}

	void Update () {

		Transform cameraMainTransform = Camera.main.transform;
		Vector3 forwardFromCamera = cameraMainTransform.TransformDirection (Vector3.forward);
		
		RaycastHit hit;
		
		if (Physics.Raycast (cameraMainTransform.TransformPoint(0.5f * Vector3.right), forwardFromCamera, out hit)) {
			if(hit.collider.gameObject.name.Contains("Horse")) {
				if(enemyDetected != null)
					enemyDetected(hit.collider.bounds.center);
			}
		}
	
	}
}
