using UnityEngine;
using System.Collections;

public class ItemViewer_MainObject : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Global_Tools.UpToDate();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Button_Function_BackToPreviousStage()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.debug_Stage);
	}
}


