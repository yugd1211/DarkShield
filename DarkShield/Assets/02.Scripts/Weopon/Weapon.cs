using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	public float damage;
	public float slashAttackInterval;
	public float skillAttackInterval;

	public abstract void SlashAttack();
	public abstract void SkillAttack();
}
