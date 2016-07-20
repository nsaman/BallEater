using UnityEngine;
//using System.Collections;

// singleton class that will load the config and be read by others
public class Globals {

    public int GROUNDXSIZE = 100;
    public int GROUNDZSIZE = 100;
    public int MAXFOOD = 1500;
    public int MAXENEMIES = 250;
    public int MAXTEAMS = 20;

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
                           "\t\"MAXTEAMS\": " + MAXTEAMS + "\n" +
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


        GROUNDXSIZE = int.Parse(stringGROUNDXSIZE.Substring(0, stringGROUNDXSIZE.IndexOf(",")));
        GROUNDZSIZE = int.Parse(stringGROUNDZSIZE.Substring(0, stringGROUNDZSIZE.IndexOf(",")));
        MAXFOOD = int.Parse(stringMAXFOOD.Substring(0, stringMAXFOOD.IndexOf(",")));
        MAXENEMIES = int.Parse(stringMAXENEMIES.Substring(0, stringMAXENEMIES.IndexOf(",")));
        MAXTEAMS = int.Parse(stringMAXTEAMS.Substring(0, stringMAXTEAMS.IndexOf("\n")));
    }



    // Use this for initialization
    /*void Start () {
        
    }
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
}
