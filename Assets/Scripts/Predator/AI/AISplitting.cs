using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISplitting : MonoBehaviour
{

    private Rigidbody rb;
    private static float speed = 100;
    private bool canJump;
    private GameObject currentTarget;
    private GameObject splitTarget;
    private Globals globals;
    // only split if we get a new target
    private bool newSplitTarget;
    public float timeSinceLastSplit;

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
        // should this be on a seperate thread?
        LookThroughFood();

        if (currentTarget != null)
        {
            Vector3 toFoodDirection = new Vector3(currentTarget.transform.position.x - transform.position.x, 0,
                 currentTarget.transform.position.z - transform.position.z);
            if (toFoodDirection.sqrMagnitude > 1)
            {
                toFoodDirection = toFoodDirection.normalized;
            }

            //todo add jump logic

            rb.AddForce(toFoodDirection * speed * Time.deltaTime * (rb.mass + 1) / 1.08f);
        }
        timeSinceLastSplit += Time.deltaTime;
        if (globals.AICANSPLIT && newSplitTarget && splitTarget != null && timeSinceLastSplit >= globals.MINTIMESPLIT)
        {
            GetComponent<Split>().DoSplit(splitTarget.transform.position - GetComponent<Transform>().position);
            if (globals.AISPLITONCEPERTARGET)
                newSplitTarget = false;
            timeSinceLastSplit = 0;
        }
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
            // check if it is small enough to eat
            if (rb.mass > edible.GetComponent<Rigidbody>().mass)
            {
                // check if it is the closest edible thing
                float currentFoodDistance = Vector3.Distance(edible.transform.position, transform.position);
                if (currentFoodDistance < closestEdibleFoodDistance)
                {
                    closestEdibleFood = edible;
                    closestEdibleFoodDistance = currentFoodDistance;
                }
                if (globals.CANSPLIT &&
                    currentFoodDistance < closestSplitTargetDistance && 
                    rb.mass > edible.GetComponent<Rigidbody>().mass * 2 &&
                    // this should probably be used to check target distance - distance to target after .75 sec
                    // if after .75 seconds we are within 3 diameters, shoot!
                    GetComponent<Transform>().localScale.x * 3 > (rb.velocity * .75f + GetComponent<Transform>().position - edible.transform.position).magnitude) // - edible.transform.position * 1000f * rb.mass))
                {
                    closestSplitTarget = edible;
                    closestSplitTargetDistance = currentFoodDistance;
                }
            }
        }


        // then look through food
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
        
        this.currentTarget = closestEdibleFood;

        if (closestSplitTarget != this.splitTarget)
            newSplitTarget = true;
        this.splitTarget = closestSplitTarget;


    }
}
