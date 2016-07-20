using UnityEngine;
using System.Collections;

public class TeamController {

    public int team = 0;
    public Color32 teamColor;

    public TeamController() {
        //teamColor = new Color32((byte)Random.value, (byte)Random.value, (byte)Random.value,1);
        teamColor = new Color(Random.value, Random.value, Random.value, 0);
    }
}
