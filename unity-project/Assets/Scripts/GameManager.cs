using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	static GameManager current;

	List<Key> keys;
	Door door;
	CameraUITransition cameraTransition;
	public bool isGameOver;


	void Awake()
	{
		//If a Game Manager exists and this isn't it...
		if (current != null && current != this)
		{
			//...destroy this and exit. There can only be one Game Manager
			Destroy(gameObject);
			return;
		}

		current = this;

		keys = new List<Key>();

		//Persis this object between scene reloads
		DontDestroyOnLoad(gameObject);
	}

	public static void RegisterKey(Key key)
    {
		if(current == null)
        {
			return;
        }
		if(!current.keys.Contains(key))
        {
			current.keys.Add(key);
			Debug.Log("key Resistered");
        }

		// UI update here

    }

	public static void RegisterDoor(Door door)
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//Record the door reference
		current.door = door;
	}

	public static void RegisterCameraTransition(CameraUITransition fader)
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//Record the scene fader reference
		current.cameraTransition = fader;
	}

	public static void PlayerWon()
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//The game is now over
		current.isGameOver = true;
		GameInfo.MenuUIstate = menuState.level;
		SceneManager.LoadScene(0);
		//Tell UI Manager to show the game over text and tell the Audio Manager to play
		//game over audio
	//	UIManager.DisplayGameOverText();
	//	AudioManager.PlayWonAudio();
	}

	public static void PlayerDied()
    {
		SceneManager.LoadScene(1);
		current.keys.Clear();
    }

	public static void PlayCameraTranstion()
    {
		current.cameraTransition.FadeSceneOut();
    }

	public static void PlayerGrabbedKey(Key key)
    {
		if (current == null)
			return;

		if (!current.keys.Contains(key))
			return;

		current.keys.Remove(key);

		Debug.Log("key removed");

		if (current.keys.Count == 0)
        {
			current.door.Open();
		}
    }

    private void Start()
    {

    }
}
