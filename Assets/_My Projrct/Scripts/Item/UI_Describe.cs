using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Describe : MonoBehaviour 
{
	public UI_Describe_Recipe describe_recipe;

	public Image frame1,frame2;
	public RawImage tato;
	public UI_Item_Slot item_slot;
	public Text /*text_item_id,*/ text_item_name, text_item_comment;

	public string item_id;



	// Use this for initialization
	void Start () 
	{
		Clear();
		// disenable itself
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Clear()
	{
		item_id = "";
		item_slot.Clear();
		frame1.color = item_slot.top.color;
		frame2.color = item_slot.top.color;
		//text_item_id.text = "";
		//text_item_id.color = item_slot.top.color;
		text_item_name.text = "";
		text_item_name.color = item_slot.top.color;
		text_item_comment.text = "";
		text_item_comment.color = Color.white;
		// self's frame
		GetComponent<Image>().color = item_slot.top.color;
	}

	public void Init(string _item_id)
	{
		Clear();

		// enable it self
		gameObject.SetActive(true);

		// disenable describe_recipe
		describe_recipe.Clear();
		describe_recipe.gameObject.SetActive(false);

		// get the item from item manager
		Item item = Global_Item_Manager.Get_Item(_item_id);
		if (item == null)
			return;

		item_id = _item_id;

		item_slot.Init_Item(item_id,"",false,false);

		// delegate
		if ( item_slot.uiSlotOnClick == null)
			item_slot.uiSlotOnClick = Item_Slot_OnClick;
		else
			item_slot.uiSlotOnClick += Item_Slot_OnClick;

		// assign other values
		frame1.color = item_slot.top.color;
		frame2.color = item_slot.top.color;

		/*
		if (text_item_id)
		{
			text_item_id.text = item.item_id;
			text_item_id.color = item_slot.top.color;
		}
		*/

		text_item_name.text = item.item_name;
		text_item_name.color = item_slot.top.color;

		text_item_comment.text = item.ToString();
		text_item_comment.color = Color.white;

		if (tato)
			tato.color = new Color(item_slot.top.color.r,
			                       item_slot.top.color.g,
			                       item_slot.top.color.b,
			                        0.2f);

		// self's frame
		GetComponent<Image>().color = item_slot.top.color;

	}

	public void Item_Slot_OnClick(string _item_id)
	{
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log(" UI Describe Item Slot OnClick [" + _item_id +" - " + Global_Item_Manager.Get_Item(_item_id).item_name+"]");
			// get the recipe info
			Recipe recipe = Global_Recipe_Manager.Get_Recipe(_item_id);
			if (recipe != null)
			{
				if (Global_Tools.gameSetting_debug_detail)
				{
					//Debug.Log("Recipe Info [" + recipe.item_id + " - " +recipe.item_name +"]\n" + recipe.ToString());
					Debug.Log("Recipe Info [" + recipe.item_id + " - " +Global_Item_Manager.Get_Item (recipe.item_id).item_name +"]\n" + recipe.ToString());
				}
			}
			else
			{
				if (Global_Tools.gameSetting_debug_detail)
				{
					Debug.Log( "Item [" 
					          + _item_id + " - " + Global_Item_Manager.Get_Item(_item_id).item_name 
					          + "] Can not be produced.");
				}
			}
		}
		describe_recipe.gameObject.SetActive(true);
		describe_recipe.Init(_item_id);
	}
}
