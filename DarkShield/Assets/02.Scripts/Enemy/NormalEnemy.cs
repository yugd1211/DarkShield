using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class NormalEnemy : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    NavMeshAgent agent; // NavMeshAgent
    public float detectionRange = 15f; // 플레이어 탐지 범위
    public float attackCooldown = 2f; // 공격 쿨타임

    public float attackRange = 1f;

    protected float lastAttackTime = 0f;

    public float health = 200; //현재 채력
    public float AttackPower = 20f;//공격력

    // 근거리
    //public float meleeRange = 2f; // 근거리 공격 범위

    // 원거리
    //public float rangedAttackRange = 10f; // 원거리 공격 범위
    //public GameObject projectilePrefab; // 원거리 투사체
    //public Transform firePoint; // 투사체 발사 위치
    private Animator _animotor;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _animotor = GetComponent<Animator>();
    }

    //근거리 애너미, 원거리 애너미 클래스로 만들기
    void Update()
    {
        Move();
        Attack();
        // 1. move > move, attack 함수로 나누기
        // 2. move, attack, 추적
        // 
    }

    private void Move()
    {
        /*float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            agent.SetDestination(player.position); // 플레이어를 추적

            if (distanceToPlayer <= meleeRange)
            {
                agent.isStopped = true; // 근접 시 멈추고 공격
                MeleeAttack();
            }
            else if (distanceToPlayer <= rangedAttackRange)
            {
                agent.isStopped = true; // 원거리 공격 범위에서도 멈춤
                RangedAttack();
            }

            else
            {
                agent.isStopped = false; // 탐지 범위 내에서 플레이어를 계속 추적
            }
        }
        else
        {
            agent.isStopped = true; // 플레이어가 탐지 범위를 벗어나면 정지
        }*/
        /*float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer <= meleeRange && distanceToPlayer <= rangedAttackRange)
            {
                agent.isStopped = false; // 플레이어를 추적
                agent.SetDestination(player.position);
            }
            else
            {
                agent.isStopped = true; // 공격 범위에 들어오면 멈춤
            }
        }
        else
        {
            agent.isStopped = true; // 탐지 범위를 벗어나면 정지
        }*/

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange && distanceToPlayer > attackRange)
        {
            agent.isStopped = false;// 플레이어를 추적
            agent.SetDestination(player.position);
            _animotor.SetBool("IsMoving",true);
        }
        else
        {
            agent.isStopped = true; // 탐지 범위를 벗어나면 정지
            _animotor.SetBool("IsMoving", false);
        }
    }

    //private bool isCheckPlayer(float distanceToPlayer) => distanceToPlayer > meleeRange && distanceToPlayer > rangedAttackRange;

    // range는 필요없음
    // 왜필요없을까?
    protected bool isCheckPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown;
    }

    public abstract void Attack();

    /*private void Attack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= meleeRange)
        {
            MeleeAttack(); // 근접 공격 실행
        }
        else if (distanceToPlayer <= rangedAttackRange)
        {
            RangedAttack(); // 원거리 공격 실행
        }
    }*/

    /*void MeleeAttack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log("근거리 공격!");
            // 근거리 공격 애니메이션, 데미지 처리
            lastAttackTime = Time.time;
        }
    }*/

    /*void RangedAttack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log("원거리 공격!");
            // 원거리 공격 구현 (투사체 생성 등)
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = (player.position - firePoint.position).normalized * 10f; // 투사체 속도
            Fire fire = projectile.GetComponent<Fire>();
            fire.damage = this.AttackPower;
            lastAttackTime = Time.time;
        }
    }*/


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
