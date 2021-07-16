using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum menuState
{
    main,
    level,
    weapon
}
public class MenuUI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;
    public GameObject weaponSelectPanel;
    public float transitionSpeed = 1;

    UIManager uiManager;

    Vector3 uiActivePos = new Vector3(0,0,0);
    Vector3 uiDeactivepositive = new Vector3(2000,0,0);
    Vector3 uiDeactiveNegative = new Vector3(-2000, 0, 0);

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        setMenuState(GameInfo.MenuUIstate);
    }
    
    public void setMenuState(menuState state)
    {
        switch (state)
        {
            case menuState.main:
                mainMenuPanel.GetComponent<RectTransform>().anchoredPosition = uiActivePos;
                levelSelectPanel.GetComponent<RectTransform>().anchoredPosition = uiDeactivepositive;
                weaponSelectPanel.GetComponent<RectTransform>().anchoredPosition = uiDeactivepositive;
                break;
            case menuState.level:
                mainMenuPanel.GetComponent<RectTransform>().anchoredPosition = uiDeactiveNegative;
                levelSelectPanel.GetComponent<RectTransform>().anchoredPosition = uiActivePos;
                weaponSelectPanel.GetComponent<RectTransform>().anchoredPosition = uiDeactivepositive;
                break;
            case menuState.weapon:
                mainMenuPanel.GetComponent<RectTransform>().anchoredPosition = uiDeactiveNegative;
                levelSelectPanel.GetComponent<RectTransform>().anchoredPosition = uiDeactiveNegative;
                weaponSelectPanel.GetComponent<RectTransform>().anchoredPosition = uiActivePos;
                break;
            default:
                break;
        }
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
        gameObject.GetComponentInChildren<WeaponSelectUI>().setWeaponImage();
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


