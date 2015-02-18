// haikun huang

// Character_Info
// 角色信息，不同于Character_Base_Info, 
// 本类是具体于每个角色修正后的所以属性，包括道具加成，buff，debuff等。

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character_Info : MonoBehaviour
{
	// Character_Base_Info
	public Character_Base_Info base_info;

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

	// current info
	public int current_HP = 0;
	// public int current_SP = 0; // skill power;

	

	// 
	public void Init(string char_id)
	{
		Character_Base_Info info = Global_Character_Base_Info_Manager.Get(char_id);
		if (info != null)
		{
			Init (info);
		}
		else
		{
			if (Global_Tools.gameSetting_debug)
			{
				Debug.Log("Character_Info Init() Failed! character id = " + char_id);
			}
		}
	}

	// 
	public void Init(Character_Base_Info info)
	{
		base_info = new Character_Base_Info(info);
		Clear_Info();
	}

	// 所有属性
	public void Clear_Info()
	{
		// 力量	智力	敏捷	生命值	物理攻击力	魔法攻击力	
		power =0;
		wis = 0;
		agi = 0;
		HP = base_info.base_hp;
		attack = base_info.base_attack;
		magic = base_info.base_magic;
		// 物理防御	魔法防御	物理暴击	魔法暴击	物理穿透	
		anti_attack = 0;
		anti_magic = 0;
		attack_crit = 0;
		magic_crit = 0;
		attack_ap = 0;
		// 魔法穿透	吸血	物理反伤	命中	闪避	生命回复量	
		magic_ap = 0;
		vampire = 0;
		attack_back = 0;
		hit = 0;
		dodge = 0;
		life_restore = 0;
		// 抵抗沉默	技能提升等级	备注，使用全角符号。
		anti_silence = 0;
		skill_up = 0;
	}

	// 计算各种属性
	public void Calculate_All()
	{
		Character_Equipment equipment = gameObject.GetComponent<Character_Equipment>();
		
		Clear_Info();
		
		// 计算道具中的所有属性
		foreach(string equipID in equipment.list_equipIDs)
		{
			Item_Equipment equip = Global_Item_Manager.Get_Item(equipID) as Item_Equipment;
			
			// 力量	智力	敏捷	生命值	物理攻击力	魔法攻击力	
			power 		+= equip.power;
			wis 			+= equip.wis;
			agi 			+= equip.agi;
			HP 			+= equip.HP;
			attack 		+= equip.attack;
			magic 		+= equip.magic;
			// 物理防御	魔法防御	物理暴击	魔法暴击	物理穿透	
			anti_attack 	+= equip.anti_attack;
			anti_magic 	+= equip.anti_magic;
			attack_crit 	+= equip.attack_crit;
			magic_crit 	+= equip.magic_crit;
			attack_ap 	+= equip.attack_ap;
			// 魔法穿透	吸血	物理反伤	命中	闪避	生命回复量	
			magic_ap 		+= equip.magic_ap;
			vampire 		+= equip.vampire;
			attack_back 	+= equip.attack_back;
			hit			+= equip.hit;
			dodge 		+= equip.dodge;
			life_restore 	+= equip.life_restore;
			// 抵抗沉默	技能提升等级	备注，使用全角符号。
			anti_silence 	+= equip.anti_silence;
			skill_up 		+= equip.skill_up;
		}
		
		// calculate with buff

		//calculate with debuff


		
	}
}
