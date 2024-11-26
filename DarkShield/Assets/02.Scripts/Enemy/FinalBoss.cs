using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FinalBoss : MonoBehaviour
{
    public Transform target; //플레이어 위치
    NavMeshAgent nmAgent; //navmeshagent
    public float detectionRange = 15f;//플레이어 탐지 범위
    public float meleeRange = 2f;//근거리 공격 범위

    public float health = 1000;//현재 채력
    public float AttackPower = 20f;//공격력


    public float rangedAttackRange = 10f; //원거리 공격 범위
    public float attackCooldown = 2f;//공격 쿨타임
    private float lastAttackTime = 0f;

    public float dashSpeed = 20f; // 돌진 속도
    public float dashDuration = 0.5f; // 돌진 지속 시간
    private bool isDashing = false; // 돌진 상태 플래그
    private Vector3 dashDirection; // 돌진 방향

    // 원거리 공격 관련 변수
    public GameObject projectilePrefab; // 원거리 투사체
    public Transform firePoint; // 투사체 발사 위치

    // 원거리 공격 변수2
    public GameObject projectileprfab2; //원거리 투사체2
    public Transform firepoint2;//투사체 발사 위치2
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Move();

    }

    void Move()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < detectionRange) // 탐지 범위 확인
        {
            if (isDashing)
                return; // 돌진 중이면 다른 행동 무시

            if (distanceToPlayer <= meleeRange) //근접 공격 범위내일떄
            {
                nmAgent.isStopped = false;
                nmAgent.SetDestination(target.position);
                MeleeAttack();
            }
            else
            {
                nmAgent.isStopped = true;
            }

            // 원거리 공격 패턴 실행
            if (distanceToPlayer <= rangedAttackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPattern();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // 탐지 범위를 벗어나면 정지
            nmAgent.isStopped = true;
        }
    }

    void AttackPattern() // 공격 패턴 함수
    {
        float randomValue = Random.value;

        if (randomValue > 0.2f) // 40% 확률
        {
            StartCoroutine(DashAttack());
        }
        else if (randomValue > 0.5f) // 30% 확률
        {
            PerformRangedAttack();
        }
        else // 나머지 30% 확률
        {
            SpecialRangedAttack();
        }
    }

    void MeleeAttack() //근거리 공격 메서드
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log("근거리 공격!");
            // 근거리 공격 애니메이션, 데미지 처리
            lastAttackTime = Time.time;
        }
    }


    IEnumerator DashAttack() //대쉬 공격 메서드
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
    }

    void PerformRangedAttack() //원거리 투사체 공격 메서드
    {
        Debug.Log("원거리 공격 실행!");

        // 투사체 생성
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = (target.position - firePoint.position).normalized * 10f; // 투사체 속도;
        Fire fire = projectile.GetComponent<Fire>();
        fire.damage = this.AttackPower;
        
    }


    void SpecialRangedAttack() //강력한 원거리 투사체 공격 메서드
    {
        print("강력한 원거리 공격 실행");
        GameObject projectile2 = Instantiate(projectileprfab2, firepoint2.position, firepoint2.rotation);
        Rigidbody rb2 = projectile2.GetComponent<Rigidbody>();
        rb2.velocity = (target.position - firepoint2.position).normalized * 10f; // 투사체 속도
        FinalSkill finalskill = projectile2.GetComponent<FinalSkill>();
        finalskill.damage = this.AttackPower;  

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("돌진 공격 성공");
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    
}
