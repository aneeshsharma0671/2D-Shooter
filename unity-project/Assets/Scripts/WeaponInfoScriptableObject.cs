using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum weaponTypes
{
    pistol,
    rifle,
    shotgun,
}

[System.Serializable]
public class weapondata
{
    public GameObject weaponPrefab;
    public Sprite weaponSprite;
    public GameObject bulletPrefab;
    public weaponTypes weaponType;
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponInfoScriptableObject", order = 1)]
public class WeaponInfoScriptableObject : ScriptableObject
{
    public List<weapondata> weapons;
}
