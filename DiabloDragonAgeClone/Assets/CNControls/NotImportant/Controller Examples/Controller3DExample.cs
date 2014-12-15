using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller3DExample : MonoBehaviour
{
    public const float ROTATE_SPEED = 15f;

    public float movementSpeed = 5f;

    public CNAbstractController MovementJoystick;
	public CNTouchpad touchPad;

    private CharacterController _characterController;
    private Transform _mainCameraTransform;
    private Transform _transformCache;
    private Transform _playerTransform;

    void Start()
    {
        // You can also move the character with an event system
        // You MUST CHOOSE one method and use ONLY ONE a frame
        // If you wan't the event based control, uncomment this line
        // MovementJoystick.JoystickMovedEvent += MoveWithEvent;

        _characterController = GetComponent<CharacterController>();
        _mainCameraTransform = Camera.main.transform;
        _transformCache = GetComponent<Transform>();
        _playerTransform = _transformCache.FindChild("Cocoon");
    }

    
    // Update is called once per frame
    void Update()
    {
        var joystickMovement = new Vector3(
            MovementJoystick.GetAxis("Horizontal"),
            0f,
            MovementJoystick.GetAxis("Vertical"));

		var touchPadMovement = new Vector3(
			touchPad.GetAxis("Horizontal"),
			0f,
			touchPad.GetAxis("Vertical"));

		Debug.Log("touchpad vector: " + touchPadMovement);

		CommonMovementMethod(joystickMovement, touchPadMovement);
    }

//    private void MoveWithEvent(Vector3 inputMovement)
//    {
//        var movement = new Vector3(
//            inputMovement.x,
//            0f,
//            inputMovement.y);
//
//        CommonMovementMethod(movement);
//    }

	private void CommonMovementMethod(Vector3 joystickMovement, Vector3 touchPadMovement)
    {
		joystickMovement = _mainCameraTransform.TransformDirection(joystickMovement);
		joystickMovement.y = 0f;
		joystickMovement.Normalize();

		FaceDirection(touchPadMovement);
		_characterController.Move(joystickMovement * movementSpeed * Time.deltaTime);
		_mainCameraTransform.position = _characterController.transform.position + 3*Vector3.back + Vector3.up;
    }

    public void FaceDirection(Vector3 direction)
    {
        StopCoroutine("RotateCoroutine");
        StartCoroutine("RotateCoroutine", direction);
    }

    IEnumerator RotateCoroutine(Vector3 direction)
    {
        if (direction == Vector3.zero) yield break;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        do
        {
            _playerTransform.rotation = Quaternion.Lerp(_playerTransform.rotation, lookRotation, Time.deltaTime * ROTATE_SPEED);
            yield return null;
        }
        while ((direction - _playerTransform.forward).sqrMagnitude > 0.2f);
    }

}
