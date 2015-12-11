using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour 
{

    //This script exists to control the GUI. It primarily controls the slider, and triggers the win screen.

    public static bool m_Win;
	[SerializeField] GameObject WinPanel;
    [SerializeField] Slider mySlider;
	[SerializeField] bool GettingCloser;
	[SerializeField] GameObject player;
	Vector3 end = new Vector3(100,0, -10);
	
	void Start ()
    {
		m_Win = false;
	}
	
	void Update ()
    {
		if (transform.position.x >= 250)
		{
			m_Win = true;
		}

		mySlider.value = (100 -(int)Vector3.Distance(transform.position, end))*0.01f;

		if ((int)Vector3.Distance (transform.position, end) <= 0) 
		{
			Time.timeScale = 0;
			WinPanel.SetActive(true);
		}
	}
}