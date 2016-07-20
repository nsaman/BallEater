using UnityEngine;
using System.Collections;

public class TeamController {

    public int team = 0;
    public Color32 teamColor;

    // on initialize, get a random team color
    public TeamController() {
        teamColor = new Color(Random.value, Random.value, Random.value, 0);
    }
}
