﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AINoOrbit : MonoBehaviour {

    private Rigidbody rb;
    private bool canJump;
    private GameObject currentTarget;
    private GameObject splitTarget;
    private Globals globals;
    // only split if we get a new target
    private bool newSplitTarget;
    private float timeSinceLastSplit;
    private float timeSinceLastFoodSearch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
        currentTarget = null;
        splitTarget = null;
        globals = Globals.Instance;
        newSplitTarget = false;
        timeSinceLastSplit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // should this be on a seperate thread? tried can't do some unity stuff on non-main thread
        timeSinceLastFoodSearch += Time.deltaTime;
        if (timeSinceLastFoodSearch > globals.AIMINLOOKWAIT)
        {
            LookThroughFood();
            timeSinceLastFoodSearch = 0;
        }
        if (globals.AICANSPLIT && newSplitTarget && splitTarget != null && timeSinceLastSplit >= globals.MINTIMESPLIT)
        {
            GetComponent<Split>().DoSplit(splitTarget.transform.position - GetComponent<Transform>().position);
            if (globals.AISPLITONCEPERTARGET)
                newSplitTarget = false;
            timeSinceLastSplit = 0;
        }
        if (currentTarget != null)
        {
            // there has to be a smarter way to deal with this mess
            Vector3 toFoodDirection = new Vector3(currentTarget.transform.position.x - transform.position.x, 0, currentTarget.transform.position.z - transform.position.z);

            if (toFoodDirection.sqrMagnitude > 1)
            {
                toFoodDirection = toFoodDirection.normalized;
            }

            Vector3 velocityRBNoY;
            if (rb.velocity.magnitude > 1)
            {
                velocityRBNoY = rb.velocity;
                velocityRBNoY.y = 0;
            }
            else
            {
                velocityRBNoY = new Vector3(0, 0, 0);
            }
            
            Vector3 correctedDirection = (toFoodDirection - velocityRBNoY.normalized * .9f).normalized;
            
            if (correctedDirection.magnitude > .9f)
                rb.AddForce(correctedDirection * globals.SPEEDMULTIPLIER * Time.deltaTime * (rb.mass + 1));
            else
                rb.AddForce(toFoodDirection * globals.SPEEDMULTIPLIER * Time.deltaTime * (rb.mass + 1));
        }

        timeSinceLastSplit += Time.deltaTime;

    }

    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    void LookThroughFood()
    {
        GameObject closestEdibleFood = null;
        float closestEdibleFoodDistance = 99999999;
        GameObject closestSplitTarget = null;
        float closestSplitTargetDistance = 99999999;
        Transform thisTransform = GetComponent<Transform>();
        Vector3 posWithVelocity = rb.velocity * .75f + thisTransform.position;
        float maxShootRange = thisTransform.localScale.x * 3;

        // get list of available foods
        List<GameObject> foods = new List<GameObject>(GameObject.FindGameObjectsWithTag("Food"));
        List<GameObject> edibles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Edible"));

        // friends aren't food!
        for (int i = edibles.Count - 1; i >= 0; i--)
        {
            if (edibles[i].GetComponent<TeamPointer>().TeamController == GetComponent<TeamPointer>().TeamController)
                edibles.RemoveAt(i);
        }

        // get rid of self
        edibles.Remove(gameObject);

        // todo review below loops code reuse

        // first look through enemies looking for potential food targets and split targets
        foreach (GameObject edible in edibles)
        {
            Rigidbody edibleRB = edible.GetComponent<Rigidbody>();

            // check if it is small enough to eat and also that it isn't too high to eat
            if (edibleRB != null && rb.mass > edibleRB.mass)
            {
                // check if it is the closest edible thing
                float currentFoodDistance = Vector3.Distance(edible.transform.position, thisTransform.position);
                if (currentFoodDistance < closestEdibleFoodDistance)
                {
                    closestEdibleFood = edible;
                    closestEdibleFoodDistance = currentFoodDistance;

                    if (globals.CANSPLIT &&
                        currentFoodDistance < closestSplitTargetDistance &&
                        rb.mass > edibleRB.mass * 2 &&
                        // this should probably be used to check target distance - distance to target after .75 sec
                        // if after .75 seconds we are within 3 diameters, shoot!
                        maxShootRange > (posWithVelocity - edible.transform.position).magnitude)
                    {
                        closestSplitTarget = edible;
                        closestSplitTargetDistance = currentFoodDistance;
                    }
                }
            }
        }

        float thisHeight = thisTransform.localScale.y + thisTransform.position.y;

        // then look through food
        foreach (GameObject food in foods)
        {
            Rigidbody foodRB = food.GetComponent<Rigidbody>();

            // check if it is small enough to eat
            if (foodRB != null && rb.mass > foodRB.mass && food.transform.position.y < thisHeight)
            {
                // check if it is the closest edible thing
                float currentFoodDistance = Vector3.Distance(food.transform.position, thisTransform.position);
                if (currentFoodDistance < closestEdibleFoodDistance)
                {
                    closestEdibleFood = food;
                    closestEdibleFoodDistance = currentFoodDistance;
                }
            }
        }

        this.currentTarget = closestEdibleFood;

        if (closestSplitTarget != this.splitTarget)
        {
            newSplitTarget = true;
            this.splitTarget = closestSplitTarget;
        }
    }
}