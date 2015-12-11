using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{

    //This script exists to set the player camera within the game level

	[SerializeField] GameObject m_Player;

	void Start () 
	{
		m_Player = GameObject.FindGameObjectWithTag ("Player"); //This finds the player by its tag
	}

	void Update () 
	{ //This moves the camera 6 units in front of the Player while maintaining the same y and z position
		gameObject.transform.position = new Vector3 (m_Player.transform.position.x+6, 0, -10); 
	}
}
//Thanks you for using the Stanley comment and update service