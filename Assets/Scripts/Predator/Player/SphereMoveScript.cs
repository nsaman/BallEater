using UnityEngine;
using System.Collections;

public class SphereMoveScript : MonoBehaviour {

    private Rigidbody rb;
    private static float speed = 100;
    private Transform cam;
    private bool canJump;
    private Globals globals;
    public float timeSinceLastSplit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
        cam = Camera.main.transform;
        globals = Globals.Instance;
        timeSinceLastSplit = globals.MINTIMESPLIT;
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (inputDirection.sqrMagnitude > 1)
        {
            inputDirection = inputDirection.normalized;
        }
        
        // set movement direction based on camera
        Vector3 newRight = Vector3.Cross(Vector3.up, cam.forward);
        Vector3 newForward = Vector3.Cross(newRight, Vector3.up);
        Vector3 movement = (newRight * inputDirection.x) + (newForward * inputDirection.y);
        
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            movement.y += (Mathf.Sqrt(rb.mass) + 70) / 1.5f;
            canJump = false;
        }

        rb.AddForce (movement * speed * Time.deltaTime * (rb.mass + 1)/1.08f);

        timeSinceLastSplit += Time.deltaTime;
        if (globals.CANSPLIT && Input.GetKeyDown(KeyCode.LeftShift) && timeSinceLastSplit >= globals.MINTIMESPLIT)
        {
            GetComponent<Split>().DoPlayerSplit();
            timeSinceLastSplit = 0;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GetComponent<Blast>().blast_test();
            print("X_TEST");
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
