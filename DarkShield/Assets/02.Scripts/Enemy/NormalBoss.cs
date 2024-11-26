using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public abstract class NormalBoss : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nmAgent;
    public float detectionRange = 15f;

    public float attackRange = 1;

    public float health = 800;


    public float rangedAttackRange = 10f;
    public float attackCooldown = 2f;   
    protected float lastAttackTime = 0f;
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer <= detectionRange && distanceToPlayer > attackRange)
        {
            nmAgent.isStopped = false;// 플레이어를 추적
            nmAgent.SetDestination(target.position);
        }
        else
        {
            nmAgent.isStopped = true; // 탐지 범위를 벗어나면 정지
        }
    }

    public abstract void Attack();

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
