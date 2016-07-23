using UnityEngine;
using System.Collections;

public class Split : MonoBehaviour {

    private Transform tf;
    private Rigidbody rb;
    private Camera cam;
    public GameObject NPC;
    private TeamPointer tp;
    private Globals globals;

	// Use this for initialization
	void Start () {
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

            GameObject npc = (GameObject)Instantiate(NPC, tf.position + spawnDirection * tf.localScale.x / 2, Quaternion.identity);
            npc.GetComponent<TeamPointer>().TeamController = tp.TeamController;
            npc.GetComponent<Rigidbody>().mass = rb.mass;

            // add this force plus launch force of split
            npc.GetComponent<Rigidbody>().AddForce(rb.velocity + spawnDirection * 700f * rb.mass);
        }
    }
}
