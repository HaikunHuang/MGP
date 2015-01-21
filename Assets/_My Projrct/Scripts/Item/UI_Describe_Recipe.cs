using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI_Describe_Recipe : MonoBehaviour 
{
	public Image frame1,frame2;
	public RawImage tato1,tato2;
	public Text page;

	public UI_Describe describe;

	public UI_Item_Slot main_item_slot;
	public UI_Item_Slot[] part_items_slot;
	public UI_Item_Slot[] product_items_slot;

	string[] product_items_list;

		
	public string item_id;

	
	int current_page = 0, max_pages = 1;

	// Use this for initialization
	void Start () 
	{
		Clear();
		// disenable 
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Clear()
	{
		product_items_list = null;
		main_item_slot.Clear();
		foreach (UI_Item_Slot slot in part_items_slot)
		{
			slot.Clear();
		}
		Clear_Product_Slots();
	}

	public void Clear_Product_Slots()
	{
		foreach (UI_Item_Slot slot in product_items_slot)
		{
			slot.Clear();
		}
	}

	public void Init(string _item_id)
	{
		Clear();
		
		// enable it self
		gameObject.SetActive(true);
		// disenable describe
		describe.Clear();
		describe.gameObject.SetActive(false);

		// get the main item from item manager
		Item item = Global_Item_Manager.Get_Item(_item_id);
		if (item == null)
			return;
		
		item_id = _item_id;
		main_item_slot.Init_Item(item_id,Global_Item_Manager.Get_Item(item_id).item_name,false,false);
		// delegate
		main_item_slot.uiSlotOnClick = Item_Slot_OnClick_Main_Item_Slot;

		// get the list of the parts
		Update_Parts_Slot();


		// get the list of product
		product_items_list = item.Get_Products_ID();
		Update_Product_Slot();


		// calculate the pages
		int count = product_items_list.Length;
		max_pages = Mathf.CeilToInt( count *1.0f / product_items_slot.Length);
		
		if (product_items_list.Length == 0 || max_pages == 0)
			max_pages = 1;
		current_page = 0;

		Update_Pages();
		
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Describe Recipe got " + max_pages + " pages." );
		}

		// assign other values
		frame1.color = main_item_slot.top.color;
		frame2.color = main_item_slot.top.color;
		if (tato1)
			tato1.color = new Color(main_item_slot.top.color.r,
			                        main_item_slot.top.color.g,
			                        main_item_slot.top.color.b,
			                        0.2f);
		if (tato2)
			tato2.color = new Color(main_item_slot.top.color.r,
			                        main_item_slot.top.color.g,
			                        main_item_slot.top.color.b,
			                        0.2f);


		
		// self's frame
		GetComponent<Image>().color = main_item_slot.top.color;

	}

	public void Next()
	{
		current_page = (current_page + 1) % max_pages;
		Update_Product_Slot();
		Update_Pages();
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Describe Recipe page change to #" + (current_page+1));
		}
	}
	
	public void Prev()
	{
		current_page = (current_page - 1 + max_pages) % max_pages;
		Update_Product_Slot();
		Update_Pages();
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Describe Recipe page change to #" + (current_page+1));
		}
	}

	void Update_Pages()
	{
		page.text = (current_page + 1) + " / " + max_pages;
	}

	public void Update_Parts_Slot()
	{
		Recipe recipe = Global_Recipe_Manager.Get_Recipe(item_id);
		if (recipe != null)
		{
			int i =0;
			foreach (Recipe.Parts part in recipe.parts)
			{
				if (i >= part_items_slot.Length)
					break;

				part_items_slot[i].Init_Item(part.item_id, Global_Item_Manager.Get_Item(part.item_id).item_name +"\nx"+ part.number,
				                        false,false);
				// delegate
				part_items_slot[i].uiSlotOnClick = Item_Slot_OnClick_Recipes;
				i++;
			}
		}
	}


	public void Update_Product_Slot()
	{
		if (product_items_list == null || product_items_list.Length == 0)
		{
			return;
		}

		// fix index
		int startIndex = product_items_slot.Length * current_page;
		for (int i=0; 
		     i < product_items_slot.Length && i+startIndex < product_items_list.Length;
		     i++)
		{
			if (Global_Tools.gameSetting_debug)
			{
				Debug.Log(" UI Describe Recipe Add a product slot [" + product_items_list[i+startIndex] + " - "
				          + Global_Item_Manager.Get_Item(product_items_list[i+startIndex]).item_name);
			}

			product_items_slot[i].Init_Item(product_items_list[i+startIndex],
			                           Global_Item_Manager.Get_Item(product_items_list[i+startIndex]).item_name,
			                           false,false);
			// delegate
			product_items_slot[i].uiSlotOnClick = Item_Slot_OnClick_Recipes;
		}
	}

	// show the item info
	public void Item_Slot_OnClick_Main_Item_Slot(string _item_id)
	{
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Describe Recipe Item_Slot_OnClick_Main_Item_Slot OnClick [" + _item_id + " - " + Global_Item_Manager.Get_Item(_item_id).item_name +"]");
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
		
		// show the describe info 
		describe.gameObject.SetActive(true);
		describe.Init(_item_id);
	}

	// show the describe recipes again
	public void Item_Slot_OnClick_Recipes(string _item_id)
	{
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Describe Recipe Item_Slot_OnClick_Recipes OnClick [" + _item_id + " - " + Global_Item_Manager.Get_Item(_item_id).item_name +"]");
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
		
		// show the recipe info 
		Init(_item_id);
	}
}
