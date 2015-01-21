using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMainMenu_MainObject : MonoBehaviour 
{
	public Button debug_home_button;
	public Text debug_text;
	// Use this for initialization
	void Start () 
	{
		Global_Tools.UpToDate();

		if (Global_Tools.gameSetting_debug)
		{
			if (debug_home_button)
				debug_home_button.gameObject.SetActive(true);
			if (debug_text)
				debug_text.gameObject.SetActive(true);

			Debug.Log("User login: " + ES2.Load<string>(Global_Tools.userInfo_username_Tag));
			if (debug_text)
				debug_text.text = "User [" + ES2.Load<string>(Global_Tools.userInfo_username_Tag) + "] welcome.";
		}
		else
		{
			if (debug_home_button)
				debug_home_button.gameObject.SetActive(false);
			if (debug_text)
				debug_text.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Button_Back_To_Home()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.mainMenu_Stage);
	}
}
