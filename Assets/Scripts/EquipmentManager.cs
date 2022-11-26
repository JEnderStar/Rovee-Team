using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquippedWeapon = 0;
    public GameObject currentWeaponObject = null;
    public Transform currentWeaponBarrel = null;

    public Transform WeaponHolderR = null;
    Animator anim;
    Inventory inventory;
    PlayerHUD hud;
    WeaponShooting shooting;

    [SerializeField] Weapon defaultPrimaryWeapon = null;
    [SerializeField] Weapon defaultSecondaryWeapon = null;

    void Start()
    {
        GetReferences();
        InitVariables();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquippedWeapon != 0)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquippedWeapon != 1)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(1));
        }
    }

    public void EquipPrimaryWeapon()
    {
        shooting.TouchReload();
        UnequipWeapon();
        EquipWeapon(inventory.GetItem(0));
    }
    public void EquipSecondaryWeapon()
    {
        shooting.TouchReload();
        UnequipWeapon();
        EquipWeapon(inventory.GetItem(1));
    }
    void EquipWeapon(Weapon weapon)
    {
        currentlyEquippedWeapon = (int)weapon.weaponStyle;
        anim.SetInteger("weaponType", (int)weapon.weaponType);
        hud.UpdateWeaponUI(weapon);
    }

    void UnequipWeapon()
    {
        anim.SetTrigger("unequipWeapon");
    }

    void InitVariables()
    {
        inventory.AddItem(defaultPrimaryWeapon);
        EquipWeapon(inventory.GetItem(0));
        inventory.AddItem(defaultSecondaryWeapon);
        EquipWeapon(inventory.GetItem(1));
    }

    void GetReferences()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
        hud = GetComponent<PlayerHUD>();
        shooting = GetComponent<WeaponShooting>();
    }
}
