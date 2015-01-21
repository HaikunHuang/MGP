using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item  
{
	public enum TYPE
	{
		None,
		Equipment
	};

	// item type
	public TYPE item_type = TYPE.None;

	// #0	1	2	3	4	5	6	7	8
	// #item_id	中文名字	图表路径	类型（无用）	装备等级	装备颜色 0白色|1绿色|2蓝色|3紫色|4橙色	买	卖	买 by $
	// must include these common variables
	public string item_id ="";
	public string item_name ="";
	public string item_icon_path = "";
	public Texture item_icon;
	public int item_level = 0;
	public int item_color = 0;
	public Color item_cole_value;
	public int item_buy = 0;
	public int item_sell = 0;
	public int item_buy_dollar = 0;


	public Item()
	{

	}

	public void Init()
	{
		// Texture
		if (item_icon_path !="")
		{
			item_icon = Resources.Load<Texture>(item_icon_path);
		}
		if (!item_icon)
		{
			Debug.Log(item_id + " cannot load the icon file.");
		}

		// color
		if (item_color == 0)
		{
			item_cole_value = new Color(1f,1f,1f,0f);
		}
		else if (item_color == 1)
		{
			item_cole_value = new Color(0f,1f,0f,1f);
		}
		else if (item_color == 2)
		{
			item_cole_value = new Color(0f,1f,1f,1f);
		}
		else if (item_color == 3)
		{
			item_cole_value = new Color(1f,0.5f,1f,1f);
		}
		else if (item_color == 4)
		{
			item_cole_value = new Color(1f,0.5f,0f,1f);
		}
	}

	public override string ToString()
	{
		return "";
	}

	public string[] Get_Products_ID()
	{
		List<string> products = new List<string>();
		
		// search all recipes and check if this item is the parts of the others
		string[] allItems = Global_Item_Manager.Get_All_Items();
		foreach(string _item_id in allItems)
		{
			//string[] allRecipe = Global_Recipe_Manager.Get_All_Recipe();
			//foreach (string _recipe_id in allRecipe)
			{
				if (Global_Recipe_Manager.Get_Recipe(_item_id)!=null)
					if (Global_Recipe_Manager.Get_Recipe(_item_id).Is_Apart(item_id))
				{
					products.Add(_item_id);
				}
			}
		}
		
		return products.ToArray();
	}

	public string[] Get_Products_Name()
	{
		List<string> products = new List<string>();
		
		// search all recipes and check if this item is the parts of the others
		string[] allItems = Global_Item_Manager.Get_All_Items();
		foreach(string _item_id in allItems)
		{
			//string[] allRecipe = Global_Recipe_Manager.Get_All_Recipe();
			//foreach (string _recipe_id in allRecipe)
			{
				if (Global_Recipe_Manager.Get_Recipe(_item_id)!=null)
					if (Global_Recipe_Manager.Get_Recipe(_item_id).Is_Apart(item_id))
					{
						products.Add(Global_Item_Manager.Get_Item(_item_id).item_name);
					}
			}
		}
		
		return products.ToArray();
	}

}
