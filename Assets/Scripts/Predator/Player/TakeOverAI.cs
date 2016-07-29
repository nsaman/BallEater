using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Cameras;

public class TakeOverAI : MonoBehaviour
{

    private Globals globals;
    bool parentDied = true;

    void Start()
    {
        globals = Globals.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            parentDied = false;
            SwitchToLargetTeamate();
        }
    }

    // todo add a button to switch to largest teamate

    void OnDestroy()
    {
        if (parentDied)
            SwitchToLargetTeamate();
    }

    // look through possible teamates, take over
    void SwitchToLargetTeamate()
    {
        GameObject currentTarget = null;
        float currentLargestMass = 0;

        if (globals.CANSWITCHWITHTEAM)
        {
            List<GameObject> edibles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Edible"));

            // get rid of self
            edibles.Remove(gameObject);

            // look through things to switch with
            foreach (GameObject edible in edibles)
            {
                // if teammate
                if (edible.GetComponent<TeamPointer>().TeamController == GetComponent<TeamPointer>().TeamController)
                {
                    if (currentLargestMass < edible.GetComponent<Rigidbody>().mass)
                    {
                        currentLargestMass = edible.GetComponent<Rigidbody>().mass;
                        currentTarget = edible;
                    }
                }
            }

            if (currentTarget != null)
            {
                currentTarget.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Materials/Polka Dot");
                GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Materials/checkered");
                currentTarget.GetComponent<TeamPointer>().TeamController = currentTarget.GetComponent<TeamPointer>().TeamController;
                GetComponent<TeamPointer>().TeamController = GetComponent<TeamPointer>().TeamController;

                GameObject cam = Camera.main.transform.parent.gameObject.transform.parent.gameObject;
                cam.GetComponent<FreeLookCam>().SetTarget(currentTarget.transform);
                cam.GetComponent<ProtectCameraFromWallClip>().playerRb = currentTarget.GetComponent<Rigidbody>();

                // todo find a way to not have to keep changing the ai script (interface?)
                
                Destroy(currentTarget.GetComponent<AIEffectiveDist>());
                Destroy(GetComponent<SphereMoveScript>());
                Destroy(GetComponent<TakeOverAI>());
                gameObject.AddComponent<AIEffectiveDist>();
                currentTarget.AddComponent<SphereMoveScript>();
                currentTarget.AddComponent<TakeOverAI>();
                
                GameObject.FindGameObjectWithTag("Ground").GetComponent<FPSDisplay>().player = currentTarget;
            }
        }
    }
}
