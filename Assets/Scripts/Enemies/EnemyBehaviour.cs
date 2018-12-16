using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{

    // States machine
    public enum GuardStates
    {
        Walk,
        Follow,
        Stopped,
    }
    public GuardStates state;
    public float catchRange = 1f;
    public Transform WayPoints;

 

    // Caracteristics
    GameObject player;
    public float enemyHP;
    public float enemyMP;
    public float enemyDefense;
    public float enemyForce;
    public float enemyDetection = 2f;
    public float searchTime = 10.0f;
    public float currentSearchTime;
    public float distancePlayer;
    public float distanceAttack = 1f;

    public string enemyName;
    public Transform target;
    private List<Transform> allPoints = new List<Transform>();

    private bool targetOn = false;
    private NavMeshAgent agent;

    Animator animator;


    // Use this for initialization
    void Start()
    {
        FindChildrenWithTag(transform.parent, "WayPoint");
        state = GuardStates.Stopped;

        player = GameObject.FindGameObjectWithTag("Player");
        currentSearchTime = searchTime;

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

    }

    private void FindChildrenWithTag(Transform  parent, string tagName)
    {
        foreach(Transform child in parent)
        {
            if(child.tag == tagName)
            {
                allPoints.Add(child);
            }
            FindChildrenWithTag(child, tagName);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Check the player position to follow or attack him
        distancePlayer = Vector3.Distance(player.transform.position, transform.position);

        checkIfPlayerIsHere();
        if (targetOn)
        {
            followPlayer();
            if (distanceAttack >= distancePlayer)
            {
                attackPlayer();
            }
        }

      


        // To change WayPoints
        
        else if (state == GuardStates.Stopped)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            SelectionNewDestination();
        }

        if (target != null)
        {
            agent.SetDestination(target.position);
        }

        if (state == GuardStates.Walk)
        {
            animator.SetBool("isWalking", true);
            
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                state = GuardStates.Stopped;
            }
        }

       

    }

    public virtual void attackPlayer()
    {
        // This method is overided in a child class
        Debug.Log("The ennemy attacks the player", gameObject);
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", true);
    }


    // Way to check the player position : distance < radius - initialization of searchtime
    public void checkIfPlayerIsHere()
    {
        if (distancePlayer < enemyDetection)
        {
            currentSearchTime = searchTime;
            targetOn = true;
            print("Enemy is seeing Player");
        }
    }

    // Stop hunting player
    public void stopFollowPlayer()
    {
        targetOn = false;
        state = GuardStates.Stopped ;
    }
    // Follow the player
    public void followPlayer()
    {
        state = GuardStates.Follow;
        target = player.transform ;
        animator.SetBool("isWalking", true);

        if (distancePlayer >= enemyDetection)
        {
            currentSearchTime -= Time.deltaTime;

            if (currentSearchTime <= 0)
            {
                stopFollowPlayer();

            }

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

    // To change gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyDetection);
    }


}
