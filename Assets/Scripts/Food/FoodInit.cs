using UnityEngine;
using System.Collections;

public class FoodInit : MonoBehaviour {
    
    private Rigidbody rb;
    private Transform trans;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();

        float edge = 1/(Random.value*5+.1f);
        rb.mass = edge * edge * edge;
        trans.localScale = new Vector3(edge, edge, edge);
    }
}
