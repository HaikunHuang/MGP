using UnityEngine;
using System.Collections;

public class TutorBattle_TestObject : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		// find the player role via tags
		Role_Tags.TAG[] player_tag= {Role_Tags.TAG.Role_Player};
		Role_Tags[] players = Role_Tags.Find_Objects_Belong_Teams(player_tag);
		if (players.Length > 0)
		{
			Role role = players[0].GetComponent<Role>();
			role.Init_Player("skeleton_king_red",Camera.main.transform);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
