using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAI : MonoBehaviour
{

    [Header("Components")]
    public NavMeshAgent agent;
    public RaycastHit2D hit;
    public Transform player;

    [Header("Movement")]
    public float maxDistance;
    private Vector2 patrolPosition;
    public Transform ParentTransform;
    // Specific coordinates of the empty object
    private float range = 0.5f;


    [Header("Behaviour")]
    [NonSerialized]
    public int currentBehaviourStateIndex;
    public int startBehaviour;
    public float AiInter;
    private bool justSwitchedBehaviour;
    private int previousBehaviourStateIndex;
    
    private bool isPaused = false;

    [SerializeField]
    private float pauseTimer = 0f;

    private float pauseDuration = 1.5f;

    private GameObject titanWayPoint;


    
    private void Awake()
    {

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        currentBehaviourStateIndex = startBehaviour;

        
    }

    private void Update()
    {
        InvokeRepeating("AiInterval", 0f, AiInter);
    }

    public virtual void AiInterval() { }

    protected bool OnDetect()
    {
        bool detected;
        
        hit = Physics2D.Raycast(transform.position, player.position - transform.position, maxDistance);
        // Move to Titan behaviour.
        if (hit.collider != null && hit.collider.CompareTag("MainCharacter"))
        {
            detected = true;
        }
        else
        {
            detected = false;
        }
        
        return detected;
    }
    

    protected void OnFollow()
    {
        agent.SetDestination(player.position);

    }


      protected void AIMovement()
        {

            if (!isPaused)
            {
                agent.SetDestination(patrolPosition);

                if (Vector2.Distance(transform.position, patrolPosition) < range)
                {
                    PausePatrol();
                    CalculatePatrolPosition();
                }
            }
            else
            {
                pauseTimer += Time.deltaTime;
                if (pauseTimer >= pauseDuration)
                {
                    ResumePatrol();
                }
            }
        }
      

    public void SetBehaviourState(int state)
    {
        previousBehaviourStateIndex = currentBehaviourStateIndex;

        currentBehaviourStateIndex = state;

        justSwitchedBehaviour = true;

        JustChangedBehaviour();
    }

    public virtual void JustChangedBehaviour()
    {

        justSwitchedBehaviour = false;
    }


    void CalculatePatrolPosition()
    {

        var count = 0;
        titanWayPoint = GameObject.FindGameObjectWithTag("Titan waypoint");
        while (count < 10)
        {
            patrolPosition = new Vector2(titanWayPoint.transform.position.x + UnityEngine.Random.Range(-maxDistance, maxDistance), titanWayPoint.transform.position.y
            + UnityEngine.Random.Range(-maxDistance, maxDistance));
            if (IsPositionOnNavMesh(patrolPosition))
            {
                return;
            }

            count++;
        }

    }

    public bool IsPositionOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(position, out hit, 0.1f, NavMesh.AllAreas);
    }


    void PausePatrol()
    {
        isPaused = true;
        pauseTimer = 0f;

    }


    void ResumePatrol()
    {
        isPaused = false;

    }
    
    





}
