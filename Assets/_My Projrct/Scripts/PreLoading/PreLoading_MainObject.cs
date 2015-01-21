using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreLoading_MainObject : MonoBehaviour {

	public Text showInfo;
	// Use this for initialization
	void Start () 
	{
		Global_Tools.UpToDate();

		showInfo.text = "Loading...";
		// show some tips here
		StartCoroutine(PreLoad());
	}

	void Update()
	{

	}

	IEnumerator PreLoad()
	{
		// preload here
		if (Global_Tools.gameSetting_debug)
			Debug.Log("Preloading now:");

		yield return null;


		// gotot the next stage
		Global_Tools.Goto_Next_Stage_from_PreLoading();
	}
}
