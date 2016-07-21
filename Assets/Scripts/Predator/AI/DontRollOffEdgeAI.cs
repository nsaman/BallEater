using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DontRollOffEdgeAI : MonoBehaviour
{

    private Rigidbody rb;
    private static float speed = 100;
    private bool canJump;
    private GameObject currentTarget;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
        currentTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentTarget = findClosestFood();

        if (currentTarget != null)
        {
            Vector3 toFoodDirection = new Vector3(currentTarget.transform.position.x - transform.position.x, 0,
                 currentTarget.transform.position.z - transform.position.z);
            if (toFoodDirection.sqrMagnitude > 1)
            {
                toFoodDirection = toFoodDirection.normalized;
            }

            // stop ai from rolling off the edge and orbitting food (don't jump off the edge for food!)
            GameObject ground = (GameObject)GameObject.FindGameObjectsWithTag("Ground")[0];
            // if close to falling off either x edge
            Vector3 projectedPosition = (rb.velocity * 2 + transform.position);
            if (projectedPosition.x > ground.transform.localScale.x * 5)
                toFoodDirection.x = -toFoodDirection.x;
            else if (projectedPosition.x > currentTarget.transform.position.x)
                toFoodDirection.x = -toFoodDirection.x;
            else if (projectedPosition.x < -ground.transform.localScale.x * 5)
                toFoodDirection.x = -toFoodDirection.x;
            else if (projectedPosition.x < currentTarget.transform.position.x)
                toFoodDirection.x = -toFoodDirection.x;
            // also check z edge
            if (projectedPosition.z > ground.transform.localScale.z * 5)
                toFoodDirection.z = -toFoodDirection.z;
            else if (projectedPosition.z > currentTarget.transform.position.z)
                toFoodDirection.z = -toFoodDirection.z;
            else if (projectedPosition.z < -ground.transform.localScale.z* 5)
                toFoodDirection.z = -toFoodDirection.z;
            else if (projectedPosition.z < currentTarget.transform.position.z)
                toFoodDirection.z = -toFoodDirection.z;


            //todo add jump logic

            rb.AddForce(toFoodDirection * speed * Time.deltaTime * (rb.mass + 1) / 1.08f);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    GameObject findClosestFood()
    {
        GameObject closestEdibleFood = null;
        float closestEdibleFoodDistance = 99999999;

        // get list of available foods
        List<GameObject> foods = new List<GameObject>(GameObject.FindGameObjectsWithTag("Food"));
        List<GameObject> edibles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Edible"));

        // friends aren't food!
        for (int i = edibles.Count - 1; i >= 0; i--)
        {
            TeamController foodTC = edibles[i].GetComponent<TeamPointer>().TeamController;
            TeamController thisTC = GetComponent<TeamPointer>().TeamController;
            if (edibles[i].GetComponent<TeamPointer>().TeamController == GetComponent<TeamPointer>().TeamController)
                edibles.RemoveAt(i);
            foodTC = thisTC;
        }

        foods.AddRange(edibles);

        // get rid of self
        foods.Remove(gameObject);

        // then find the closest that we can eat
        foreach (GameObject food in foods)
        {

            // check if it is small enough to eat
            if (rb.mass > food.GetComponent<Rigidbody>().mass)
            {
                // check if it is the closest edible thing
                float currentFoodDistance = Vector3.Distance(food.transform.position, transform.position);
                if (currentFoodDistance < closestEdibleFoodDistance)
                {
                    closestEdibleFood = food;
                    closestEdibleFoodDistance = currentFoodDistance;
                }
            }
        }

        return closestEdibleFood;
    }
}

