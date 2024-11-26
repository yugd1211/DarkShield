using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSkill : MonoBehaviour
{
    public float damage = 40f; // 기본 데미지

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("플레이어가 원거리 공격에 맞음!");

            Destroy(gameObject); // 투사체 제거
        }
    }
}
