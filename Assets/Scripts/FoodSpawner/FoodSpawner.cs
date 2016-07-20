using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

    public Transform food;
    private Globals globals;

    // Use this for initialization
    void Start () {
        globals = Globals.Instance;
    }

    // Update is called once per frame
    void Update ()
    {
        // if we can spawn more food, do so. Note: food size is set in FoodInit
        if (GameObject.FindGameObjectsWithTag("Food").Length < globals.MAXFOOD)
            Instantiate(food, new Vector3(Random.value * globals.GROUNDXSIZE - globals.GROUNDXSIZE/2, Random.value * 10 + 10, Random.value * globals.GROUNDZSIZE - globals.GROUNDZSIZE / 2), Quaternion.identity);
    }
}
