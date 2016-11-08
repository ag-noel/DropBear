using UnityEngine;
using System.Collections;

public class OutlineOff : MonoBehaviour {

    public GUIText parentText;

	// Update is called once per frame
	void LateUpdate () {
        if (parentText == null)
        {
            Destroy(this.gameObject);
        }
	}
}
