using UnityEngine;
using System.Collections;

public class GroundInit : MonoBehaviour {

    private Transform trans;
    public Globals globals;

    void Start()
    {
        globals = Globals.Instance;
        trans = GetComponent<Transform>();
        trans.localScale = new Vector3(globals.GROUNDXSIZE/10,1, globals.GROUNDZSIZE/10);
    }
}
