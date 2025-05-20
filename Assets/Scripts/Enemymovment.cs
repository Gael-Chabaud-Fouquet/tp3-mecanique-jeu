using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemymovment : MonoBehaviour
{
    private NavMeshAgent m_Skeleton;
    private Vector3 m_TargetDestination;
    private bool m_IsIdle; //if m_IsIdle == true, the skeleton is iddle, but if m_IsIdle == false, the skeleton is moving
    private Animator animator;

    [SerializeField] private float m_WanderSpeed;
    [SerializeField] private float m_WanderRadius;
    [SerializeField] private float m_WanderDistance;

    [SerializeField] private float m_Timer;
    [SerializeField] private float m_Elapsed;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        m_Skeleton = GetComponent<NavMeshAgent>();
        m_Skeleton.speed = m_WanderSpeed;
        m_Skeleton.acceleration = 10;
        m_Skeleton.angularSpeed = 180;

        m_IsIdle = true;
        WanderDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Skeleton.hasPath && m_Skeleton.remainingDistance == 0f)
        {
            m_IsIdle = true;
            
            WanderTimer();
            WanderDestination();
        }
    }

    private void WanderDestination()
    {
        Vector3 RandomDirection = Random.insideUnitSphere * m_WanderRadius;
        RandomDirection.y = 0;
        m_TargetDestination = transform.position + RandomDirection;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(m_TargetDestination, out hit, m_WanderDistance, -1))
        {
            m_Skeleton.SetDestination(hit.position);
            m_IsIdle = false;
        }
        else
        {
            m_TargetDestination = transform.position + (Random.insideUnitSphere * m_WanderRadius * 2);
            if (NavMesh.SamplePosition (m_TargetDestination, out hit, m_WanderDistance * 2, -1)) {
                m_Skeleton.SetDestination(hit.position);
                m_IsIdle |= false;
            }
            Invoke("WanderDestination", 0.5f);
        }
    }

    private void WanderTimer()
    {
        m_Elapsed += Time.deltaTime;
        if (m_Elapsed >= m_Timer)
        {
            m_Elapsed = 0;
        }
    }
}
