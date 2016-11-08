using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

    private float score;
    private float scoreMultipler;

    public float score2xThreshold;
    public float score4xThreshold;
    public float score8xThreshold;


    public GameObject dropbear;
    private Rigidbody rbody;
    private DropBearMovementScript dropbearScript;
    private DropbearCollisionScript dropbearCollision;

    public GUIText startText;
    public GUIText scoreText;
    public GUIText bonusText;
    public GUIText endText;

    void Paused(bool paused)
    {
        if (paused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }

    // Use this for initialization
    void Start() {
        Paused(true);
        scoreText.text = "SCORE: 0";
        endText.text = "";

        rbody = dropbear.GetComponent<Rigidbody>();
        dropbearScript = dropbear.GetComponent<DropBearMovementScript>();
        dropbearCollision = dropbear.GetComponent<DropbearCollisionScript>();

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            Paused(false);
            Destroy(startText, 0.5f);
        }

        if (dropbearCollision.health < 1)
        {
            Paused(true);
            endText.text = "GAME OVER\nPress SPACE to restart";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    void Score(float multiplier)
    {
        score = ((rbody.transform.position.y * -1)) * multiplier;
        scoreText.text = "SCORE: " + string.Format("{0:#}", score);
    }

    void LateUpdate()
    {
        Score(1);
        bonusText.text = "";

        if (dropbearScript.velocityControl >= 0.01f)
        {
            Score(2);
            bonusText.text = "x2";
        }

        if (dropbearScript.velocityControl >= 0.03f)
        {
            Score(4);
            bonusText.text = "x2 x4";
        }

        if (dropbearScript.velocityControl >= 0.07f)
        {
            Score(4);
            bonusText.text = "x2 x4 x8";
        }
    }
}