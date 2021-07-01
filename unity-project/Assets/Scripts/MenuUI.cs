using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;
    public GameObject weaponSelectPanel;
    public float transitionSpeed = 1;

    UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void onPlay()
    {
        uiManager.leanTweenMenuPanel(mainMenuPanel,levelSelectPanel, -1 ,1/transitionSpeed);
    }
    public void levelBack()
    {
        uiManager.leanTweenMenuPanel(levelSelectPanel, mainMenuPanel, 1 , 1/transitionSpeed);
    }
    
    public void onlevelSelect(int levelNo)
    {
        uiManager.leanTweenMenuPanel(levelSelectPanel, weaponSelectPanel, -1, 1 / transitionSpeed);
        GameInfo.levelindex = levelNo;
    }

    public void weaponBack()
    {
        uiManager.leanTweenMenuPanel(weaponSelectPanel, levelSelectPanel, 1, 1 / transitionSpeed);
    }

    public void playGame()
    {
        SceneManager.LoadScene(GameInfo.levelindex);
    }
}


