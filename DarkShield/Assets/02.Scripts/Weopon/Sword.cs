using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sword : Weapon
{
    public ParticleSystem normalAttackPt;
    public ParticleSystem skillAttackPt;
    public AnimationClip attackClip;

    private float lastNormalAttackTime;
    private float lastSkillAttackTime;

    private void Start()
    {
        lastNormalAttackTime = Time.time;
        lastSkillAttackTime = Time.time;
        normalAttackInterval = attackClip.length;
        print(normalAttackInterval);
    }

    //공격이 가능한지
    public override bool CanNormalAttack()
    {
        if (Time.time >= lastNormalAttackTime && isAttack == false)
        {
            lastNormalAttackTime = normalAttackInterval + Time.time;
            StartCoroutine(NormalAttack());
            return true;
        }

        return false;
    }

    public override bool CanSkillAttack()
    {
        if (Time.time >= lastSkillAttackTime && isAttack == false)
        {
            lastSkillAttackTime = skillAttackInterval + Time.time;
            StartCoroutine(SkillAttack());
            return true;
        }

        return false;
    }

    //기본 공격
    public IEnumerator NormalAttack()
    {
        isAttack = true;
        normalAttackPt.Play();
        yield return new WaitForSeconds(normalAttackInterval);
        isAttack = false;
    }

    //스킬 공격
    private IEnumerator SkillAttack()
    {
        isAttack = true;
        skillAttackPt.Play();
        yield return new WaitForSeconds(skillAttackInterval);
        isAttack = false;
    }
}
