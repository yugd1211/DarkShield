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
    //public float meleeRange = 2f;

    public float attackRange = 1;

    public float health = 800;


    public float rangedAttackRange = 10f;
    public float attackCooldown = 2f;   
    protected float lastAttackTime = 0f;

    //public float dashSpeed = 20f; // 돌진 속도
    //public float dashDuration = 0.5f; // 돌진 지속 시간
    //private bool isDashing = false; // 돌진 상태 플래그
    //private Vector3 dashDirection; // 돌진 방향

    // 원거리 공격 관련 변수
    //public GameObject projectilePrefab; // 원거리 투사체
    //public Transform firePoint; // 투사체 발사 위치
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
        /*float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < detectionRange)
        {
            if (isDashing)
                return; // 돌진 중이면 다른 행동 무시

            if (distanceToPlayer <= meleeRange)
            {
                // 플레이어를 추적
                nmAgent.isStopped = false;
                nmAgent.SetDestination(target.position);
                MeleeAttack();
            }
            else
            {
                // 근거리 범위 내에서는 멈춤
                nmAgent.isStopped = true;
            }

            // 공격 패턴 실행
            if (distanceToPlayer <= rangedAttackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPatern();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // 탐지 범위를 벗어나면 정지
            nmAgent.isStopped = true;
        }*/
        /*float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < detectionRange)
        {
            if (isDashing)
                return; // 돌진 중이면 다른 행동 무시

            if (distanceToPlayer > meleeRange)
            {
                // 플레이어를 추적
                nmAgent.isStopped = false;
                nmAgent.SetDestination(target.position);
            }
            else
            {
                // 근거리 범위 내에서는 멈춤
                nmAgent.isStopped = true;
            }
        }
        else
        {
            // 탐지 범위를 벗어나면 정지
            nmAgent.isStopped = true;
        }*/

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
    /*private void Attack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < detectionRange)
        {
            // 근거리 공격
            if (distanceToPlayer <= meleeRange)
            {
                MeleeAttack();
            }

            // 원거리 또는 돌진 공격
            if (distanceToPlayer <= rangedAttackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPatern();
                lastAttackTime = Time.time;
            }
        }
    }*/
    /*void AttackPatern()
    {

        // 일정 확률로 돌진 공격 수행
        if (Random.value > 0.5f) // 50% 확률
        {
            StartCoroutine(DashAttack());
        }
        else
        {
            PerformRangedAttack();
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
        if (isDashing) return;
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log("원거리 공격!");
            // 원거리 공격 구현 (투사체 생성 등)
            StartCoroutine(DashAttack());
            lastAttackTime = Time.time;
        }
    }*/

    /*IEnumerator DashAttack()
    {
        isDashing = true;
        dashDirection = (target.position - transform.position).normalized;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            transform.position += dashDirection * dashSpeed * Time.deltaTime;
            yield return null; // 한 프레임 대기
        }
        print("원거리 대쉬 공격 실행");
        isDashing = false;
    }*/

    /*void PerformRangedAttack()
    {
        Debug.Log("원거리 공격 실행!");

        // 투사체 생성
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = (target.position - firePoint.position).normalized * 10f; // 투사체 속도
    }*/

    public abstract void Attack();

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("돌진 공격 성공");
        }
    }*/

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
