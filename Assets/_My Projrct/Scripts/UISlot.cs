// haikun huang

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISlot : MonoBehaviour 
{
	public RawImage icon; // item icon
	public Image cover; // item level color
	public Image top; // item level color
	public RawImage mark1,mark2; // some useful mark, TBD
	public Text number; // stack number
	
	public string _id;
	
	// delegate the manager event
	public delegate void UI_Slot_onCliek(string id);
	public UI_Slot_onCliek uiSlotOnClick; // handled by manager

	
	// Use this for initialization
	void Start () 
	{
		// Clear();
		icon.gameObject.SetActive(true);
		cover.gameObject.SetActive(true);
		top.gameObject.SetActive(true);
		mark1.gameObject.SetActive(true);
		mark2.gameObject.SetActive(true);
		number.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	
	// Clear the UI item slot
	public virtual void Clear()
	{
		_id = "";
		icon.texture = null;
		icon.enabled = true;
		icon.color = new Color(0f,0f,0f,0f);
		cover.enabled = true;
		cover.color = new Color(0f,0f,0f,0f);
		top.color = Color.white;
		mark1.enabled = false;
		mark2.enabled = false;
		number.text = "";
		
		// diseable the function of button
		GetComponent<Button>().interactable = false;
		// reset the delegate
		uiSlotOnClick = null;
	}


	
	public virtual void Button_OnClick()
	{
		if (string.IsNullOrEmpty(_id))
			return;
		
		if (Global_Tools.gameSetting_debug)
			Debug.Log("UI Slot Click: [" + _id + "]");
		
		if (uiSlotOnClick != null)
			uiSlotOnClick(_id);
		
	}


}
