using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour 
{

    //This script exists to control the GUI. It primarily controls the slider, and triggers the win screen.

    public static bool m_Win;   //This bool tells the game if the player has won. It is marked as public because it is needed in the PlayerControls Script.

    //This sets the UI textures.
	[SerializeField] GameObject WinPanel;
    [SerializeField] Slider mySlider;

    //These help run the slider.
	[SerializeField] bool GettingCloser;
	[SerializeField] GameObject player;
	Vector3 end = new Vector3(100,0, -10);
	
	void Start ()
    {
		m_Win = false;  //This is set to false to prevent bugs where you win on activating the game.
	}
	
	void Update ()
    {
		if (transform.position.x >= 250)
		{   //This triggers the win screen.
			m_Win = true;
		}

		mySlider.value = (100 -(int)Vector3.Distance(transform.position, end))*0.01f;   //This manages the slider.

		if ((int)Vector3.Distance (transform.position, end) <= 0) 
		{   //This helps trigger the win screen.
			Time.timeScale = 0;
			WinPanel.SetActive(true);
		}
	}
}
//Thank you for using the Stanley comment and update service.