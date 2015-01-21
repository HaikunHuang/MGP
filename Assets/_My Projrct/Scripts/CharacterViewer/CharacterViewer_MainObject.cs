// haikun huang

using UnityEngine;
using System.Collections;

public class CharacterViewer_MainObject : MonoBehaviour 
{
	
	public GameObject spwanPoint;
	GameObject modelObject;

	//string[] all_characters;
	//int current_character_index = 0;

	public UI_Character_InfoShower cis;

	public UI_Character_Picker picker;

	CharacterAnimationController cac;




	// Use this for initialization
	void Start () 
	{
		Global_Tools.UpToDate();

		if (picker.initModel != null)
			picker.initModel = Init_Model;
		else
			picker.initModel += Init_Model;

		cis.gameObject.SetActive(false);
		picker.gameObject.SetActive(true);

		//all_characters = Global_Character_Base_Info_Manager.Get_All_Character();

		// Init();

	}

	// initialization model
	public void Init_Model(string _char_id)
	{
		if (modelObject != null)
		{
			DestroyObject(modelObject);
			modelObject = null;
		}

		cac = null;

		//if (all_characters.Length == 0)
			//return;

		// load the character from the Character Base Info
		Character_Base_Info cbi = Global_Character_Base_Info_Manager.Get(_char_id);
		if (cbi != null)
		{
			GameObject go = Resources.Load<GameObject>(cbi.character_model_path);
			modelObject = Instantiate(go,spwanPoint.transform.position,spwanPoint.transform.rotation) as GameObject;
		}

		if (modelObject)
		{
			modelObject.transform.parent = spwanPoint.transform;
			cac = modelObject.GetComponent<CharacterAnimationController>();
		}

		if (cis)
		{
			cis.Init_Character(cbi.character_id);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void Button_Function_BackToPreviousStage()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.debug_Stage);
	}
	

	///////////////////////////////////////////////////////////////
	/// UI functions for character //////////////
	///////////////////////////////////////////////////////////////

	public void UI_Function_Idle()
	{
		if (cac)
		{
			cac.ReStart();
		}
	}

	public void UI_Function_Walk()
	{
		if (cac)
		{
			cac.Walk();
		}
	}

	public void UI_Function_Run()
	{
		if (cac)
		{
			cac.Run();
		}
	}

	public void UI_Function_Attack_0()
	{
		if (cac)
		{
			cac.Attack_0();
		}
	}
	
	public void UI_Function_Attack_1()
	{
		if (cac)
		{
			cac.Attack_1();
		}
	}
	
	public void UI_Function_Power_Attack()
	{
		if (cac)
		{
			cac.Power_Attack();
		}
	}
	
	public void UI_Function_Victory_Pose()
	{
		if (cac)
		{
			cac.Victory_Pose();
		}
	}
	
	public void UI_Function_Hurt()
	{
		if (cac)
		{
			cac.Hurt();
		}
	}
	
	public void UI_Function_Die()
	{
		if (cac)
		{
			cac.Die();
		}
	}

}
