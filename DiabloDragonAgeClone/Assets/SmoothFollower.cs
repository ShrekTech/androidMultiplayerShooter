using UnityEngine;
using System.Collections;

public class SmoothFollower : MonoBehaviour {

	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 5.0f;
	public float rotationDamping = 3.0f;

	private EnemyDetectedListener enemyDetectedListener;

	void Start () {
		enemyDetectedListener = new EnemyDetectedListener ();
	}
	
	void LateUpdate () {
		// Early out if we don't have a target
		if (target == null)
			return;

		transform.position = target.position;
		
		if (enemyDetectedListener.IsEnemyDetected()) {
			transform.LookAt(enemyDetectedListener.GetEnemyPosition());
		} else {	
			transform.LookAt (target);
		}
		
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;

		float currentRotationAngleY = transform.eulerAngles.y;
		float currentRotationAngleX = transform.eulerAngles.x;
		
		// Damp the rotation around the y-axis
		currentRotationAngleY = Mathf.LerpAngle (currentRotationAngleY, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (currentRotationAngleX, currentRotationAngleY, 0);
		
		Vector3 offsetBehindCharacter = new Vector3(0, 0, distance);
		transform.position -= currentRotation * offsetBehindCharacter;
	}
}
