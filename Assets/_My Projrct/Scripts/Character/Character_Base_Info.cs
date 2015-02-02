using UnityEngine;

public class Character_Base_Info  
{

	// 0
	// character_id,
	public string character_id;

	// 1
	// model 文件名，Resources中的文件名
	public string character_model_path;

	// 2
	// 中文名字
	public string character_name;

	// 3
	// 图标路径
	public string character_icon_path;
	public Texture character_icon;

	// 4
	// 解锁价值$
	public int character_unlock_value;

	// 5
	// 基础攻击ID
	public string attack_id;

	// 6
	// 技能名ID
	public string skill_id;

	// 7
	// 大招名ID
	public string power_attack_id;

	// 8
	// 基础血量
	public int base_hp;

	// 9
	//基础物理攻击
	public int base_attack;

	// 10
	// 基础魔法攻击
	public int base_magic;

	// 11
	// 进场攻击顺序 例如 0|0|1|1,0为基础攻击，1为技能攻击
	public string[] charge_attack_order;

	// 12
	// 循环攻击, 例如 0|1|0|1
	public string[] loop_attack_order;

	//13
	//备注，使用全角符号。
	public string comment;




	public Character_Base_Info()
	{

	}

	public Character_Base_Info(Character_Base_Info info)
	{
		// 0
		// character_id,
		this.character_id = info.character_id;
		
		// 1
		// model 文件名，Resources中的文件名
		this.character_model_path = info.character_model_path;
		
		// 2
		// 中文名字
		this.character_name = info.character_name;
		
		// 3
		// 图标路径
		this.character_icon_path = info.character_icon_path;
		this.character_icon = info.character_icon;
		
		// 4
		// 解锁价值$
		this.character_unlock_value = info.character_unlock_value;
		
		// 5
		// 基础攻击ID
		this.attack_id = info.attack_id;
		
		// 6
		// 技能名ID
		this.skill_id = info.skill_id;
		
		// 7
		// 大招名ID
		this.power_attack_id = info.power_attack_id;
		
		// 8
		// 基础血量
		this.base_hp = info.base_hp;
		
		// 9
		//基础物理攻击
		this.base_attack = info.base_attack;
		
		// 10
		// 基础魔法攻击
		this.base_magic = info.base_magic;
		
		// 11
		// 进场攻击顺序 例如 0|0|1|1,0为基础攻击，1为技能攻击
		this.charge_attack_order = info.charge_attack_order;
		
		// 12
		// 循环攻击, 例如 0|1|0|1
		this.loop_attack_order = info.loop_attack_order;
		
		//13
		//备注，使用全角符号。
		this.comment = info.comment;


	}


	public void Init()
	{
		// load icon
		if (!string.IsNullOrEmpty(character_icon_path))
		{
			character_icon = Resources.Load<Texture>(character_icon_path);
		}
	}

	public override string ToString()
	{
		// load other info
		string infotext = "";
		infotext += ("ID: " + character_id + "\n");
		infotext += ("Model Path: " + character_model_path + "\n");
		infotext += ("名字: " + character_name + "\n");
		infotext += ("图标: " + character_icon_path + "\n");
		infotext += ("解锁价值$: " + character_unlock_value + "\n");
		infotext += ("基础攻击ID: " + attack_id + "\n");
		infotext += ("技能名ID: " + skill_id + "\n");
		infotext += ("大招名ID: " + power_attack_id + "\n" );
		infotext += ("基础血量: " + base_hp + "\n" );
		infotext += ("基础物理攻击: " + base_attack + "\n");
		infotext += ("基础魔法攻击: " + base_magic + "\n");
		infotext += ("进场攻击顺序: " );
		for (int i=0; i<charge_attack_order.Length; i++)
		{
			infotext += charge_attack_order[i];
			if (i+1 <charge_attack_order.Length)
				infotext += ",";
		}
		infotext += "\n";
		infotext += ("循环攻击顺序: ");
		for (int i=0; i<loop_attack_order.Length; i++)
		{
			infotext += loop_attack_order[i];
			if (i+1 <loop_attack_order.Length)
				infotext += ",";
		}
		infotext += "\n";
		infotext += ("备注: " + comment);

		return infotext;
	}

}
