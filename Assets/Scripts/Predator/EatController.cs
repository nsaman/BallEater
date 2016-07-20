using UnityEngine;
using System.Collections;

public class EatController : MonoBehaviour {

    private Rigidbody rb;
    private Transform trans;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }
    
    void Update ()
    {
        float expectedScale = 2 * Mathf.Pow((rb.mass * 3) / (4 * Mathf.PI), 1f / 3f);
        float currentScale = trans.localScale.x;
        if (currentScale / expectedScale < .99f)
        {
            float newScale = currentScale + (expectedScale - currentScale) / 10;
            trans.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.gameObject.CompareTag("Edible") && collision.collider.GetComponent<TeamPointer>().TeamController != GetComponent<TeamPointer>().TeamController)
            || collision.collider.gameObject.CompareTag("Food"))
        {
            Rigidbody otherRB = collision.collider.GetComponent<Rigidbody>();

            if (rb.mass > otherRB.mass)
            {
                rb.mass += otherRB.mass;
                collision.collider.gameObject.SetActive(false);
            }
        }
    }
}
