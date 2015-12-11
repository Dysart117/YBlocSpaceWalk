using UnityEngine;
using System.Collections;

public class ItemSpawning : MonoBehaviour 
{
	public GameObject background;
	public GameObject[] cratersObj = new GameObject[4];
	public int crater = 0;
	public float craterx;

	void Start () 
	{
		//GetComponent<playAgainGUI>().enabled = false;
	}

	void Update () 
	{
		//craterx = UnityEngine.Random.Range(transform.position.y + 10, transform.position.y + 10);
		Vector2 positionc = new Vector3(transform.position.x + 15, -2);
		GameObject[] craters = GameObject.FindGameObjectsWithTag("crater");
		for(int m = 0; m < 1; m++)
		{
			if(craters.Length < 4) 
			{
				if(!Physics2D.OverlapCircle(positionc, 4) && positionc.x < 90) 
				{
					crater = UnityEngine.Random.Range(0,3);
					GameObject cr = (GameObject)Instantiate(cratersObj[crater]);
					//positionc.y = cr.transform.position.y;
					cr.transform.position = positionc;
					cr.transform.eulerAngles = (new Vector3(0,0,0));
				}
			}
		}
		Vector3 positionb = new Vector3 (transform.position.x + 20, -4.14f, 0);
		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("background");
		for(int m = 0; m < 1; m++) 
		{
			if(backgrounds.Length < 2)
			{
				if(!Physics.CheckSphere(positionb, 1))
				{
					GameObject bg = (GameObject)Instantiate(background);
					bg.transform.position = positionb;
					bg.transform.eulerAngles = (new Vector3(270,0,0));
				}
			}
		}
	
		if (GameObject.FindGameObjectWithTag ("Player") == transform.position.x >= 250) 
		{    
		
			GetComponent<ItemSpawning>().enabled = false;
		}
	}
}
