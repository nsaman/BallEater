using UnityEngine;
using System.Collections;

public class RayCastController : MonoBehaviour
{

    GameObject createdObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /// handle object creation/placement
        // on right click
        if (Input.GetMouseButtonDown(1))
        {
            // place object on second right click
            if (createdObject != null)
            {
                createdObject.GetComponent<BoxCollider>().enabled = true;
                createdObject = null;
            }
            // create object on first right click
            else
            {
                createdObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                createdObject.GetComponent<BoxCollider>().enabled = false;
            }
        }

        /// handle drawing of object
        // update the cubes position
        if (createdObject != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    createdObject.SetActive(true);
                    createdObject.transform.position = hit.point;
                }
            }
            else
                createdObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {

    }
}
