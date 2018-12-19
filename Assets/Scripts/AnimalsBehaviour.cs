using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalsBehaviour : MonoBehaviour
{

    // States machine
    public enum GuardStates
    {
        Walk,
        Stopped
    }
    public GuardStates state;
    public float catchRange = 1f;
    public Transform WayPoints;



    // Caracteristics

    public Transform target;
    private List<Transform> allPoints = new List<Transform>();

    private bool targetOn = false;
    private NavMeshAgent agent;

    Animator animator;


    // Use this for initialization
    void Start()
    {
        //FindChildrenWithTag(transform.parent, "WayPoint");
        state = GuardStates.Stopped;

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

    }

    //private void FindChildrenWithTag(Transform parent, string tagName)
    //{
    //    foreach (Transform child in parent)
    //    {
    //        if (child.tag == tagName)
    //        {
    //            allPoints.Add(child);
    //        }
    //        FindChildrenWithTag(child, tagName);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            agent.SetDestination(target.position);
        }

        if (state == GuardStates.Walk)
        {
            //animator.SetBool("isWalking", true);

            //if (agent.remainingDistance <= agent.stoppingDistance)
            //{
            //    state = GuardStates.Stopped;

            //}
        }

        else if (state == GuardStates.Stopped)
        {
            //animator.SetBool("isWalking", false);
            animator.SetBool("isEating", true);
            SelectionNewDestination();
        }
    }



    void SelectionNewDestination()
    {
        // Random index

        int indexNumber = Random.Range(0, allPoints.Count);

        // Get waypoints list


        target = allPoints[indexNumber];
        state = GuardStates.Walk;

        // Solution version courte
        // EnemyControl.target = WayPoints.GetChild(Random.Range(1, WayPoints.childCount));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WayPoint" && other.transform == target)
        {
            SelectionNewDestination();

        }

    }
}



