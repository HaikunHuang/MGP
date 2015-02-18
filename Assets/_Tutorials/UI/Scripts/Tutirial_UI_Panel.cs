using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class Tutirial_UI_Panel : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
	bool bHold = false;
	Vector3 lastMousePos;

	// Use this for initialization
	void Start () 
	{
	
		Debug.Log("Tutirial_UI_Panel");
		lastMousePos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bHold)
		{
			Vector3 mouseDel = Input.mousePosition - lastMousePos;

			gameObject.transform.position += mouseDel;
		}

		// update the mouse pos
		lastMousePos = Input.mousePosition;
	}
	



	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("Mouse Click");
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("Mouse Down");
		bHold = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("Mouse Up");
		bHold = false;
	}

}
