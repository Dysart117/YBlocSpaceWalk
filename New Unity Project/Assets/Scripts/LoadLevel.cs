using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void LevelLoad(int name){
		Application.LoadLevel(name);
		Debug.Log (name);
	}
	public void QuitGame(){
		Application.Quit();
	}
}
