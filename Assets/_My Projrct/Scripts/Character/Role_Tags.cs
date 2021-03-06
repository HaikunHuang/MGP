﻿// haikun huang

// Role_Tags
// 标签功能扩展类，用于扩展Unity3D自带的标签功能。

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Role_Tags : MonoBehaviour 
{
	public enum TAG
	{
		None,
		Team_Red, // or called player team
		Team_Blue, // or called enemy team

		Role_Player, // player id

		// or other special team
		Skeleton
	}

	// 所属团队
	public TAG[] belong_teams;

	// 敌对团队
	public TAG[] against_teams;

	// 寻找属于指定团队的角色
	public static Role_Tags[] Find_Objects_Belong_Teams(TAG[] tags)
	{
		List<Role_Tags> role_tags = new List<Role_Tags>();
		
		// 找出所有包含Role_Tags组件的对象
		Role_Tags[] all_role_tags = Object.FindObjectsOfType<Role_Tags>();
		
		// 如果某个对象满足所指定的团队（组）的话，加入返回列表中。
		foreach(Role_Tags t in all_role_tags)
		{
			if (t.Is_Belong_Teams(tags))
				role_tags.Add(t);
		}
		
		return role_tags.ToArray();
	}

	// 寻找包含指定敌对团队的角色
	public static Role_Tags[] Find_Objects_Against_Teams(TAG[] tags)
	{
		List<Role_Tags> role_tags = new List<Role_Tags>();
		
		// 找出所有包含Role_Tags组件的对象
		Role_Tags[] all_role_tags = Object.FindObjectsOfType<Role_Tags>();
		
		// 如果某个对象满足所指定的团队（组）的话，加入返回列表中。
		foreach(Role_Tags t in all_role_tags)
		{
			if (t.Is_Against_Teams(tags))
				role_tags.Add(t);
		}
		return role_tags.ToArray();
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// add a new team to it
	public void Add_Belong_Team(TAG tag)
	{
		List<TAG> oldTags = new List<TAG>(belong_teams);
		oldTags.Add(tag);
		belong_teams = oldTags.ToArray();
	}

	// add a new against team to it
	public void Add_Against_Team(TAG tag)
	{
		List<TAG> oldTags = new List<TAG>(against_teams);
		oldTags.Add(tag);
		against_teams = oldTags.ToArray();
	}

	// 是否属于指定团队（组）
	public bool Is_Belong_Teams(TAG[] tags)
	{
		List<TAG> listTeam = new List<TAG>(belong_teams);
		foreach(TAG t in tags)
		{
			if (!listTeam.Contains(t))
				return false;
		}
		return true;
	}

	// 是否包含指定敌对团队（组）
	public bool Is_Against_Teams(TAG[] tags)
	{
		List<TAG> listTeam = new List<TAG>(against_teams);
		foreach(TAG t in tags)
		{
			if (!listTeam.Contains(t))
				return false;
		}
		return true;
	}

}
