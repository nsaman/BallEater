using UnityEngine;
using System.Collections;

public class Split : MonoBehaviour {

    private Transform tf;
    private Rigidbody rb;
    private Camera cam;
    private TeamPointer tp;
    private Globals globals;
    GameObject ballPrefab;

    // Use this for initialization
    void Start ()
    {
        ballPrefab = (GameObject)Resources.Load("Prefabs/Ball");
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        tp = GetComponent<TeamPointer>();
        globals = Globals.Instance;
    }

    public void DoPlayerSplit()
    {
        DoSplit(cam.transform.forward);
    }

    public void DoSplit(Vector3 spawnDirection)
    {
        // no cheating
        if (spawnDirection.sqrMagnitude > 1)
        {
            spawnDirection = spawnDirection.normalized;
        }

        if (globals.CANSPLIT && rb.mass > globals.MINSPLITMASS)
        {
            rb.mass = rb.mass / 2;

            //make sure we don't spawn the guy under the ground
            Vector3 spawnLocation = tf.position + spawnDirection * (Mathf.Pow((3f * rb.mass / 4 / Mathf.PI), 1f / 3f)) * 3f;
            if (spawnLocation.y < 0)
                spawnLocation.y = 0;

            GameObject npc = (GameObject)Instantiate(ballPrefab, spawnLocation, Quaternion.identity);
            npc.GetComponent<TeamPointer>().TeamController = tp.TeamController;
            npc.GetComponent<Rigidbody>().mass = rb.mass;

            // add this force plus launch force of split
            npc.GetComponent<Rigidbody>().AddForce(rb.velocity + spawnDirection * globals.SPLITSPEED * rb.mass);
        }
    }
}
