// haikun huang

// this is a base class of character skill


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill
{
	// defind the kinds of the skill
	public enum TYPE
	{
		None,
		Positive,
		Passive,
		Buff,
		Debuff,
	}


	
	// skill type
	public TYPE type;

	// skill ID
	public string skill_id;

	// skill name
	public string skill_name;

	// 力量	智力	敏捷	生命值	物理攻击力	魔法攻击力	
	public int power =0;
	public int wis = 0;
	public int agi = 0;
	public int HP = 0;
	public int attack = 0;
	public int magic = 0;
	// 物理防御	魔法防御	物理暴击	魔法暴击	物理穿透	
	public int anti_attack = 0;
	public int anti_magic = 0;
	public int attack_crit = 0;
	public int magic_crit = 0;
	public int attack_ap = 0;
	// 魔法穿透	吸血	物理反伤	命中	闪避	生命回复量	
	public int magic_ap = 0;
	public int vampire = 0;
	public int attack_back = 0;
	public int hit = 0;
	public int dodge = 0;
	public int life_restore = 0;
	// 抵抗沉默	技能提升等级	备注，使用全角符号。
	public int anti_silence = 0;
	public int skill_up = 0;

	// cost
	public int cost = 0;
	// cd
	public float cool_down = 0;
	public float current_cool_down = 0;

	// damage 
	public int damage_attack = 0;
	public int damage_magic = 0;

	// during time
	public float maxDuringTime = 0.0f;
	public float currentDureingTime = 0.0f;

	// special effect -- create a blocker to the targets that limit the target actions.
	public string blocker_id;
	public float blocker_maxDuringTime = 0.0f;

	// pre-skill, which skills need to be required for the currently skill?
	public string[] pre_skill_ids;


	// ref roles, ---- for buff and debuff
	public Role selfRole;
	public Role[] targerRoles;


	// execute the skill
	public virtual void Execute_Skill(Role self, Role[] targets){}
	


	// parse the skill type from string 
	public void Pares_Type(string str_type)
	{
		if (str_type == "Positive")
		{
			type = TYPE.Positive;
		}
		else if (str_type == "Passive")
		{
			type = TYPE.Passive;
		}
		else if (str_type == "Buff")
		{
			type = TYPE.Buff;
		}
		else if (str_type == "Debuff")
		{
			type = TYPE.Debuff;
		}
		else
		{
			type = TYPE.None;
		}
	}
}
