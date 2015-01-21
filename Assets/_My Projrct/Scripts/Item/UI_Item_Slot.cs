// haikun huang
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Item_Slot : UISlot 
{
	
	// Initialization
	public void Init_Item(string _item_id, string snumber = "", bool bmark1 = false, bool bmark2 = false )
	{
		Clear();

		// get the item info from the item manager
		Item item = Global_Item_Manager.Get_Item(_item_id);
		if (item == null)
			return;

		_id = _item_id;

		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log("UI Item Slot Loading a Item: ["+ _id
			          + " - " + Global_Item_Manager.Get_Item(_id).item_name
			          +"]");
		}
		// icon.enabled
		icon.color = Color.white;
		icon.texture = Resources.Load<Texture>(item.item_icon_path);

		// cover.color 
		// top.color
		if (item.item_color > 0)
		{
			cover.color = item.item_cole_value;
			cover.color = new Color(cover.color.r,cover.color.g,cover.color.b,0.8f);
			top.color = item.item_cole_value;
		}

		// mark1.enabled
		mark1.enabled = bmark1;
		// mark2.enabled
		mark2.enabled = bmark2;
		// number.text
		number.text = snumber;

		// eable the function of button
		GetComponent<Button>().interactable = true;

	}




}
