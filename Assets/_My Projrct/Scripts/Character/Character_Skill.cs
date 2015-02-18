// haikun huang

// this class used to hold the skill info of the character

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character_Skill : MonoBehaviour 
{

	// A list of buff and debuff and blocker
	public List<Skill> skillBuff, skillDebuff;
	public List<Skill_Blocker> skillBlocker;

	// Use this for initialization
	void Start () 
	{
		skillBuff = new List<Skill>();
		skillDebuff = new List<Skill>();
		skillBlocker = new List<Skill_Blocker>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

}
