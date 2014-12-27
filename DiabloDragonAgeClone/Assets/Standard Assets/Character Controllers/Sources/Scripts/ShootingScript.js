var projectile : Rigidbody;
var speed = 0;

function Update () {

if ( Input.GetButton ("Fire1")) {

var clone = Instantiate(projectile, transform.position, transform.rotation);
clone.velocity = transform.TransformDirection( Vector3 (0, 0, speed));

Destroy (clone.gameObject, 3);

}}