using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour {

    bool seen = false;
    Renderer rendr;

    void Start()
    {
        rendr = GetComponent<Renderer>();
    }

    void Update()
    {
        if (rendr.isVisible)
            seen = true;

        if (seen && !rendr.isVisible)
            Destroy(gameObject);
    }

    /*public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }*/
}
