// Haikun Huang

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Character_InfoShower : MonoBehaviour 
{
	// character's icon, it is the same thing to item slot.
	public UI_Character_Slot charSlot;

	// name
	public Text charName;

	// info shower
	public Text infoShower;

	public string _id;

	public UI_Character_Picker charPicker;

	// Use this for initialization
	void Start () 
	{
		// gameObject.SetActive(false);
		Clear();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void Clear()
	{
		_id = "";
	}

	// Initialization
	public void Init_Character(string _char_id, bool bmark1 = false, bool bmark2 = false )
	{
		Clear();

		// get the item info from the item manager
		Character_Base_Info info = Global_Character_Base_Info_Manager.Get(_char_id);
		if (info == null)
			return;

		_id = _char_id;
		// char slot Initialization
		charSlot.Init_Character(_char_id,bmark1,bmark2);

		// text
		charName.text = info.character_name;
		infoShower.text = info.ToString();

		// assign the delgate method
		if (charSlot.uiSlotOnClick == null)
			charSlot.uiSlotOnClick = Character_Slot_OnClick;
		else
			charSlot.uiSlotOnClick += Character_Slot_OnClick;

	}

	// delgate function
	public void Character_Slot_OnClick(string _char_id)
	{
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Character Slot OnClick [" + _char_id + " - " 
			          + Global_Character_Base_Info_Manager.Get(_char_id).character_name +"]");
		}

		// show the picker 
		charPicker.gameObject.SetActive(true);

		gameObject.SetActive(false);
	}
}
