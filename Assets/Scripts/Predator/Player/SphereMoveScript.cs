using UnityEngine;
using System.Collections;

public class SphereMoveScript : MonoBehaviour {

    private Rigidbody rb;
    private static float speed = 100;
    public Transform cam;
    private bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (inputDirection.sqrMagnitude > 1)
        {
            inputDirection = inputDirection.normalized;
        }
        
        Vector3 newRight = Vector3.Cross(Vector3.up, cam.forward);
        Vector3 newForward = Vector3.Cross(newRight, Vector3.up);
        Vector3 movement = (newRight * inputDirection.x) + (newForward * inputDirection.y);
        
        if (Input.GetKey("space") && canJump == true)
        {
            movement.y += (Mathf.Sqrt(rb.mass) + 70) / 1.5f;
            canJump = false;
        }

        rb.AddForce (movement * speed * Time.deltaTime * (rb.mass + 1)/1.08f);

    }


    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

}
