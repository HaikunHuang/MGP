// haikun huang
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour 
{
	Animator anim;

	// hash values
	float fade_time = 0.1f;
	
	int hash_Idle = Animator.StringToHash("Idle");
	int hash_Run = Animator.StringToHash("Run");
	int hash_Walk = Animator.StringToHash("Walk");
	int hash_VictoryPose = Animator.StringToHash("Victory Pose");
	int hash_Hurt = Animator.StringToHash("Hurt");
	int hash_Die = Animator.StringToHash("Die");
	int hash_Attack0 = Animator.StringToHash("Attack 0"); // primary attack
	int hash_Attack1 = Animator.StringToHash("Attack 1"); // skill attack
	int hash_PowerAttack = Animator.StringToHash("Power Attack");


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}



	public bool Is_Idle()
	{
		if (anim && !Is_Die())
		{
			return anim.GetCurrentAnimatorStateInfo(0).IsName("Idle");
		}
		return false;
	}

	public bool Is_Die()
	{
		if (anim)
		{
			return anim.GetCurrentAnimatorStateInfo(0).IsName("Die");
		}
		return false;
	}
	
	public void ReStart()
	{
		if (anim)
		{
			anim.CrossFade(hash_Idle,fade_time);
		}
	}

	public void Idle()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_Idle,fade_time);
		}
	}
	
	public void Walk()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_Walk,fade_time);
		}
	}
	
	public void Run()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_Run,fade_time);
		}
	}

	public void Attack_0()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_Attack0,fade_time);
		}
	}

	public void Attack_1()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_Attack1,fade_time);
		}
	}

	public void Power_Attack()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_PowerAttack,fade_time);
		}
	}

	public void Victory_Pose()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_VictoryPose,fade_time);
		}
	}

	// only idle state can be hurt, otherwise not.
	public void Hurt()
	{
		if (anim && Is_Idle())
		{
			anim.CrossFade(hash_Hurt,fade_time);
		}
	}

	public void Die()
	{
		if (anim && !Is_Die())
		{
			anim.CrossFade(hash_Die,fade_time);
		}
	}
	
}
