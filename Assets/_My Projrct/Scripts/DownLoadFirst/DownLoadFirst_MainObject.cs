using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DownLoadFirst_MainObject : MonoBehaviour {

	IniFile gameSetting;

	public Text showInfo;

	// Use this for initialization
	void Start () 
	{
		// enable the compass function.
		Input.compass.enabled = true;
		// setup the FPS fixed it at 60
		Application.targetFrameRate = 60;
		// set up to data false
		Global_Tools.isUpToDate = false;

		Debug.Log("Current Platform is " + Application.platform);
		// load game setting
		Load_GameSetting();	

		if (showInfo)
			showInfo.text = "Loading...";

		// 
		// show some tips here

		StartCoroutine(Load_UpdateSetting_Online());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator Load_UpdateSetting_Online()
	{
		// load the update setting online

		yield return null;

		//done
		StartCoroutine(PreLoad());
	}

	IEnumerator PreLoad()
	{
		// preload here
		if (Global_Tools.gameSetting_debug)
			Debug.Log("Preloading now:");
		
		// clean up first
		if (showInfo)
			showInfo.text = "Cleanning the battle field...";
		
		Global_Item_Manager.Clear();
		Global_Character_Base_Info_Manager.Clear();
		
		yield return null;
		

		////////////// Item_Equipment_Path /////////////
		if (Global_Tools.gameSetting_debug)
			Debug.Log("Loading " + Global_Tools.item_Equipment_Path);
			
		if (showInfo)
			showInfo.text = "Loading \"" + Global_Tools.item_Equipment_Path + "\"";
		yield return null;
		Global_Item_Manager.Load_Equiment_From_Resource(Global_Tools.item_Equipment_Path);
		//yield return null;
		yield return null;

		// check if need to update the file online and save it to memory

		// load the update file from memory
			
		// Recipe_Path & update online
		if (Global_Tools.gameSetting_debug)
			Debug.Log("Loading " + Global_Tools.recipe_Path);
			
		if (showInfo)
			showInfo.text = "Loading \"" + Global_Tools.recipe_Path + "\"";
		yield return null;

		Global_Recipe_Manager.Load_Recipe_From_Resource(Global_Tools.recipe_Path);
		//yield return null;
		yield return null;

		// check if need to update the file online and save it to memory
		
		// load the update file from memory



		//////////////// Character Base Info //////////////
		if (Global_Tools.gameSetting_debug)
			Debug.Log("Loading " + Global_Tools.character_baseInfo_Path);
		
		if (showInfo)
			showInfo.text = "Loading \"" + Global_Tools.character_baseInfo_Path + "\"";
		yield return null;

		Global_Character_Base_Info_Manager.Load_From_Resource(Global_Tools.character_baseInfo_Path);
		//yield return null;
		yield return null;


		// check if need to update the file online and save it to memory
		
		// load the update file from memory



		//////////////// load others //////////////
	
		// end load
		if (Global_Tools.gameSetting_debug)
			Debug.Log("Preloading Done!");
			
		showInfo.text = "Loading Done!";
		yield return null;
		// yield return new WaitForSeconds(1f);



		// UpDated
		Global_Tools.isUpToDate = true;
		// gotot the next stage
		Application.LoadLevel(Global_Tools.mainMenu_Stage);
	}

	// load the game setting 
	void Load_GameSetting()
	{
		gameSetting = new IniFile(Global_Tools.gameSetting_Path,true);
		
		// if disable the debug function, that disactive the debug button.
		gameSetting.goTo("Setting");
		if (gameSetting.GetValue_Int("debug",0) == 0)
		{
			// Global_Tools.gameSetting_debug = false;
		}
		else
		{
			Global_Tools.gameSetting_debug = true;
			
			if (gameSetting.GetValue_Int("debug_detail",0) == 0)
			{
			}
			else
			{
				Global_Tools.gameSetting_debug_detail = true;
			}
		}
		
		// email setting
		Global_Tools.gameSetting_emailTo = gameSetting.GetValue_String("emailTo");
		Global_Tools.gameSetting_emailFrom = gameSetting.GetValue_String("emailFrom");
		Global_Tools.gameSetting_emailFromPSW = gameSetting.GetValue_String("emaliFromPSW");
		Global_Tools.gameSetting_emailSmtp = gameSetting.GetValue_String("emailSmtp");
		
		
		
	}
}
