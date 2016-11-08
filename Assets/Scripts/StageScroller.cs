using UnityEngine;
using System.Collections;

public class StageScroller : MonoBehaviour {

    public GameObject stage;
    public Transform[] stageSpawnPoints;

    void OnTriggerEnter(Collider hit)
    {
        //player has hit the collider
        if (hit.gameObject.tag == "Player")
        {

            for (int i = 0; i < stageSpawnPoints.Length; i++)
            {
                    Instantiate(stage, stageSpawnPoints[i].position + stage.transform.position / 2, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
            }

        }
    }

}
