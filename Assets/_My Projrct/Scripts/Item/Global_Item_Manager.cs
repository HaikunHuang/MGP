// haikun huang

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;


/*
 * This is a Global tools use to manage all the item data
 */
public class Global_Item_Manager 
{
	// item data dictionary<item_id,item>
	static Dictionary<string,Item> ItemDict = new Dictionary<string, Item>();

	static public void Clear()
	{
		ItemDict.Clear();
	}

	static public void Update_Equiment_From_Online(string identifyFile, string onlineFile)
	{
		// save update file to ES2
		// save whole file 
	}
	
	static public void Load_Equiment_From_Memory(string identifyFile)
	{
		// load the whole file from ES2
		
		// paser by Load_X_From_String()
	}


	static public void Load_Equiment_From_String(string data)
	{
		// read the file line by line
		string[] files = data.Split('\n');
		for(int i=0; i<files.Length; i++)
		{
			string line = files[i].Trim();
			
			if (line.Length == 0)
				continue;
			
			// if any line begin with a char '#', that means this line is a comment line, then skip it
			if (line.ToCharArray()[0] == '#')
				continue;
			
			// parse the string 
			string[] lines = line.Split(',');
			for (int k=0; k<lines.Length; k++)
			{
				lines[k] = lines[k].Trim();
			}
			// not a item
			if (lines[0] == "")
				continue;
			
			if (Global_Tools.gameSetting_debug_detail)
			{
				Debug.Log("Equiment Raw data: " + line);
			}
			
			Item_Equipment item = new Item_Equipment();
			// 0 1 2 3
			// #item_id	中文名字	图表路径	类型（无用）
			item.item_id = lines[0];
			item.item_name = lines[1];
			item.item_icon_path = lines[2];
			
			
			// 4	5
			// 装备等级	装备颜色 0白色|1绿色|2蓝色|3紫色|4橙色	
			if (lines[4] != "")
			{
				item.item_level = int.Parse(lines[4]);
			}
			if (lines[5] != "")
			{
				item.item_color = int.Parse(lines[5]);
			}
			
			
			// 6	7	8	9	10	11	12
			// 买	卖	买 by $	力量	智力	敏捷	生命值	
			if (lines[6] != "")
			{
				item.item_buy = int.Parse(lines[6]);
			}
			if (lines[7] != "")
			{
				item.item_sell = int.Parse(lines[7]);
			}
			if (lines[8] != "")
			{
				item.item_buy_dollar = int.Parse(lines[8]);
			}
			if (lines[9] != "")
			{
				item.power = int.Parse(lines[9]);
			}
			if (lines[10] != "")
			{
				item.wis = int.Parse(lines[10]);
			}
			if (lines[11] != "")
			{
				item.agi = int.Parse(lines[11]);
			}
			if (lines[12] != "")
			{
				item.HP = int.Parse(lines[12]);
			}
			
			// 13	14	15	16
			// 物理攻击力	魔法攻击力	物理防御	魔法防御	
			if (lines[13] != "")
			{
				item.attack = int.Parse(lines[13]);
			}
			if (lines[14] != "")
			{
				item.magic = int.Parse(lines[14]);
			}
			if (lines[15] != "")
			{
				item.anti_attack = int.Parse(lines[15]);
			}
			if (lines[16] != "")
			{
				item.anti_magic = int.Parse(lines[16]);
			}
			// 17	18	19	20	21
			// 物理暴击	魔法暴击	物理穿透	魔法穿透	吸血	
			if (lines[17] != "")
			{
				item.attack_crit = int.Parse(lines[17]);
			}
			if (lines[18] != "")
			{
				item.magic_crit = int.Parse(lines[18]);
			}
			if (lines[19] != "")
			{
				item.attack_ap = int.Parse(lines[19]);
			}
			if (lines[20] != "")
			{
				item.magic_ap = int.Parse(lines[20]);
			}
			if (lines[21] != "")
			{
				item.vampire = int.Parse(lines[21]);
			}
			
			
			// 22	23	24	25
			// 物理反伤	命中	闪避	生命回复量	
			if (lines[22] != "")
			{
				item.attack_back = int.Parse(lines[22]);
			}
			if (lines[23] != "")
			{
				item.hit = int.Parse(lines[23]);
			}
			if (lines[24] != "")
			{
				item.dodge = int.Parse(lines[24]);
			}
			if (lines[25] != "")
			{
				item.life_restore = int.Parse(lines[25]);
			}
			
			// 26	27	28
			// 抵抗沉默	技能提升等级	备注，使用全角符号。
			if (lines[26] != "")
			{
				item.anti_silence = int.Parse(lines[26]);
			}
			if (lines[27] != "")
			{
				item.skill_up = int.Parse(lines[27]);
			}
			item.comment = lines[28];
			
			// init 
			item.Init();
			
			// add 
			if (ItemDict.ContainsKey(item.item_id))
			{
				// if existed, update it
				ItemDict[item.item_id] = item;
			}
			else
			{
				ItemDict.Add(item.item_id,item);
			}
			
			if (Global_Tools.gameSetting_debug_detail)
			{
				Debug.Log("Add item: " + item.item_id + " - " + item.item_name);
				Debug.Log("["+item.item_name + "]\n" +item.ToString());
			}
		}
	}

	static public void Load_Equiment_From_Resource(string filePath)
	{
		Object obj = Resources.Load<Object>(filePath);
		
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log("Load_Equiment Read File:\n" + obj);
		}

		Load_Equiment_From_String(obj.ToString());

	}

	// Get a Item by a specialy item id
	static public Item Get_Item( string item_id )
	{
		Item ret_item = null;

		if (ItemDict.ContainsKey(item_id))
		{
			ret_item = ItemDict[item_id];
		}

		return ret_item;
	}

	// Get all the id of the items
	static public string[] Get_All_Items()
	{
		List<string> all_items = new List<string>();
		foreach(string it in ItemDict.Keys)
		{
			all_items.Add(it);
		}
		return all_items.ToArray();
	}
}
