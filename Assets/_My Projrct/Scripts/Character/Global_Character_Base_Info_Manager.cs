using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class Global_Character_Base_Info_Manager 
{
	static Dictionary<string,Character_Base_Info> CharDict = new Dictionary<string, Character_Base_Info>();

	static public void Clear()
	{
		CharDict.Clear();
	}

	static public void Update_From_Online(string identifyFile, string onlineFile)
	{
		// save update file to ES2
		// save whole file 
	}
	
	static public void Load_From_Memory(string identifyFile)
	{
		// load the whole file from ES2
		
		// paser by Load_X_From_String()
	}
	
	
	static public void Load_From_String(string data)
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
				Debug.Log("Character Base Info Raw data: " + line);
			}
			
			// load here
			Character_Base_Info cbi = new Character_Base_Info();

			// 0
			// character_id
			cbi.character_id = lines[0];

			// 1
			// model 文件名，Resources中的文件名
			cbi.character_model_path = lines[1];
			
			// 2
			// 中文名字
			cbi.character_name = lines[2];
			
			// 3
			// 图标路径
			cbi.character_icon_path = lines[3];
			
			// 4
			// 解锁价值$
			if (lines[4] != "")
			{
				cbi.character_unlock_value = int.Parse(lines[4]);
			}
			
			// 5
			// 基础攻击ID
			cbi.attack_id = lines[5];

			
			// 6
			// 技能名ID
			cbi.skill_id = lines[6];

			
			// 7
			// 大招名ID
			cbi.power_attack_id = lines[7];

			
			// 8
			// 基础血量
			if (lines[8] != "")
			{
				cbi.base_hp = int.Parse(lines[8]);
			}
			
			// 9
			//基础物理攻击
			if (lines[9] != "")
			{
				cbi.base_attack = int.Parse(lines[9]);
			}
			
			// 10
			// 基础魔法攻击
			if (lines[10] != "")
			{
				cbi.base_magic = int.Parse(lines[10]);
			}
			
			// 11
			// 进场攻击顺序 例如 0|0|1|1,0为基础攻击，1为技能攻击
			if (lines[11] != "")
			{
				cbi.charge_attack_order = lines[11].Split('|');
			}
			
			// 12
			// 循环攻击, 例如 0|1|0|1
			if (lines[12] != "")
			{
				cbi.loop_attack_order = lines[12].Split('|');
			}
			
			//13
			//备注，使用全角符号。
			cbi.comment = lines[13];


			cbi.Init();

			// add here
			if (CharDict.ContainsKey(cbi.character_id))
			{
				// if existed, update it
				CharDict[cbi.character_id] = cbi;
			}
			else
			{
				CharDict.Add(cbi.character_id, cbi);
			}
			
			if (Global_Tools.gameSetting_debug_detail)
			{
				Debug.Log("Add Character: " + cbi.character_id + " - " + cbi.character_name);
				Debug.Log("["+cbi.character_name + "]\n" +cbi.ToString());
			}

		}
	}
	
	static public void Load_From_Resource(string filePath)
	{
		Object obj = Resources.Load<Object>(filePath);
		
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log("Load_Character Read File:\n" + obj);
		}
		
		Load_From_String(obj.ToString());
		
	}
	
	// Get a Item by a specialy item id
	static public Character_Base_Info Get( string character_id )
	{
		Character_Base_Info ret = null;
		
		if (CharDict.ContainsKey(character_id))
		{
			ret = CharDict[character_id];
		}
		
		return ret;
	}
	
	// Get all the id of the items
	static public string[] Get_All_Character()
	{
		List<string> all = new List<string>();
		foreach(string it in CharDict.Keys)
		{
			all.Add(it);
		}
		return all.ToArray();
	}
}
