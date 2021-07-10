using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static GameManager current;

	List<Key> keys;
	Door door;


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
