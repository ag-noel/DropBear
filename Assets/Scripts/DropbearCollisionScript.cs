using UnityEngine;
using System.Collections;

public class DropbearCollisionScript : MonoBehaviour {

    public float health = 3;
    public GUIText healthText;

    private CameraShakeScript cameraShakeScript;
    public Camera mainCamera;

    private ObstacleScript obstacleScript;
	public GameObject dropbear;
	private Animator DropBearAnimator;

    private Renderer rendr;
    public int blinkNumber = 5;
    public float colliderOffDelay = 0.2f;
    public float blinkDelay = 0.1f;

    void Start()
    {
        healthText.text = "HEALTH: " + health;
        cameraShakeScript = mainCamera.GetComponent<CameraShakeScript>();

		DropBearAnimator = dropbear.GetComponent<Animator> ();
        rendr = GetComponentInChildren<Renderer>();

    }

    IEnumerator InvincibilityFlash()
    {
        yield return new WaitForSeconds(colliderOffDelay);
        this.GetComponent<CapsuleCollider>().enabled = false;
        for (int n = 0; n < blinkNumber; n++)
        {
            rendr.enabled = true;
            yield return new WaitForSeconds(blinkDelay);
            rendr.enabled = false;
            yield return new WaitForSeconds(blinkDelay);
        }
        this.GetComponent<CapsuleCollider>().enabled = true;
        rendr.enabled = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            obstacleScript = other.gameObject.GetComponent<ObstacleScript>();

            if (obstacleScript.isHit == false)
            {
                obstacleScript.isHit = true;
				cameraShakeScript.enabled = true;
                health -= 1;
                healthText.text = "HEALTH: " + health;
                this.GetComponent<DropBearMovementScript>().velocityControl = 0f;
				DropBearAnimator.SetTrigger("Hit");
				StartCoroutine(InvincibilityFlash());
            }
		}
	}
}
