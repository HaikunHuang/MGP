using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login_MainObject : MonoBehaviour 
{

	public InputField username, password;
	public Text showInfo;
	// Use this for initialization
	void Start () 
	{
		Global_Tools.UpToDate();

		showInfo.text = "";
		// first check if the user has login 
		if (Is_Login())
		{
			// did user play tutor battle already?
			if (!ES2.Exists(Global_Tools.globalData_tutor_battle))
			{
				Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.tutor_battle_Stage);
			}
			else
			{
				Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.gameMainMenu_Stage);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// check if the user has login 
	bool Is_Login()
	{
		if (ES2.Exists(Global_Tools.userInfo_username_Tag))
		{
			if (ES2.Load<string>(Global_Tools.userInfo_username_Tag)!= "")
			{
				// also load the password and login
				// online process here...
				return true;
			}
		}
		return false;
	}

	public void  Button_Login()
	{
		if (username.text == "" || password.text == "")
		{
			showInfo.text = "用户名或密码错误！";
			return;
		}
		// check if the username and password match to the record online or whatelse
		// add the online code here

		// if not match, respon to the user, and return

		// else assume that it match the record
		// record the user info to local file
		ES2.Save(username.text,Global_Tools.userInfo_username_Tag);
		ES2.Save(password.text,Global_Tools.userInfo_userpsw_Tag);

		// did user play tutor battle already?
		if (!ES2.Exists(Global_Tools.globalData_tutor_battle))
		{
			Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.tutor_battle_Stage);
		}
		else
		{
			Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.gameMainMenu_Stage);
		}
	}

	public void Button_Home()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.mainMenu_Stage);
	}
}
