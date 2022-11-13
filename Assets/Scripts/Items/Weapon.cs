using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]
public class Weapon : Items
{
    public GameObject prefab;
    public GameObject muzzleFlashParticles;
    public int damage;
    public int magazineSize;
    public int storedAmmo;
    public float fireRate;
    public float range;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;
}

public enum WeaponType { Pistol, Rifle }
public enum WeaponStyle { Primary, Secondary }
