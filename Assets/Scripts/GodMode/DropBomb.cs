using UnityEngine;
using System.Collections;

public class DropBomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            dropBomb(.1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            dropBomb(.2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            dropBomb(.4f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            dropBomb(.8f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            dropBomb(1.6f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            dropBomb(3.2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            dropBomb(6.4f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            dropBomb(12.8f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            dropBomb(25.6f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            dropBomb(100);
        }
    }

    void dropBomb(float scale)
    {
        float force = 20000 * Mathf.Pow(scale,3);
        float radius = 100 * scale;
        GameObject bomb = Instantiate(Resources.Load("Nuclear Bomb/Prefabs/NuclearBomb", typeof(GameObject)), Camera.main.transform.position + transform.forward * (scale + 1), Quaternion.identity) as GameObject;
        bomb.transform.Rotate(new Vector3(0, 0, -90));
        bomb.transform.localScale = new Vector3(scale, scale, scale);
        bomb.GetComponent<Explode>().force = force;
        bomb.GetComponent<Explode>().radius = radius;

    }
}
