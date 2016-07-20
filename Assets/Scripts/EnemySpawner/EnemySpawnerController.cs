using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerController : MonoBehaviour {

    public GameObject NPC;
    public Globals globals;
    private int enemiesSpawned;
    private List<TeamController> teams;

    // Use this for initialization
    void Start()
    {
        teams = new List<TeamController>();
        teams.Add(new TeamController());
        GameObject.Find("Player").GetComponent<TeamPointer>().TeamController = teams[0];
        globals = Globals.Instance;
        enemiesSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if (enemiesSpawned < globals.MAXENEMIES)
        {
            GameObject npc = (GameObject)Instantiate(NPC, new Vector3((Random.value * globals.GROUNDXSIZE - globals.GROUNDXSIZE / 2), Random.value * 20 + 25, (Random.value * globals.GROUNDZSIZE - globals.GROUNDZSIZE / 2) ), Quaternion.identity);
            teams.Add(new TeamController());
            enemiesSpawned++;
            if (enemiesSpawned < (globals.MAXTEAMS - 1))
                npc.GetComponent<TeamPointer>().TeamController = teams[enemiesSpawned];
            else
                npc.GetComponent<TeamPointer>().TeamController = teams[enemiesSpawned % globals.MAXTEAMS];

        }
    }
}
