using UnityEngine;
using System.Collections;

/*
 * Application.persistentDataPath:
 * /Users/haikunhuang/Library/Application Support/DefaultCompany/Moble Game Project/
*/
public class Global_Tools
{
	// some path
	public const string gameSetting_Path = "GameSetting";
	public const string item_Equipment_Path = "Items/Item_equipment";
	public const string recipe_Path = "Items/Recipe";
	public const string character_baseInfo_Path = "Character/Character_BaseInfo";

	// ES2 idenity
	// GlobalData
	public const string globalData_Path = "GlobalData.txt";
	// public const string nextStageAfterPreLoad_Tag = GlobalData_Path +"?tag=nextStageAfterPreLoad";
	public const string globalData_tutor_battle = globalData_Path + "?tag=tutor_battle"; // played tutor battle?

	// UserInfo
	public const string userInfo_Path = "UserInfo.txt";
	public const string userInfo_username_Tag = userInfo_Path + "?tag=username";
	public const string userInfo_userpsw_Tag = userInfo_Path + "?tag=userpsw";

	// statge
	public const string mainMenu_Stage = "MainMenu";
	public const string preLoading_Stage = "PreLoading";
	public const string debug_Stage = "Debug";
	public const string itemViewer_Stage = "ItemViewer";
	public const string login_Stage = "Login";
	public const string gameMainMenu_Stage = "GameMainMenu";
	public const string downLoadFirst_Stage = "DownLoadFirst";
	public const string characterViewer_Stage = "CharacterViewer";
	public const string tutor_battle_Stage = "TutorBattle";

	public static string previous_Stage = mainMenu_Stage;
	public static string next_Stage = mainMenu_Stage;

	// gameseting
	public static bool gameSetting_debug = false;
	public static bool gameSetting_debug_detail = false;
	public static string gameSetting_emailTo = "";
	public static string gameSetting_emailFrom = "";
	public static string gameSetting_emailFromPSW = "";
	public static string gameSetting_emailSmtp = "";

	// global setting
	public static bool isUpToDate = false;

	// this function will be used mostly by users who wants to change the stage before loading data.
	static public void Goto_Next_Stage_via_PreLoading(string next_stage_name)
	{
		// the next_stage_name will be stored in [nextStageAfterPreLoad] of [GlobalData.txt]
		//ES2.Save(next_stage_name,nextStageAfterPreLoad_Tag);
		// store current stage name
		previous_Stage = Application.loadedLevelName;
		// store next stage name
		next_Stage = next_stage_name;
		// than goto preloading
		Application.LoadLevel(preLoading_Stage);
	}

	// this function will be used by program mostly, after preloading
	static public void Goto_Next_Stage_from_PreLoading()
	{
		// get the next_stage_name
		//string next = ES2.Load<string>(nextStageAfterPreLoad_Tag);
		// than goto next stage
		Application.LoadLevel(next_Stage);
	}

	static public string ToString_From_Array_endwith_NewLine(string[] array, string sp ="\n")
	{
		string ret = "";
		for (int i=0; i<array.Length; i++)
		{
			ret += array[i];
			if (i+1 < array.Length)
				ret += sp;
		}
		return ret;
	}


	// check is it up to date, just for test.
	static public void UpToDate()
	{
		if (!isUpToDate)
		{
			next_Stage = mainMenu_Stage;
			Application.LoadLevel(downLoadFirst_Stage);
		}
	}

}
