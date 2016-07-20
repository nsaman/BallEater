using UnityEngine;
using System.Collections;

public class FoodInit : MonoBehaviour {
    
    private Rigidbody rb;
    private Transform trans;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();

        // give food random size
        // food spawns inverse func between mass .008 to 1000  
        float edge = 1/(Random.value*5+.1f);
        rb.mass = edge * edge * edge;
        trans.localScale = new Vector3(edge, edge, edge);
    }
}
