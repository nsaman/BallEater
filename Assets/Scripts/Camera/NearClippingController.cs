using UnityEngine;
using System.Collections;

public class NearClippingController : MonoBehaviour {
    
    private Globals globals;

    // Use this for initialization
    void Start ()
    {
        globals = Globals.Instance;
        Camera.main.nearClipPlane = globals.NEARCLIPPLANE;
    }
}
