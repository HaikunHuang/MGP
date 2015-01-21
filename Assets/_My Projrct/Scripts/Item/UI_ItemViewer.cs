using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI_ItemViewer : MonoBehaviour {

	public UI_Describe descirbe;

	public UI_Item_Slot[] itemSlots;

	public Text page;

	// a list of all the item id
	string[] list_item_ids;

	int current_page = 0, max_pages = 1;


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
		foreach (UI_Item_Slot slot in itemSlots)
		{
			slot.Clear();
		}
	}

	// Initialization
	public void Init()
	{
		// first is list the all the item id and store them into a list.
		list_item_ids = Global_Item_Manager.Get_All_Items();

		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI ItemViewer got " + list_item_ids.Length + " items." );
		}

		// calculate how many pages we have
		int count = list_item_ids.Length;
		max_pages = Mathf.CeilToInt( count *1.0f / itemSlots.Length);
		
		if (max_pages ==0)
			max_pages = 1;
		current_page = 0;

		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI ItemViewer got " + max_pages + " pages." );
		}

		Update_Slots();
		Update_Pages();
	}

	// to re-assign the slots
	public void Update_Slots()
	{
		Clear();

		int startIndex = itemSlots.Length * current_page;
		for (int i=0;
		     i<itemSlots.Length && startIndex+i<list_item_ids.Length; 
		     i++)
		{
			if (Global_Tools.gameSetting_debug)
			{
				Debug.Log(" UI ItemViewer re-assign item slot #" + i + " to item " + list_item_ids[startIndex+i]);
			}
			itemSlots[i].Init_Item(list_item_ids[startIndex+i],"",false,false);

			// delegate
			if (itemSlots[i].uiSlotOnClick == null)
				itemSlots[i].uiSlotOnClick = Item_Slot_OnClick;
			else
				itemSlots[i].uiSlotOnClick += Item_Slot_OnClick;
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
			Debug.Log(" UI ItemViewer page change to #" + (current_page+1));
		}
	}
	
	public void Prev()
	{
		current_page = (current_page - 1 + max_pages) % max_pages;
		Update_Slots();
		Update_Pages();
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI ItemViewer page change to #" + (current_page+1));
		}
	}

	public void Item_Slot_OnClick(string _item_id)
	{
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI ItemViewer Item Slot OnClick [" + _item_id + " - " + Global_Item_Manager.Get_Item(_item_id).item_name +"]");
		}

		
		// debug show
		if (Global_Tools.gameSetting_debug_detail)
		{
			Debug.Log("Recipe Review: " + _item_id + " - " + Global_Item_Manager.Get_Item(_item_id).item_name);
			if (Global_Recipe_Manager.Get_Recipe(_item_id)!=null)
			{
				Debug.Log("["+Global_Item_Manager.Get_Item(_item_id).item_name + "] Made By:\n" 
					+ Global_Recipe_Manager.Get_Recipe(_item_id).ToString() );


			}
			if (Global_Item_Manager.Get_Item(_item_id).Get_Products_Name().Length > 0)
			{
				Debug.Log("["+Global_Item_Manager.Get_Item(_item_id).item_name + "] Produce To:\n" 
				          + Global_Tools.ToString_From_Array_endwith_NewLine(Global_Item_Manager.Get_Item(_item_id).Get_Products_Name()
				                                                   ));
			}

		}

		// show the descirbe 
		descirbe.gameObject.SetActive(true);
		descirbe.Init(_item_id);


	}
}
