using UnityEngine;
using System.Collections;

public class DropBearMovementScript : MonoBehaviour {

	public Rigidbody rbody;
	public float speed = 5.0f;
	public float tilt;
	public float returnSpeed;
	public float dropSpeed;

    private float dropSpeedVelocity;
    public float velocityControl = 0f;
    public float maxVelocity;
    public float minVelocity;
    public float velocityDelay;

	Vector3 velocity;
	Vector3 oldPosition;

	void Start () {

		oldPosition = transform.position;
		rbody = GetComponent<Rigidbody> ();
	}

    public void VelocityLerp()
    {
        velocityControl += Time.deltaTime / velocityDelay;

        dropSpeedVelocity = Mathf.Lerp(minVelocity, maxVelocity, velocityControl);
    }

	// Update is called once per frame
	void Update () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float currentY = transform.position.y;

        VelocityLerp();

		Vector3 movement = new Vector3 (moveHorizontal, dropSpeed * dropSpeedVelocity, moveVertical);
	
		rbody.velocity = movement * speed;

		{
			if (Input.anyKey) {
				rbody.rotation = Quaternion.Euler (rbody.velocity.z * tilt, 0.0f, rbody.velocity.x * -tilt);
				rbody.position = new Vector3 (rbody.position.x, currentY, rbody.position.z);

			} 
			else {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(oldPosition.x, currentY, oldPosition.z), speed * Time.deltaTime * returnSpeed);
				rbody.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f * Time.deltaTime);
				rbody.rotation = Quaternion.Euler (rbody.velocity.z * tilt, 0.0f, rbody.velocity.x * -tilt);
			}
		}

	}
}

