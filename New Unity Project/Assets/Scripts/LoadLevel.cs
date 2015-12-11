using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    //This scripts exists to allow the buttons of the game to work.

	public void LevelLoad(int name)
    {   //This loads a lever of choice.
		Application.LoadLevel(name);
		Debug.Log (name);
	}
	public void QuitGame()
    {   //This shuts down the game.
		Application.Quit();
	}
}
//Thank you for using the Stanley Comment and Update Service.