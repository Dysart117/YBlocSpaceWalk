using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour 
{
    //This script exists to manage the music so that it can play through scenes.

    static MusicManager m_Instance; //This saves the music.
	
	public static MusicManager Instance
	{
		get
		{
            if (m_Instance == null)
            {   //This tells unity not to destroy the music while loading the next scene.
                m_Instance = GameObject.FindObjectOfType<MusicManager>();
                DontDestroyOnLoad(m_Instance.gameObject);
            }
			return m_Instance;
		}
	}
	
	void Awake() 
	{
		if(m_Instance == null)
		{   //If the music already exists dont make another.
			m_Instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{   //If another instance of the music exists make sure that you delete it.
            if (this != m_Instance)
            {
                Destroy(this.gameObject);
            }
		}
	}
}
//Thank you for using the Stanley Comment and Update Service.