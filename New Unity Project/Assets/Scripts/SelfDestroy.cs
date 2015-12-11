using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public int dist;

	void Update () 
	{
		if(transform.position.x < Camera.main.transform.position.x - dist)
		{
			Destroy(gameObject);
		}
	}
}
