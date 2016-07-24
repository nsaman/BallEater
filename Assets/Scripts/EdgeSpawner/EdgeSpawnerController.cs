using UnityEngine;
using System.Collections;

public class EdgeSpawnerController : MonoBehaviour {

    public GameObject wall;
    private Globals globals;
    private GameObject northWall;
    private GameObject southWall;
    private GameObject eastWall;
    private GameObject westWall;

    // Use this for initialization
    void Start()
    {
        globals = Globals.Instance;
        if (globals.HASEDGEWALLS)
        {
            northWall = (GameObject)Instantiate(wall, new Vector3(0, globals.WALLHEIGHT/ 4f - .5f, globals.GROUNDZSIZE / 2f), Quaternion.identity);
            northWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDXSIZE, globals.WALLHEIGHT/2f, .5f);
            southWall = (GameObject)Instantiate(wall, new Vector3(0, globals.WALLHEIGHT / 4f - .5f, -globals.GROUNDZSIZE / 2f), Quaternion.identity);
            southWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDXSIZE, globals.WALLHEIGHT/2f, .5f);
            eastWall = (GameObject)Instantiate(wall, new Vector3(-globals.GROUNDXSIZE / 2f, globals.WALLHEIGHT / 4f - .5f, 0), Quaternion.identity);
            eastWall.GetComponent<Transform>().localScale = new Vector3(.5f, globals.WALLHEIGHT/2f, globals.GROUNDZSIZE);
            westWall = (GameObject)Instantiate(wall, new Vector3(globals.GROUNDXSIZE / 2f, globals.WALLHEIGHT /4f -.5f, 0), Quaternion.identity);
            westWall.GetComponent<Transform>().localScale = new Vector3(.5f, globals.WALLHEIGHT/2f, globals.GROUNDZSIZE);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.HASEDGEWALLS && globals.ISSHRINKING)
        {
            northWall.GetComponent<Transform>().position = new Vector3(0, globals.WALLHEIGHT / 4f - .5f, globals.GROUNDZSIZE / 2f);
            northWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDXSIZE, globals.WALLHEIGHT / 2f, .5f);
            southWall.GetComponent<Transform>().position = new Vector3(0, globals.WALLHEIGHT / 4f - .5f, -globals.GROUNDZSIZE / 2f);
            southWall.GetComponent<Transform>().localScale = new Vector3(globals.GROUNDXSIZE, globals.WALLHEIGHT / 2f, .5f);
            eastWall.GetComponent<Transform>().position = new Vector3(-globals.GROUNDXSIZE / 2f, globals.WALLHEIGHT / 4f - .5f, 0);
            eastWall.GetComponent<Transform>().localScale = new Vector3(.5f, globals.WALLHEIGHT / 2f, globals.GROUNDZSIZE);
            westWall.GetComponent<Transform>().position = new Vector3(globals.GROUNDXSIZE / 2f, globals.WALLHEIGHT / 4f - .5f, 0);
            westWall.GetComponent<Transform>().localScale = new Vector3(.5f, globals.WALLHEIGHT / 2f, globals.GROUNDZSIZE);
        }
    }
}
