using UnityEngine;
using System.Collections;

public class OutOfBoundsDestroy : MonoBehaviour {

    private Transform trans;

    void Start()
    {
        trans = GetComponent<Transform>();
    }
	
	// Check if out of bounds vertically
	void Update () {
	    if(trans.position.y < - 10)
            this.gameObject.SetActive(false);

    }
}
