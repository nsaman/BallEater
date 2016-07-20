using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionSplash : MonoBehaviour {
    
    void OnCollisionEnter(Collision collision) {
        
        if (collision.collider.tag == "Ground")
        {
            // get list of available foods
            List<GameObject> foods = new List<GameObject>(GameObject.FindGameObjectsWithTag("Food"));
            List<GameObject> edibles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Edible"));
            
            foods.AddRange(edibles);
            foods.Remove(gameObject);

            foreach (GameObject food in foods)
            {
                Vector3 force = food.GetComponent<Transform>().position - GetComponent<Transform>().position;
                food.GetComponent<Rigidbody>().AddForce(force.normalized / Mathf.Pow(force.magnitude, 2) * Mathf.Sqrt(collision.relativeVelocity.magnitude));     
            }
        }
    }
}
