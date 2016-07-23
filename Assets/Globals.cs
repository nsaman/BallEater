﻿using UnityEngine;
//using System.Collections;

// singleton class that will load the config and be read by others
public class Globals {

    // default settings
    public int GROUNDXSIZE = 100;
    public int GROUNDZSIZE = 100;
    public int MAXFOOD = 1500;
    public int MAXENEMIES = 250;
    public int MAXTEAMS = 20;
    public bool HASEDGEWALLS = false;
    public int WALLHEIGHT = 1;
    public bool CANSPLIT = true;
    public bool AICANSPLIT = true;
    public float SPLITSPEED = 700f;
    public float MINSPLITMASS = .9f;
    public float MINTIMESPLIT = .5f;
    public bool AISPLITONCEPERTARGET = false;

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
                           "\t\"AISPLITONCEPERTARGET\": " + AISPLITONCEPERTARGET + "\n" +
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


        GROUNDXSIZE = int.Parse(stringGROUNDXSIZE.Substring(0, stringGROUNDXSIZE.IndexOf(",")));
        GROUNDZSIZE = int.Parse(stringGROUNDZSIZE.Substring(0, stringGROUNDZSIZE.IndexOf(",")));
        MAXFOOD = int.Parse(stringMAXFOOD.Substring(0, stringMAXFOOD.IndexOf(",")));
        MAXENEMIES = int.Parse(stringMAXENEMIES.Substring(0, stringMAXENEMIES.IndexOf(",")));
        MAXTEAMS = int.Parse(stringMAXTEAMS.Substring(0, stringMAXTEAMS.IndexOf(",")));
        HASEDGEWALLS = bool.Parse(stringHASEDGEWALLS.Substring(0, stringHASEDGEWALLS.IndexOf(",")));
        WALLHEIGHT = int.Parse(stringWALLHEIGHT.Substring(0, stringWALLHEIGHT.IndexOf(",")));
        CANSPLIT = bool.Parse(stringCANSPLIT.Substring(0, stringCANSPLIT.IndexOf(",")));
        AICANSPLIT = bool.Parse(stringAICANSPLIT.Substring(0, stringAICANSPLIT.IndexOf(",")));
        SPLITSPEED = float.Parse(stringSPLITSPEED.Substring(0, stringSPLITSPEED.IndexOf(",")));
        MINSPLITMASS = float.Parse(stringMINSPLITMASS.Substring(0, stringMINSPLITMASS.IndexOf(",")));
        MINTIMESPLIT = float.Parse(stringMINTIMESPLIT.Substring(0, stringMINTIMESPLIT.IndexOf(",")));
        AISPLITONCEPERTARGET = bool.Parse(stringAISPLITONCEPERTARGET.Substring(0, stringAISPLITONCEPERTARGET.IndexOf("\n")));
    }



    // Use this for initialization
    /*void Start () {
        
    }
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
}
