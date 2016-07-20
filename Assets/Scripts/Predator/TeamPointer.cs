using UnityEngine;
using System.Collections;

public class TeamPointer : MonoBehaviour {

    private TeamController teamController;
    public TeamController TeamController
    {
        get{ return teamController; }
        set
        {
            teamController = value;
            GetComponent<MeshRenderer>().material.color = value.teamColor;
        }
    }


	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
