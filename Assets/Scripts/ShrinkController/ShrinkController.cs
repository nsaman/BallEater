using UnityEngine;
using System.Collections;

public class ShrinkController : MonoBehaviour {

    private Globals globals;
    private float startingXSize;
    private float startingZSize;

    // Use this for initialization
    void Start ()
    {
        globals = Globals.Instance;
        startingXSize = globals.GROUNDXSIZE;
        startingZSize = globals.GROUNDZSIZE;
    }
	
	// Update is called once per frame
	void Update () {
        if (globals.ISSHRINKING && globals.GROUNDXSIZE > globals.SHRINKMINSIZE)
        {
            globals.GROUNDXSIZE -= startingXSize / globals.SHRINKTIMETILLMIN * Time.deltaTime;
            if (globals.GROUNDXSIZE < globals.SHRINKMINSIZE)
                globals.GROUNDXSIZE = globals.SHRINKMINSIZE;
        }
        if (globals.ISSHRINKING && globals.GROUNDZSIZE > globals.SHRINKMINSIZE)
        {
            globals.GROUNDZSIZE -= startingZSize / globals.SHRINKTIMETILLMIN * Time.deltaTime;
            if (globals.GROUNDZSIZE < globals.SHRINKMINSIZE)
                globals.GROUNDZSIZE = globals.SHRINKMINSIZE;
        }
    }
}
