// haikun huang

// Character_Equipment
// 角色装备栏，用于记录角色的装备及计算其加成的效果。

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character_Equipment : MonoBehaviour
{

	// 最大装备数量
	const int max_equips = 6;

	List<string> list_equipIDs;

	public void Init()
	{
		list_equipIDs = new List<string>();
	}

	// 添加一个装备
	public bool Add_Equipment(string equipID)
	{
		if (list_equipIDs.Count < max_equips && !Is_Equipment(equipID))
		{
			list_equipIDs.Add(equipID);
			Calculate_All();
		}
		else
			return false;

		return true;
	}

	// 删除一个装备
	public bool Del_Equipment(string equipID)
	{
		bool ret = list_equipIDs.Remove(equipID);
		Calculate_All();
		return ret;
	}

	// 装备数量
	public int Get_Equipment_Count()
	{
		return list_equipIDs.Count;
	}

	// 是否拥有指定装备
	public bool Is_Equipment(string equipID)
	{
		return list_equipIDs.Contains(equipID);
	}

	// 计算各种属性
	public void Calculate_All()
	{
		Character_Info char_info = gameObject.GetComponent<Character_Info>();

		char_info.Clear_Info();

		// 计算道具中的所有属性
		foreach(string equipID in list_equipIDs)
		{
			Item_Equipment equip = Global_Item_Manager.Get_Item(equipID) as Item_Equipment;

			// 力量	智力	敏捷	生命值	物理攻击力	魔法攻击力	
			char_info.power 		+= equip.power;
			char_info.wis 			+= equip.wis;
			char_info.agi 			+= equip.agi;
			char_info.HP 			+= equip.HP;
			char_info.attack 		+= equip.attack;
			char_info.magic 		+= equip.magic;
			// 物理防御	魔法防御	物理暴击	魔法暴击	物理穿透	
			char_info.anti_attack 	+= equip.anti_attack;
			char_info.anti_magic 	+= equip.anti_magic;
			char_info.attack_crit 	+= equip.attack_crit;
			char_info.magic_crit 	+= equip.magic_crit;
			char_info.attack_ap 	+= equip.attack_ap;
			// 魔法穿透	吸血	物理反伤	命中	闪避	生命回复量	
			char_info.magic_ap 		+= equip.magic_ap;
			char_info.vampire 		+= equip.vampire;
			char_info.attack_back 	+= equip.attack_back;
			char_info.hit			+= equip.hit;
			char_info.dodge 		+= equip.dodge;
			char_info.life_restore 	+= equip.life_restore;
			// 抵抗沉默	技能提升等级	备注，使用全角符号。
			char_info.anti_silence 	+= equip.anti_silence;
			char_info.skill_up 		+= equip.skill_up;
		}

		// reset the current HP
		char_info.current_HP = char_info.HP;

	}

}
