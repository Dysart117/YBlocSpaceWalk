using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private float xPosition, yPosition;
	public Vector3 finalPoint;
	public static bool gameOver;
	[SerializeField] bool m_EndJump;
	public GameObject LosePanel;
	public bool falling;
	public bool hopping;
	public Sprite[] yblocSprites = new Sprite[4];
	public GameObject trail;
	public GameObject ybloc;
	private Vector3 gravity;
	private Vector3 rocketPower;// = new Vector3(2,5,0);
	private Vector3 groundReturn = new Vector3(-1,0,0);
	AudioSource audio;
	void Start()
	{
		trail = GameObject.Find ("Smoke Trail");
		gravity = new Vector3(-1, 0, 0);
		rocketPower = new Vector3(1,2,0);
		gameOver = false;
		audio = GetComponent<AudioSource>();
	}
	void Update()
	{
		if(gameOver || HUD.m_Win){}
		else
		{
			Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
			if(m_EndJump)
			{
				RocketPhysics();
				if(rocketPower.y < 0)
					rocketPower.y = 0;
				if(rocketPower.y > 0)
					rocketPower.y -= 4 * Time.deltaTime;
				if(rocketPower.y == 0)
				{
					m_EndJump = false;
					falling = true;
					gravity.y = 0;
				}
			}
			if(Input.GetMouseButtonUp(0) && !m_EndJump && !falling)
			{
				m_EndJump = true;
				audio.Stop();
			}
			if(Input.GetMouseButtonDown(0) && hopping)
			{
				falling = false;
				m_EndJump = false;
				hopping = false;
				StopCoroutine("Hop");
				audio.Play();
			}
			if((Input.GetMouseButton(0) && !m_EndJump && !falling))// || Input.GetMouseButton(0) && hopping)
			{
				rocketPower.y = 2;
				RocketPhysics();
			}
			else if(transform.position.y > -0.67f && !m_EndJump)
			{
				audio.Stop ();
				GravityPhysics ();
			}
			if (transform.position.y < -0.67f)
				transform.position = new Vector3 (transform.position.x, -0.67f, transform.position.z);
			if(transform.position.y == -0.67f)
			{
				m_EndJump = false;
				falling = false;
				Grounded();
			}
		}
	}
	void Grounded()
	{
		ybloc.GetComponent<SpriteRenderer>().sprite = yblocSprites [2];
			transform.position -= groundReturn * Time.deltaTime;
		StartCoroutine ("Hop");
	}
	void GravityPhysics()
	{
		ybloc.GetComponent<SpriteRenderer>().sprite = yblocSprites [0];
		if(gravity.y < 1.6f)
			gravity.y += 0.6f * Time.deltaTime;
		transform.position -= gravity * Time.deltaTime;
	}
	void RocketPhysics()
	{
		ybloc.GetComponent<SpriteRenderer>().sprite = yblocSprites [3];
		transform.position += rocketPower * Time.deltaTime;
		if(transform.position.y > 3 && !m_EndJump)
		{
			m_EndJump = true;
		}
	}
	void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.transform.tag == "crater")
		{
			LosePanel.SetActive (true);
			Debug.Log("Hit");
		}
	}
	IEnumerator Hop()
	{
		m_EndJump = true;
        hopping = true;
		rocketPower.y = 2;
		RocketPhysics();
		yield return new WaitForSeconds(3.0f);
		StopCoroutine("Hop");
	}
}
