using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

    public Rigidbody target;
    float zStart;
    float xStart;

    void Start()
    {
        xStart = transform.position.x;
        zStart = transform.position.z;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        this.transform.position = new Vector3(xStart, target.transform.position.y, zStart);
	}
}
