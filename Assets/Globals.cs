﻿using UnityEngine;
//using System.Collections;

// singleton class that will load the config and be read by others
public class Globals {

    // default settings
    public float GROUNDXSIZE = 100;
    public float GROUNDZSIZE = 100;
    public int MAXFOOD = 1500;
    public int MAXENEMIES = 250;
    public int MAXTEAMS = 20;
    public bool HASEDGEWALLS = false;
    public float WALLHEIGHT = 3;
    public bool CANSPLIT = true;
    public bool AICANSPLIT = true;
    public float SPLITSPEED = 700f;
    public float MINSPLITMASS = .9f;
    public float MINTIMESPLIT = .6f;
    public bool AISPLITONCEPERTARGET = false;
    public bool CANSWITCHWITHTEAM = true;
    public float AIMINLOOKWAIT = .5f;
    public float SPEEDMULTIPLIER = 100;
    public bool ISSHRINKING = false;
    public float SHRINKTIMETILLEND = 120;
    public float SHRINKXENDSIZE = 20;
    public float SHRINKZENDSIZE = 20;
    public float NEARCLIPPLANE = .3f;
    public float FARCLIPPLANE = 1000;

    private static Globals instance;

    private Globals() {
        LoadJson();
    }

    public static Globals Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Globals();
            }
            return instance;
        }
    }

    public void LoadJson()
    {
#if UNITY_STANDALONE
        string json;

        if (!System.IO.File.Exists("conf.json"))
        {
            string text = "{\n" +
                           "\t\"GroundXSize\": "+ GROUNDXSIZE + ",\n" +
                           "\t\"GroundZSize\": "+ GROUNDZSIZE + ",\n" +
                           "\t\"MAXFOOD\": " + MAXFOOD + ",\n" +
                           "\t\"MAXENEMIES\": " + MAXENEMIES + ",\n" +
                           "\t\"MAXTEAMS\": " + MAXTEAMS + ",\n" +
                           "\t\"HASEDGEWALLS\": " + HASEDGEWALLS + ",\n" +
                           "\t\"WALLHEIGHT\": " + WALLHEIGHT + ",\n" +
                           "\t\"CANSPLIT\": " + CANSPLIT + ",\n" +
                           "\t\"AICANSPLIT\": " + AICANSPLIT + ",\n" +
                           "\t\"MINSPLITMASS\": " + MINSPLITMASS + ",\n" +
                           "\t\"SPLITSPEED\": " + SPLITSPEED + ",\n" +
                           "\t\"MINTIMESPLIT\": " + MINTIMESPLIT + ",\n" +
                           "\t\"AISPLITONCEPERTARGET\": " + AISPLITONCEPERTARGET + ",\n" +
                           "\t\"CANSWITCHWITHTEAM\": " + CANSWITCHWITHTEAM + ",\n" +
                           "\t\"AIMINLOOKWAIT\": " + AIMINLOOKWAIT + ",\n" +
                           "\t\"SPEEDMULTIPLIER\": " + SPEEDMULTIPLIER + ",\n" +
                           "\t\"ISSHRINKING\": " + ISSHRINKING + ",\n" +
                           "\t\"SHRINKTIMETILLEND\": " + SHRINKTIMETILLEND + ",\n" +
                           "\t\"SHRINKXENDSIZE\": " + SHRINKXENDSIZE + ",\n" +
                           "\t\"SHRINKZENDSIZE\": " + SHRINKZENDSIZE + ",\n" +
                           "\t\"NEARCLIPPLANE\": " + NEARCLIPPLANE + ",\n" +
                           "\t\"FARCLIPPLANE\": " + FARCLIPPLANE + "\n" +
                           "}";
            System.IO.File.WriteAllText("conf.json", text);
        }
        json = System.IO.File.ReadAllText("conf.json");

        //todo implement a real json reader solution

        /* Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(json);

        GROUNDXSIZE = (int)token.SelectToken("GROUNDXSIZE");
        GROUNDZSIZE = (int)token.SelectToken("GROUNDZSIZE");
        MAXFOOD = (int)token.SelectToken("MAXFOOD");*/

        // this is reading json files the hard way
        string stringGROUNDXSIZE = json.Substring(json.IndexOf("XSize") + 8);
        string stringGROUNDZSIZE = json.Substring(json.IndexOf("ZSize") + 8);
        string stringMAXFOOD = json.Substring(json.IndexOf("MAXFOOD") + 10);
        string stringMAXENEMIES = json.Substring(json.IndexOf("MAXENEMIES") + 13);
        string stringMAXTEAMS = json.Substring(json.IndexOf("MAXTEAMS") + 11);
        string stringHASEDGEWALLS = json.Substring(json.IndexOf("HASEDGEWALLS") + 15);
        string stringWALLHEIGHT = json.Substring(json.IndexOf("WALLHEIGHT") + 13);
        string stringCANSPLIT = json.Substring(json.IndexOf("CANSPLIT") + 11);
        string stringAICANSPLIT = json.Substring(json.IndexOf("AICANSPLIT") + 13);
        string stringSPLITSPEED = json.Substring(json.IndexOf("SPLITSPEED") + 13);
        string stringMINSPLITMASS = json.Substring(json.IndexOf("MINSPLITMASS") + 15);
        string stringMINTIMESPLIT = json.Substring(json.IndexOf("MINTIMESPLIT") + 15);
        string stringAISPLITONCEPERTARGET = json.Substring(json.IndexOf("AISPLITONCEPERTARGET") + 23);
        string stringCANSWITCHWITHTEAM = json.Substring(json.IndexOf("CANSWITCHWITHTEAM") + 20);
        string stringAIMINLOOKWAIT = json.Substring(json.IndexOf("AIMINLOOKWAIT") + 16);
        string stringSPEEDMULTIPLIER = json.Substring(json.IndexOf("SPEEDMULTIPLIER") + 18);
        string stringISSHRINKING = json.Substring(json.IndexOf("ISSHRINKING") + 14);
        string stringSHRINKTIMETILLEND = json.Substring(json.IndexOf("SHRINKTIMETILLEND") + 20);
        string stringSHRINKXENDSIZE = json.Substring(json.IndexOf("SHRINKXENDSIZE") + 17);
        string stringSHRINKZENDSIZE = json.Substring(json.IndexOf("SHRINKZENDSIZE") + 17);
        string stringNEARCLIPPLANE = json.Substring(json.IndexOf("NEARCLIPPLANE") + 16);
        string stringFARCLIPPLANE = json.Substring(json.IndexOf("FARCLIPPLANE") + 15);


        GROUNDXSIZE = float.Parse(stringGROUNDXSIZE.Substring(0, stringGROUNDXSIZE.IndexOf(",")));
        GROUNDZSIZE = float.Parse(stringGROUNDZSIZE.Substring(0, stringGROUNDZSIZE.IndexOf(",")));
        MAXFOOD = int.Parse(stringMAXFOOD.Substring(0, stringMAXFOOD.IndexOf(",")));
        MAXENEMIES = int.Parse(stringMAXENEMIES.Substring(0, stringMAXENEMIES.IndexOf(",")));
        MAXTEAMS = int.Parse(stringMAXTEAMS.Substring(0, stringMAXTEAMS.IndexOf(",")));
        HASEDGEWALLS = bool.Parse(stringHASEDGEWALLS.Substring(0, stringHASEDGEWALLS.IndexOf(",")));
        WALLHEIGHT = float.Parse(stringWALLHEIGHT.Substring(0, stringWALLHEIGHT.IndexOf(",")));
        CANSPLIT = bool.Parse(stringCANSPLIT.Substring(0, stringCANSPLIT.IndexOf(",")));
        AICANSPLIT = bool.Parse(stringAICANSPLIT.Substring(0, stringAICANSPLIT.IndexOf(",")));
        SPLITSPEED = float.Parse(stringSPLITSPEED.Substring(0, stringSPLITSPEED.IndexOf(",")));
        MINSPLITMASS = float.Parse(stringMINSPLITMASS.Substring(0, stringMINSPLITMASS.IndexOf(",")));
        MINTIMESPLIT = float.Parse(stringMINTIMESPLIT.Substring(0, stringMINTIMESPLIT.IndexOf(",")));
        AISPLITONCEPERTARGET = bool.Parse(stringAISPLITONCEPERTARGET.Substring(0, stringAISPLITONCEPERTARGET.IndexOf(",")));
        CANSWITCHWITHTEAM = bool.Parse(stringCANSWITCHWITHTEAM.Substring(0, stringCANSWITCHWITHTEAM.IndexOf(",")));
        AIMINLOOKWAIT = float.Parse(stringAIMINLOOKWAIT.Substring(0, stringAIMINLOOKWAIT.IndexOf(",")));
        SPEEDMULTIPLIER = float.Parse(stringSPEEDMULTIPLIER.Substring(0, stringSPEEDMULTIPLIER.IndexOf(",")));
        ISSHRINKING = bool.Parse(stringISSHRINKING.Substring(0, stringISSHRINKING.IndexOf(",")));
        SHRINKTIMETILLEND = float.Parse(stringSHRINKTIMETILLEND.Substring(0, stringSHRINKTIMETILLEND.IndexOf(",")));
        SHRINKXENDSIZE = float.Parse(stringSHRINKXENDSIZE.Substring(0, stringSHRINKXENDSIZE.IndexOf(",")));
        SHRINKZENDSIZE = float.Parse(stringSHRINKZENDSIZE.Substring(0, stringSHRINKZENDSIZE.IndexOf(",")));
        NEARCLIPPLANE = float.Parse(stringNEARCLIPPLANE.Substring(0, stringNEARCLIPPLANE.IndexOf(",")));
        FARCLIPPLANE = float.Parse(stringFARCLIPPLANE.Substring(0, stringFARCLIPPLANE.IndexOf("\n")));
#endif
    }



    // Use this for initialization
    /*void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
