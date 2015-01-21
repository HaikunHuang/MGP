using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class Global_Recipe_Manager 
{
	// recipe data dictionary<item_id,item>
	static Dictionary<string,Recipe> RecipeDict = new Dictionary<string, Recipe>();

	static public void Clear()
	{
		RecipeDict.Clear();
	}

	static public void Updat_Recipe_From_Online(string identifyFile, string onlineFile)
	{
		// save update file to ES2
		// save whole file 
	}
	
	static public void Load_Recipe_From_Memory(string identifyFile)
	{
		// load the whole file from ES2

		// paser by Load_X_From_String()
	}

	static public void Load_Recipe_From_String(string data)
	{
		// read the file line by line
		string[] files = data.Split('\n');
		for(int i=0; i<files.Length; i++)
		{
			string line = files[i].Trim();
			
			if (line.Length == 0)
				continue;
			
			// if any line begin with a char '#', that means this line is a comment line, then skip it
			if (line.ToCharArray()[0] == '#')
				continue;
			
			// parse the string 
			string[] lines = line.Split(',');
			for (int k=0; k<lines.Length; k++)
			{
				lines[k] = lines[k].Trim();
			}
			// not a item
			if (lines[0] == "")
				continue;
			
			if (Global_Tools.gameSetting_debug_detail)
			{
				Debug.Log("Recipe Raw data: " + line);
			}
			
			Recipe recipe = new Recipe();
			
			// read 
			//#Item_id
			recipe.item_id = lines[0];
			// part1	number1	
			if (lines[1].Length > 0)
			{	
				recipe.Add_Part(lines[1],int.Parse(lines[2]));
			}
			//part2	number2	
			if (lines[3].Length > 0)
			{	
				recipe.Add_Part(lines[3],int.Parse(lines[4]));
			}
			//part3	number3
			if (lines[5].Length > 0)
			{	
				recipe.Add_Part(lines[5],int.Parse(lines[6]));
			}
			// init
			recipe.Init();
			
			// add 
			if (RecipeDict.ContainsKey(recipe.item_id))
			{
				// if existed, update it
				RecipeDict[recipe.item_id] = recipe;
			}
			else
			{
				RecipeDict.Add(recipe.item_id,recipe);
			}
			
			if (Global_Tools.gameSetting_debug_detail)
			{
				Debug.Log("Add recipe: " + recipe.item_id + " - " + Global_Item_Manager.Get_Item(recipe.item_id).item_name);
				Debug.Log("["+ Global_Item_Manager.Get_Item(recipe.item_id).item_name + "]\n" +recipe.ToString());
			}
		}
	}

	static public void Load_Recipe_From_Resource(string filePath)
	{
		Object obj = Resources.Load<Object>(filePath);
		
		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log("Load_Recipe Read File:\n" + obj);
		}
		
		Load_Recipe_From_String(obj.ToString());

	}
	
	// Get a recipe by a specialy item id
	static public Recipe Get_Recipe( string item_id )
	{
		Recipe ret_recipe = null;
		
		if (RecipeDict.ContainsKey(item_id))
		{
			ret_recipe = RecipeDict[item_id];
		}
		
		return ret_recipe;
	}
	
	// Get all the id of the recipes
	static public string[] Get_All_Recipe()
	{
		List<string> all_items = new List<string>();
		foreach(string it in RecipeDict.Keys)
		{
			all_items.Add(it);
		}
		return all_items.ToArray();
	}

}
