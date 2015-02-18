// haikun huang

// this class is defined to describe the skill blocker which used to limit the target actions.
// e.g disable some actions, or disallow the target do something for a while.
using UnityEngine;
using System.Collections;

public class Skill_Blocker
{
	// type of the blocker
	public enum TYPE
	{
		None,
		Silence,// 禁止施法
		Disability,// 禁止移动
		Void,// 虚无状态
	}

	public TYPE type;

	// id
	public string blocker_id;

	// time
	public float maxDuringTime = 0.0f;
	public float currentDuringTime = 0.0f;


	
	// parse the type from string
	public void Parse_Type(string str_blocker)
	{
		if (str_blocker == "Silence")
		{
			type = TYPE.Silence;
		}if (str_blocker == "Disability")
		{
			type = TYPE.Disability;
		}
		else if (str_blocker == "Void")
		{
			type = TYPE.Void;
		}
		else
		{
			type = TYPE.None;
		}
	}

}
