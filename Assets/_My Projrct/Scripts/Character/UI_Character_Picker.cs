// haikun huang

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Character_Picker : MonoBehaviour 
{
	public UI_Character_InfoShower infoShower;
	
	public UI_Character_Slot[] charSlots;
	
	public Text page;
	
	// a list of all the item id
	string[] list_char_ids;
	
	int current_page = 0, max_pages = 1;

	public delegate void Init_Model(string _char_id);
	public Init_Model initModel;

	// Use this for initialization
	void Start () 
	{
		
		Clear();
		Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	// clear all the slots
	public void Clear()
	{
		foreach (UI_Character_Slot slot in charSlots)
		{
			slot.Clear();
		}
	}

	// Initialization
	public void Init()
	{
		// first is list the all the item id and store them into a list.
		list_char_ids = Global_Character_Base_Info_Manager.Get_All_Character();
		
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Character Base Info got " + list_char_ids.Length + " characters." );
		}
		
		// calculate how many pages we have
		int count = list_char_ids.Length;
		max_pages = Mathf.CeilToInt( count *1.0f / list_char_ids.Length);
		
		if (max_pages ==0)
			max_pages = 1;
		current_page = 0;
		
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Character Base Info got " + max_pages + " pages." );
		}
		
		Update_Slots();
		Update_Pages();
	}

	// to re-assign the slots
	public void Update_Slots()
	{
		Clear();
		
		int startIndex = charSlots.Length * current_page;
		for (int i=0;
		     i<charSlots.Length && startIndex+i<list_char_ids.Length; 
		     i++)
		{
			if (Global_Tools.gameSetting_debug)
			{
				Debug.Log(" UI Character Picker re-assign character slot #" + i + " to character "
				          + list_char_ids[startIndex+i]);
			}
			charSlots[i].Init_Character(list_char_ids[startIndex+i],false,false);
			
			// delegate
			if (charSlots[i].uiSlotOnClick == null)
				charSlots[i].uiSlotOnClick = Character_Slot_OnClick;
			else
				charSlots[i].uiSlotOnClick += Character_Slot_OnClick;
		}
	}

	void Update_Pages()
	{
		page.text = (current_page + 1) + " / " + max_pages;
	}
	
	public void Next()
	{
		current_page = (current_page + 1) % max_pages;
		Update_Slots();
		Update_Pages();
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Character Picker page change to #" + (current_page+1));
		}
	}
	
	public void Prev()
	{
		current_page = (current_page - 1 + max_pages) % max_pages;
		Update_Slots();
		Update_Pages();
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Iharacter Picker change to #" + (current_page+1));
		}
	}

	public void Character_Slot_OnClick(string _char_id)
	{
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Character Picker Item Slot OnClick [" + _char_id + " - " 
			          + Global_Character_Base_Info_Manager.Get(_char_id).character_name + "]");
		}
		
		
		// debug show
		if (Global_Tools.gameSetting_debug_detail)
		{
			Debug.Log("Character: " + _char_id + " - " + Global_Character_Base_Info_Manager.Get(_char_id).character_name);
		}
		
		// show the info shower 
		infoShower.gameObject.SetActive(true);
		infoShower.Init_Character(_char_id);

		if (initModel != null)
			initModel(_char_id);

		// disactive itself
		gameObject.SetActive(false);
	}
}
