using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class Tutorial_UI_Simaple_Test : MonoBehaviour
{
	public Text text;
	public GameObject go;

	// Use this for initialization
	void Start ()
	{
		Input.compass.enabled = true;
	}


	void Update()
	{

		Vector3 v = Input.acceleration;
		text.text = "x: " + v.x + "\ny: " + v.y + "\nz: " + v.z;
		text.text += "\nlocation altitude: " + Input.location.lastData.altitude;
		text.text += "\nlocation latitude: " + Input.location.lastData.latitude;
		text.text += "\nlocation longitude: " + Input.location.lastData.longitude;
		text.text += "\ncompass ha: " + Input.compass.headingAccuracy + "; mh: " + Input.compass.magneticHeading 
						+ "; th: " + Input.compass.trueHeading;
		text.text += "\ncompass: " +Input.compass.rawVector.ToString();

		go.transform.position = Vector3.Lerp(go.transform.position,v *3.0f, 5.0f*Time.deltaTime);
		//go.transform.rotation =  Quaternion.FromToRotation(Vector3.forward,v * 10.0f) ;
		go.transform.rotation = Quaternion.Lerp(go.transform.rotation, Quaternion.Euler(0,Input.compass.trueHeading,0), 
		                                        5.0f*Time.deltaTime);

	}



	
}
