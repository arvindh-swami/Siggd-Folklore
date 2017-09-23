using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class Controller : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX;
	public float sensitivityY;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;
	public float movementSpeed;
	public GameObject fireBall;

	private Rigidbody rb;
	public int jumpForce;
	float lastJump = 0;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (fireBall, new Vector3(transform.position.x, transform.position.y + 1F, transform.position.z), Quaternion.identity);
		}
		if(Input.GetKey(KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * movementSpeed;
		}
		if(Input.GetKey(KeyCode.S)) {
			transform.position -= transform.forward * Time.deltaTime * movementSpeed;
		}
		if (Input.GetKey (KeyCode.Space) && Time.time - lastJump >= 1) {
			rb.AddForce(new Vector3(0, jumpForce, 0));
			lastJump = Time.time;
		}
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		if (rb) 
			rb.freezeRotation = true;
	}
}