// haikun huang


// Role Class
// 定义角色类所需要的组件

// Character  Info 角色信息
// Character Model 角色模型  — 通过外部初始化创建的角色模型信息。
// Character Equipment 角色装备
// Character Skill 角色技能


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Role_Tags))]
public class Role : MonoBehaviour 
{
	// 角色信息
	public Character_Info info{set;get;}

	// 角色装备
	public Character_Equipment equipment{set;get;}

	// 角色模型
	public Character_Model model;

	// 角色技能
	public Character_Skill skill {set;get;}

	// camera
	public Transform cam_trans{set;get;}
	const float cam_trans_pos_speed = 20.0f;
	const float cam_trans_rot_speed = 10.0f;
	const float cam_trans_compass_speed = 10.0f;

	// player controll?
	public bool player_controll {set;get;}



	void Start()
	{


	}
	
	// Init
	public void Init_NPC(string char_id)
	{
		if (gameObject.GetComponent<Character_Info>() == null)
			gameObject.AddComponent<Character_Info>();
		info = gameObject.GetComponent<Character_Info>();
		
		if (gameObject.GetComponent<Character_Equipment>() == null)
			gameObject.AddComponent<Character_Equipment>();
		equipment = gameObject.GetComponent<Character_Equipment>();
		
		if (gameObject.GetComponent<Character_Skill>() == null)
			gameObject.AddComponent<Character_Skill>();
		skill = gameObject.GetComponent<Character_Skill>();


		// 角色信息
		// info = new Character_Info();
		info.Init(char_id);


		// 角色装备
		// equipment = new Character_Equipment();

		// 角色模型
		// model = _model;
		if (model == null)
		{
			// create a model via char_id

			GameObject go 
				= Instantiate (
				Resources.Load<GameObject>(Global_Character_Base_Info_Manager.Get(char_id).character_model_path)
				) 
				as GameObject;
			model = go.GetComponent<Character_Model>();
		}
		model.gameObject.transform.position = gameObject.transform.position;
		model.gameObject.transform.parent = gameObject.transform;


		// 角色技能, load the skill via character base info.

		// set player controll to false
		player_controll = false;

	}

	void Update()
	{
		// player rotate via the compass
		if (player_controll)
		{
			Rotate_via_Compass();
		}
	}


	void LateUpdate()
	{
		// update the camera
		if (cam_trans)
		{
			cam_trans.position = Vector3.Lerp(cam_trans.position, model.player_camera_trans.position,
			                                  cam_trans_pos_speed * Time.deltaTime);

			//cam_trans.position = model.player_camera_trans.position;
			cam_trans.rotation = Quaternion.Lerp(cam_trans.rotation, model.player_camera_trans.rotation,
			                                    cam_trans_rot_speed * Time.deltaTime);

		}
	}

	void Rotate_via_Compass()
	{
		transform.rotation = 
			Quaternion.Lerp(
				transform.rotation,
				Quaternion.Euler(0,
			                 (Input.compass.trueHeading - Global_Tools.compass_default_trueHeading),
			                 0),
				cam_trans_compass_speed * Time.deltaTime);
	}

	public void Init_Player(string char_id, Transform _cam_trans)
	{
		Init_NPC(char_id);
		// attach the camera
		cam_trans = _cam_trans;
		cam_trans.position = model.player_camera_trans.position;
		cam_trans.rotation = model.player_camera_trans.rotation;
		// cam_trans.parent = model.player_camera_trans;
		player_controll = true;
		// set the compass default trueHeading
		Global_Tools.compass_default_trueHeading = Input.compass.trueHeading;

	}


}
