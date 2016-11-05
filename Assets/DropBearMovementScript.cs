using UnityEngine;
using System.Collections;

public class DropBearMovementScript : MonoBehaviour {

	public Rigidbody rbody;
	public float speed;

	public float tilt;


	void Start () {
		rbody = GetComponent<Rigidbody> ();
	}
		
	// Update is called once per frame
	void FixedUpdate () {
	
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rbody.velocity = movement * speed;
		rbody.position = new Vector3 (rbody.position.x, 0.0f, rbody.position.z);

		rbody.rotation = Quaternion.Euler (rbody.velocity.z * tilt, 0.0f, rbody.velocity.x * -tilt);

		}
}
