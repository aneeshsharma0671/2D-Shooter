// This script is a Manager that controls the UI HUD (deaths, time, and orbs) for the 
// project. All HUD UI commands are issued through the static methods of this class

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
	//This class holds a static reference to itself to ensure that there will only be
	//one in existence. This is often referred to as a "singleton" design pattern. Other
	//scripts access this one through its public static methods
	static UIManager current;
	

	void Awake()
	{
		//If an UIManager exists and it is not this...
		if (current != null && current != this)
		{
			//...destroy this and exit. There can be only one UIManager
			Destroy(gameObject);
			return;
		}

		//This is the current UIManager and it should persist between scene loads
		current = this;
		DontDestroyOnLoad(gameObject);
	}

    public static void onPlay()
    {
		Debug.Log("play");
		GameInfo.weaponindex = 0;
		SceneManager.LoadScene(1);
    }

	public void leanTweenMenuPanel(GameObject panelOut,GameObject panelIn,int direction, float speed)
    {
		if(direction < 0)
        {
			LeanTween.moveX(panelOut.GetComponent<RectTransform>(), -2000, speed);
			LeanTween.moveX(panelIn.GetComponent<RectTransform>(), 0, speed);
		}
		else if(direction >= 0)
        {
			LeanTween.moveX(panelOut.GetComponent<RectTransform>(), 2000, speed);
			LeanTween.moveX(panelIn.GetComponent<RectTransform>(), 0, speed);
		}
	}
}
