using UnityEngine;
using System.Collections;

public class ClippingController : MonoBehaviour {

    private Globals globals;

    // Use this for initialization
    void Start()
    {
        globals = Globals.Instance;
        Camera.main.nearClipPlane = globals.NEARCLIPPLANE;
        Camera.main.farClipPlane = globals.FARCLIPPLANE;
    }
}
