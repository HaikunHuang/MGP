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

	public List<string> list_equipIDs;

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
			gameObject.GetComponent<Character_Info>().Calculate_All();
		}
		else
			return false;

		return true;
	}

	// 删除一个装备
	public bool Del_Equipment(string equipID)
	{
		bool ret = list_equipIDs.Remove(equipID);
		gameObject.GetComponent<Character_Info>().Calculate_All();
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



}
