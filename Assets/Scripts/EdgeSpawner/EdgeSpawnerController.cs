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
            GameObject northWall = (GameObject)Instantiate(wall, new Vector3(0, globals.WALLHEIGHT/ 4f - .5f, globals.GROUNDZSIZE / 2f), Quaternion.identity);
            //northWall.GetComponent<Transform>().Rotate(-90, 0, 0);
            northWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDXSIZE, globals.WALLHEIGHT/2f, .5f);
            GameObject southWall = (GameObject)Instantiate(wall, new Vector3(0, globals.WALLHEIGHT / 4f - .5f, -globals.GROUNDZSIZE / 2f), Quaternion.identity);
            //southWall.GetComponent<Transform>().Rotate(90, 0, 0);
            southWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDXSIZE, globals.WALLHEIGHT/2f, .5f);
            GameObject eastWall = (GameObject)Instantiate(wall, new Vector3(-globals.GROUNDXSIZE / 2f, globals.WALLHEIGHT / 4f - .5f, 0), Quaternion.identity);
            //eastWall.GetComponent<Transform>().Rotate(0, 0, -90);
            eastWall.GetComponent<Transform>().localScale = new Vector3(.5f, globals.WALLHEIGHT/2f, globals.GROUNDZSIZE);
            GameObject westWall = (GameObject)Instantiate(wall, new Vector3(globals.GROUNDXSIZE / 2f, globals.WALLHEIGHT /4f -.5f, 0), Quaternion.identity);
            //westWall.GetComponent<Transform>().Rotate(0, 0, 90);
            westWall.GetComponent<Transform>().localScale = new Vector3(.5f, globals.WALLHEIGHT/2f, globals.GROUNDZSIZE);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
