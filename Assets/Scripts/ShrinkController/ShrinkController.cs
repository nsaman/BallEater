using UnityEngine;
using System.Collections;
using System;

public class ShrinkController : MonoBehaviour {

    private Globals globals;
    private float startingXSize;
    private float startingZSize;
    private DateTime dt;

    // Use this for initialization
    void Start ()
    {
        globals = Globals.Instance;
        startingXSize = globals.GROUNDXSIZE;
        startingZSize = globals.GROUNDZSIZE;
        dt = DateTime.UtcNow;
    }
	
	// Update is called once per frame
	void Update () {
        if (globals.ISSHRINKING)
        {
            if ((DateTime.UtcNow - dt).Seconds < globals.SHRINKTIMETILLEND)
                globals.GROUNDXSIZE -= (startingXSize - globals.SHRINKXENDSIZE) / globals.SHRINKTIMETILLEND * Time.deltaTime;
            else
                globals.GROUNDXSIZE = globals.SHRINKXENDSIZE;
            if ((DateTime.UtcNow - dt).Seconds < globals.SHRINKTIMETILLEND)
                globals.GROUNDZSIZE -= (startingZSize - globals.SHRINKZENDSIZE) / globals.SHRINKTIMETILLEND * Time.deltaTime;
            else
                globals.GROUNDZSIZE = globals.SHRINKZENDSIZE;
        }
    }
}
