using UnityEngine;
using System.Collections;

public class Blast : MonoBehaviour {

    public float force = 100.0f;
    public float radius = 5.0f;
    public ForceMode forceMode;
        
	
	public void blast_test ()
    {
        Vector3 blast_location = transform.position;
        blast_location.y += 0.7f;

        foreach (Collider col in Physics.OverlapSphere(transform.position, radius))
        {
            if (col.GetComponent<Rigidbody>() != null)
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(force, blast_location, radius, 0.0f, forceMode);
            }
        }  
	}
	

}
