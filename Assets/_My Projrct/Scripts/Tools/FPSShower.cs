/// <summary>
/// FPS shower.
/// Haikun Huang
/// 
/// This compontent use to show the fps on the debug mode.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class FPSShower : MonoBehaviour 
{
	private Text fps;

	// Use this for initialization
	void Start () 
	{

		if (!Global_Tools.gameSetting_debug)
		{
			Destroy(gameObject);
		}

		fps = GetComponent<Text>();

		StartCoroutine(FPS ());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	IEnumerator FPS()
	{
		if (fps)
		{
			while(true)
			{
				fps.text = "FPS:" + (int)(1.0f/Time.deltaTime);
				yield return new WaitForSeconds(1.0f);
			}
		}

		yield return null;
	}
}
