using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : NormalEnemy
{
    // 원거리
    //public float rangedAttackRange = 10f; // 원거리 공격 범위
    // 나도 필요없음 왜필요없을까?

    public GameObject projectilePrefab; // 원거리 투사체
    public Transform firePoint; // 투사체 발사 위치

    private Animator _animator;

    private void Awake()
    {
        attackRange = 10f;
        _animator = GetComponent<Animator>();
    }

    public override void Attack()
    {
        /*float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= rangedAttackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            RangedAttack();
            lastAttackTime = Time.time;
        }*/
        if(isCheckPlayer())
        {
            RangedAttack();
            _animator.SetBool("IsRangeAttack", true);
            lastAttackTime = Time.time;
            StartCoroutine(ResetAttackAnimation());
        }
    }

    private void RangedAttack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = (player.position - firePoint.position).normalized * 10f; // 투사체 속도
            Fire fire = projectile.GetComponent<Fire>();
            fire.damage = this.AttackPower;
            lastAttackTime = Time.time;
        }
    }

    private IEnumerator ResetAttackAnimation()
    {
        // 공격 애니메이션이 끝나는 데 걸리는 시간 (애니메이션 길이에 맞게 설정)
        yield return new WaitForSeconds(1.0f);

        // 공격 애니메이션 종료
        _animator.SetBool("IsRangeAttack", false);
    }


}
