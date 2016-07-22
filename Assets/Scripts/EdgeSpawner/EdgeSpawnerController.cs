using UnityEngine;
using System.Collections;

public class EdgeSpawnerController : MonoBehaviour {

    public GameObject wall;
    private Globals globals;

    // Use this for initialization
    void Start()
    {
        globals = Globals.Instance;
        if (globals.HASEDGEWALLS)
        {
            GameObject northWall = (GameObject)Instantiate(wall, new Vector3(0, 0, globals.GROUNDZSIZE / 2), Quaternion.identity);
            northWall.GetComponent<Transform>().Rotate(-90, 0, 0);
            northWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDZSIZE / 10, 1, globals.WALLHEIGHT);
            GameObject southWall = (GameObject)Instantiate(wall, new Vector3(0, 0, -globals.GROUNDZSIZE / 2), Quaternion.identity);
            southWall.GetComponent<Transform>().Rotate(90, 0, 0);
            southWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDZSIZE / 10, 1, globals.WALLHEIGHT);
            GameObject eastWall = (GameObject)Instantiate(wall, new Vector3(-globals.GROUNDXSIZE / 2, 0, 0), Quaternion.identity);
            eastWall.GetComponent<Transform>().Rotate(0, 0, -90);
            eastWall.GetComponent<Transform>().localScale = new Vector3(globals.WALLHEIGHT, 1, globals.GROUNDZSIZE / 10);
            GameObject westWall = (GameObject)Instantiate(wall, new Vector3(globals.GROUNDXSIZE / 2, 0, 0), Quaternion.identity);
            westWall.GetComponent<Transform>().Rotate(0, 0, 90);
            westWall.GetComponent<Transform>().localScale = new Vector3(globals.WALLHEIGHT, 1, globals.GROUNDZSIZE / 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
