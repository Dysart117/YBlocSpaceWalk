using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    //This script exists to allow the player to move.

    [SerializeField] static bool m_GameOver;
	[SerializeField] bool m_EndJump;
	[SerializeField] GameObject m_LosePanel;
	[SerializeField] bool m_Falling;
	[SerializeField] bool m_Hopping;
	[SerializeField] Sprite[] m_YBlockSprites = new Sprite[4];
	[SerializeField] GameObject m_Trail;
	[SerializeField] GameObject m_YBloc;
	Vector3 gravity;
	Vector3 rocketPower;// = new Vector3(2,5,0);
	Vector3 groundReturn = new Vector3(-1,0,0);
	AudioSource audio;

	void Start()
	{
		m_Trail = GameObject.Find ("Smoke Trail");
		gravity = new Vector3(-1, 0, 0);
		rocketPower = new Vector3(1,2,0);
		m_GameOver = false;
		audio = GetComponent<AudioSource>();
	}
	void Update()
	{
		if(m_GameOver || HUD.m_Win){}
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
					m_Falling = true;
					gravity.y = 0;
				}
			}
			if(Input.GetMouseButtonUp(0) && !m_EndJump && !m_Falling)
			{
				m_EndJump = true;
				audio.Stop();
			}
			if(Input.GetMouseButtonDown(0) && m_Hopping)
			{
				m_Falling = false;
				m_EndJump = false;
				m_Hopping = false;
				StopCoroutine("Hop");
				audio.Play();
			}
			if((Input.GetMouseButton(0) && !m_EndJump && !m_Falling))// || Input.GetMouseButton(0) && m_Hopping)
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
				m_Falling = false;
				Grounded();
			}
		}
	}
	void Grounded()
	{
		m_YBloc.GetComponent<SpriteRenderer>().sprite = m_YBlockSprites [2];
			transform.position -= groundReturn * Time.deltaTime;
		StartCoroutine ("Hop");
	}
	void GravityPhysics()
	{
		m_YBloc.GetComponent<SpriteRenderer>().sprite = m_YBlockSprites [0];
		if(gravity.y < 1.6f)
			gravity.y += 0.6f * Time.deltaTime;
		transform.position -= gravity * Time.deltaTime;
	}
	void RocketPhysics()
	{
		m_YBloc.GetComponent<SpriteRenderer>().sprite = m_YBlockSprites [3];
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
			m_LosePanel.SetActive (true);
			Debug.Log("Hit");
		}
	}
	IEnumerator Hop()
	{
		m_EndJump = true;
        m_Hopping = true;
		rocketPower.y = 2;
		RocketPhysics();
		yield return new WaitForSeconds(3.0f);
		StopCoroutine("Hop");
	}
}
