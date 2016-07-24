using UnityEngine;
using System.Collections;

public class GroundInit : MonoBehaviour {

    private Transform trans;
    private Globals globals;

    void Start()
    {
        globals = Globals.Instance;
        trans = GetComponent<Transform>();
        trans.localScale = new Vector3(globals.GROUNDXSIZE,1, globals.GROUNDZSIZE);
    }

    void Update()
    {
        trans = GetComponent<Transform>();
        trans.localScale = new Vector3(globals.GROUNDXSIZE, 1, globals.GROUNDZSIZE);
    }
}
