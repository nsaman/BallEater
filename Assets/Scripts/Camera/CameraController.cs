using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject ball;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    void LateUpdate()
    {
        transform.position = ball.transform.position + offset * (1 + Mathf.Sqrt(ball.GetComponent<Rigidbody>().mass)/20);
    }
}