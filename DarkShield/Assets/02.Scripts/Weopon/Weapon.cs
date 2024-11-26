using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage;
    public float normalAttackInterval;
    public float skillAttackInterval;
    public bool isAttack;

    public abstract bool CanNormalAttack();
    public abstract bool CanSkillAttack();
}
