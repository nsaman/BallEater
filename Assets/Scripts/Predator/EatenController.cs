using UnityEngine;
using System.Collections;

public class EatenController : MonoBehaviour {

    private GameObject eatenBy;
    private float originalScale;
    private bool isEaten = false;

    public void Eaten (GameObject eater)
    {
        eatenBy = eater;
        isEaten = true;
        originalScale = GetComponent<Transform>().localScale.x;
    }
    void LateUpdate()
    {
        if (isEaten)
        {
            // remove anything that will mess up the eat animation
            if (GetComponent<SphereMoveScript>() != null)
                Destroy(GetComponent<SphereMoveScript>());
            if (GetComponent<AIEffectiveDist>() != null)
                Destroy(GetComponent<AIEffectiveDist>());
            if (GetComponent<Rigidbody>() != null)
                Destroy(GetComponent<Rigidbody>());
            if (GetComponent<BoxCollider>() != null)
                Destroy(GetComponent<BoxCollider>());
            if (GetComponent<SphereCollider>() != null)
                Destroy(GetComponent<SphereCollider>());
            if (GetComponent<OutOfBoundsDestroy>() != null)
                Destroy(GetComponent<OutOfBoundsDestroy>());
            if (GetComponent<EatController>() != null)
                Destroy(GetComponent<EatController>());
        }
    }

	// Update is called once per frame
	void Update () {
	    if(isEaten)
        {
            Transform transform = GetComponent<Transform>();

            if (transform.localScale.x < originalScale / 10)
                Destroy(gameObject);
            else
            {
                transform.localScale = new Vector3(transform.localScale.x/(1 + 9f * Time.deltaTime), transform.localScale.y/ (1 + 9f * Time.deltaTime), transform.localScale.z/ (1 + 9f * Time.deltaTime));
                // move towards the center of the eater, this is probably going to be bad at low fps
                transform.position += (eatenBy.transform.position + new Vector3(0,eatenBy.transform.localScale.y/2,0) - transform.position) * 2.5f * Time.deltaTime;
                isEaten = true;
            }

        }
	}
}
