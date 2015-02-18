using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterAnimationController))]
[RequireComponent(typeof(CharacterAnimationEvent))]
public class Character_Model : MonoBehaviour 
{
	public CharacterAnimationController cac {get;set;}
	public CharacterAnimationEvent cae {get;set;}

	// player camera position,
	public Transform player_camera_trans;

	void Awake () 
	{
		cac = GetComponent<CharacterAnimationController>();
		cae = GetComponent<CharacterAnimationEvent>();
	}


}
