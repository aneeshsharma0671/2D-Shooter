using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static GameManager current;

	void Awake()
	{
		//If a Game Manager exists and this isn't it...
		if (current != null && current != this)
		{
			//...destroy this and exit. There can only be one Game Manager
			Destroy(gameObject);
			return;
		}

		//Persis this object between scene reloads
		DontDestroyOnLoad(gameObject);
	}
    private void Start()
    {
		Debug.Log(GameInfo.weaponindex);
    }
}
