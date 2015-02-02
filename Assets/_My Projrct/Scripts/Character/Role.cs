// haikun huang


// Role Class
// 定义角色类所需要的组件

// Character  Info 角色信息
// Character Model 角色模型  — 通过外部初始化创建的角色模型信息。
// Character Equipment 角色装备
// Character Skill 角色技能


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Role_Tags))]
public class Role : MonoBehaviour 
{
	// 角色信息
	public Character_Info info {set;get;}

	// 角色装备
	public Character_Equipment equipment {set;get;}

	// 角色模型
	public Character_Model model {set;get;}

	// 角色技能
	
	// Init
	void Init(string char_id, Character_Model _model)
	{
		// 角色信息
		info = new Character_Info();
		info.Init(char_id);

		// 角色装备
		equipment = new Character_Equipment();

		// 角色模型
		model = _model;

		// 角色技能

	}
}
