using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;
    public GameObject player;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Edible");
        float biggestBall = 0;
        foreach(GameObject ball in balls)
        {
            if (ball != player)
            {
                if (ball.GetComponent<Rigidbody>().mass > biggestBall)
                    biggestBall = ball.GetComponent<Rigidbody>().mass;
            }
        }
        string text = string.Format("{0:0.0} ms ({1:0.} fps)\nFood: " + GameObject.FindGameObjectsWithTag("Food").Length + "\n" + "Enimies: " + (balls.Length - 1) + "\nYour Mass: " + player.GetComponent<Rigidbody>().mass + "\nTop enemy mass: " + biggestBall, msec, fps);
        GUI.Label(rect, text, style);
    }
}