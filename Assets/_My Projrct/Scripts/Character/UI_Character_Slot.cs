// haikun huang

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Character_Slot : UISlot {

	// Initialization
	public void Init_Character(string _char_id, bool bmark1 = false, bool bmark2 = false )
	{
		Clear();
		
		// get the item info from the item manager
		Character_Base_Info info = Global_Character_Base_Info_Manager.Get(_char_id);
		if (info == null)
			return;
		
		_id = _char_id;
		
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log("UI Character Slot Loading a Item: ["+ _id
			          + " - " + Global_Character_Base_Info_Manager.Get(_id).character_name
			          +"]");
		}
		// icon.enabled
		icon.color = Color.white;
		icon.texture = Resources.Load<Texture>(info.character_icon_path);
		
		// cover.color 
		// top.color
		//cover.color = Color.white;
		cover.color = new Color(cover.color.r,cover.color.g,cover.color.b,0f);
		top.color = Color.white;
		
		
		// mark1.enabled
		mark1.enabled = bmark1;
		// mark2.enabled
		mark2.enabled = bmark2;
		// number.text
		number.text = "";
		
		// eable the function of button
		GetComponent<Button>().interactable = true;
		
	}
}
