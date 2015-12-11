using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    //This script exists to run the button system of the entire game

	[SerializeField] Image m_MuteIcon; //Assigns the mute button's icon
	[SerializeField] Sprite m_MusicOnSprite, m_MusicOffSprite; //Assigns the two sprites that m_MuteIcon can have
	[SerializeField] Text m_MuteButtonText; //Assigns the text that will be on the mute button

	void Start ()
	{
		if(AudioListener.volume == 0) //This states that if the music is turned off the mute button will display Un-Mute
		{
			m_MuteIcon.sprite = m_MusicOffSprite;
			m_MuteButtonText.text = "UN-MUTE";
		}
		else //This states that if the music is turned on the mute button will display Mute
        {
			m_MuteIcon.sprite = m_MusicOnSprite;
			m_MuteButtonText.text = "MUTE";
		}
	}

	public void Mute() //This is called by the mute button to mute/un-mute the music
	{   //This checks to see if the music is playing
		if(AudioListener.volume == 1) //If the music is playing then it turns it off and sets the mute button to display un-mute
		{
			AudioListener.volume = 0;
			m_MuteIcon.sprite = m_MusicOffSprite;
			m_MuteButtonText.text = "UN-MUTE";
		}
		else //If the music is not playing then it turns it on and sets the mute button to display mute
        {
			AudioListener.volume = 1;
			m_MuteIcon.sprite = m_MusicOnSprite;
            m_MuteButtonText.text = "MUTE";
		}
	}

	public void LoadLevel1() //This is used by the play button to start the game
	{
		Application.LoadLevel("Level");
	}

	public void Quit() //This is used by the quit button to quit the game
	{
		Application.Quit ();
	}

	public void LoadMainMenu()
	{
		Application.LoadLevel("MainMenu"); //This is used by the main menu button to return to the main menu
	}
}
//Thanks for using the Stanley comment and update service