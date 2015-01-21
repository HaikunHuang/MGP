using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Recipe 
{
	public class Parts
	{
		public string item_id;
		public int number;

		public Parts(string _item_id,int _number)
		{
			item_id = _item_id;
			number = _number;
		}

	}

	public string item_id;
	//public string item_name;

	//public string part1_id, part2_id, part3_id;
	//public int part1_number, part2_number, part3_number;
	public List<Parts> parts;

	public Recipe()
	{
		parts = new List<Parts>();
	}

	public void Add_Part(string _item_id, int number)
	{
		Parts part= new Parts(_item_id,number);
		parts.Add(part);
	}



	public void Init()
	{
		// assign the item name
		if (!string.IsNullOrEmpty (item_id)) 
		{
			// item_name = Global_Item_Manager.Get_Item (item_id).item_name;
		}

	}

	// show the parts of the recipe and the number
	public override string ToString ()
	{
		string ret = "";

		// ret += "Parts:";
		if (!string.IsNullOrEmpty (item_id)) 
		{
			foreach (Parts part in parts)
			{
				ret += (Global_Item_Manager.Get_Item (part.item_id).item_name + " X"+part.number +"\n");
			}

		}
		return ret;
	}

	// determine if the specially item id is a part of this recipe
	public bool Is_Apart(string _item_id)
	{
		foreach(Parts p in parts)
		{
			if (p.item_id == _item_id)
			{
				return true;
			}
		}
		return false;
	}

}

