using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class Tutorial_UI_Simaple_Test : MonoBehaviour
{
	public Text myText;
	public Scrollbar myScrollBar;
	int iCount = 0;

	IniFile iniFile;

	Texture tr;
	public RawImage raw;

	bool isDownLoad_Done = false;


	// Use this for initialization
	void Start ()
	{
		// if 2nd parameter is true, than show all the detail when it parsing the data.
		IniFile gameSetting = new IniFile("GameSetting",false);

		// jump to the specify selctor
		gameSetting.goTo("Setting");
		// read the data by specify name
		Debug.Log("debug = " + gameSetting.GetValue_Int("debug"));
		// jump to the specify selctor
		gameSetting.goTo("version");
		// read the data by specify name
		Debug.Log("var = " + gameSetting.GetValue_Float("var"));


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
