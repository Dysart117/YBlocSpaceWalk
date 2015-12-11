using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

    //This script exists to destroy game objects that are behind the player.

	[SerializeField] int m_Distance;    //This sets how long the items will be kept.

	void Update () 
	{   //This actually physically deletes the gameObject.
		if(transform.position.x < Camera.main.transform.position.x - m_Distance)
		{
			Destroy(gameObject);
		}
	}
}
//Thank you for using the Stanley Comment and Update Service.