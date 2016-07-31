using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

    public float force = 1000.0f;
    public float radius = 100.0f;
    public ForceMode forceMode;
    void OnCollisionEnter(Collision collision)
    {
        Vector3 blast_location = transform.position;

        if (collision.collider.tag == "Bomb")
            return;

        foreach (Collider col in Physics.OverlapSphere(transform.position, radius))
        {
            if (col.GetComponent<Rigidbody>() != null && col.tag != "Bomb")
            {
                float distance = Mathf.Pow(Vector3.Distance(transform.position, col.transform.position) - transform.localScale.x, 2);
                if (distance < 1)
                    distance = 1;
                col.GetComponent<Rigidbody>().AddExplosionForce(force/ distance, blast_location, radius, 0.0f, forceMode);
            }
        }

        Destroy(gameObject);
    }
}
