using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectUI : MonoBehaviour
{
    public WeaponInfoScriptableObject weaponsInfo;
    public int currentWeaponIndex = 0;
    public Image weaponImage;

    private void Start()
    {
    }

    public void rightImageButton()
    {
        if( (currentWeaponIndex+1) < weaponsInfo.weapons.Count)
        {
            currentWeaponIndex++;
            setWeaponImage();
        }
    }

    public void leftImageButton()
    {
        if (currentWeaponIndex > 0)
        {
            currentWeaponIndex--;
            setWeaponImage();
        }
    }

    public void setWeaponImage()
    {
        weaponImage.sprite = weaponsInfo.weapons[currentWeaponIndex].weaponSprite;
        GameInfo.weaponindex = currentWeaponIndex;
    }

}
