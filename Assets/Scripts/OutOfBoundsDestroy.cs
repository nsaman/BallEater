using UnityEngine;
using System.Collections;

public class OutOfBoundsDestroy : MonoBehaviour {

    private Transform trans;

    void Start()
    {
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(trans.position.y < - 10)
            this.gameObject.SetActive(false);

    }
}
