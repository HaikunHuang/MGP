using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu_MainObect : MonoBehaviour 
{
	
	public Button debugButton;

	// Use this for initialization
	void Start () 
	{
		Global_Tools.UpToDate();


		// debug ?
		if (debugButton)
			debugButton.gameObject.SetActive (Global_Tools.gameSetting_debug);

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	// For the button function
	public void Button_Debug()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.debug_Stage);
	}

	// For the login functino
	public void Button_Login()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.login_Stage);
	}


}
