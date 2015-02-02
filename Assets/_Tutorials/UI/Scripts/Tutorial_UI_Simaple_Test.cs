using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class Tutorial_UI_Simaple_Test : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		string[] str = {"1"};

		List<string> list = new List<string>(str);

		list.Add("2");
		list.Add("3");

		str = list.ToArray();

		foreach(string s in str)
		{
			Debug.Log(s);
		}

	}


	void Update()
	{

	}
		
	public void Click_function ()
	{

	}

	public void Save_Function()
	{
	
	}

	public void Load_Function()
	{
	

	}


	
}
