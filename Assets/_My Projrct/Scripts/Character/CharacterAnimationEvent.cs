// haikun huang
/*
 * responsibility to handle the animation events. 
 * 
 * 
 */ 
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CharacterAnimationEvent : MonoBehaviour 
{

	public AudioClip audio_footStep;
	public AudioClip audio_attack_0, audio_attack_1, audio_power_attack;
	public AudioClip audio_hurt, audio_victory_pose, audio_die;


	AudioSource audio;


	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/////////////////////////////////////////////////////////
	//////////////////////// Sound //////////////////////////
	/////////////////////////////////////////////////////////

	void AnimEvent_FootStep()
	{
		if (audio_footStep)
		{
			audio.PlayOneShot(audio_footStep);
		}
	}

	void AnimEvent_AttackSound_0()
	{
		if (audio_attack_0)
		{
			audio.PlayOneShot(audio_attack_0);
		}
	}

	void AnimEvent_AttackSound_1()
	{
		if (audio_attack_1)
		{
			audio.PlayOneShot(audio_attack_1);
		}
	}

	void AnimEvent_Power_AttackSound()
	{
		if (audio_power_attack)
		{
			audio.PlayOneShot(audio_power_attack);
		}
	}

	void AnimEvent_HurtSound()
	{
		if (audio_hurt)
		{
			audio.PlayOneShot(audio_hurt);
		}
	}

	void AnimEvent_DieSound()
	{
		if (audio_die)
		{
			audio.PlayOneShot(audio_die);
		}
	}

	void AnimEvent_Victory_PoseSound()
	{
		if (audio_victory_pose)
		{
			audio.PlayOneShot(audio_victory_pose);
		}
	}
}
