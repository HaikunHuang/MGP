using UnityEngine;
using UnityEngine.UI;  
using System.Collections;  
using System;  
using System.Net;  
using System.Net.Mail;  
using System.Net.Security;  
using System.Security.Cryptography.X509Certificates;  

public class Debug_MainObject : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		Global_Tools.UpToDate();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Button_Function_BackToMainMenu()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.mainMenu_Stage);
	}

	public void Button_Function_ItemViewer()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.itemViewer_Stage);
	}

	public void Button_Function_Send_Test_Email()
	{
		StartCoroutine(Send_Test_Email());
	}

	public void Button_Clear_User_Info()
	{
		if (ES2.Exists(Global_Tools.userInfo_Path))
		{
			ES2.Delete(Global_Tools.userInfo_Path);
			if (Global_Tools.gameSetting_debug)
			{
				Debug.Log("User info deleted.");
			}
		}
	}

	public void Button_Function_CharacterViewer()
	{
		Global_Tools.Goto_Next_Stage_via_PreLoading(Global_Tools.characterViewer_Stage);
	}

	IEnumerator Send_Test_Email()
	{
		/*
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Application.CaptureScreenshot(Application.persistentDataPath + "/Send_Test_Email.png");
			if (Global_Tools.gameSetting_debug)
			{
				Debug.Log("Capture a Screen shot.");
				Debug.Log("The Screen Shot is saved to "+ Application.persistentDataPath + "/Send_Test_Email.png" );
			}
		}
		else
		{
			Application.CaptureScreenshot("Send_Test_Email.png");
			if (Global_Tools.gameSetting_debug)
			{
				Debug.Log("Capture a Screen shot.");
				Debug.Log("The Screen Shot is saved to Send_Test_Email.png" );
			}
		}
		*/

		// yield return new WaitForSeconds(3f);
		yield return null;

		MailMessage mail = new MailMessage();  
		
		mail.From = new MailAddress(Global_Tools.gameSetting_emailFrom);  
		mail.To.Add(Global_Tools.gameSetting_emailTo);  
		mail.Subject = "Mobile Game Project Test Email";  
		mail.Body = "Button_Function_Send_Test_Email";  
		// mail.Attachments.Add(new Attachment("Send_Test_Email.png")); 
		SmtpClient smtpServer = new SmtpClient(Global_Tools.gameSetting_emailSmtp);  
		smtpServer.Port = 587;  
		smtpServer.Credentials = new System.Net.NetworkCredential(Global_Tools.gameSetting_emailFrom, Global_Tools.gameSetting_emailFromPSW) as ICredentialsByHost;  
		smtpServer.EnableSsl = true;  
		ServicePointManager.ServerCertificateValidationCallback =  
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)  
		{ return true; };  

		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log("Sending a Email \nFrom: " + mail.From.ToString() + "\nTo: "+ mail.To.ToString() +"\nSubject: " 
			          + mail.Subject + "\nBody: " + mail.Body+ "\n" );
		}
		yield return null;

		smtpServer.Send(mail);  

		if (Global_Tools.gameSetting_debug)
		{
			Debug.Log("Email has benn sent." );
		}
		yield return null;
	}
}
