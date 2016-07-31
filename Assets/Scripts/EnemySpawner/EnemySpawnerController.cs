using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerController : MonoBehaviour
{

    public GameObject NPC;
    private Globals globals;
    private int enemiesSpawned;
    private List<TeamController> teams;

    // Use this for initialization
    void Start()
    {
        globals = Globals.Instance;
        enemiesSpawned = 0;
        teams = new List<TeamController>();

        teams.Add(new TeamController());

        // add a team for the player
        if (GameObject.Find("Player") != null)
        {
            GameObject.Find("Player").GetComponent<TeamPointer>().TeamController = teams[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned < globals.MAXENEMIES)
        {
            // spawn a npc in the playing area
            GameObject npc = (GameObject)Instantiate(NPC, new Vector3((Random.value * globals.GROUNDXSIZE - globals.GROUNDXSIZE / 2), Random.value * 20 + 25, (Random.value * globals.GROUNDZSIZE - globals.GROUNDZSIZE / 2)), Quaternion.identity);
            enemiesSpawned++;

            // if we haven't reachead max teams (player needs to be accounted for)
            if (enemiesSpawned < globals.MAXTEAMS)
            {
                teams.Add(new TeamController());
                npc.GetComponent<TeamPointer>().TeamController = teams[enemiesSpawned];
            }
            else
                npc.GetComponent<TeamPointer>().TeamController = teams[enemiesSpawned % globals.MAXTEAMS];
        }
    }
}
