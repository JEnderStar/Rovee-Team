using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] float pickupRange;
    [SerializeField] LayerMask pickupLayer;

    Camera cam;
    Inventory inventory;
    PlayerStats stats;
    WeaponShooting shooting;
    
    void Start()
    {
        GetReferences();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,pickupRange, pickupLayer))
            {
                Debug.Log("Hit: " + hit.transform.name);
                if (hit.transform.GetComponent<ItemObject>().item as Weapon)
                {
                    Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                    inventory.AddItem(newItem);
                    
                }
                else
                {
                    Consumable newItem = hit.transform.GetComponent<ItemObject>().item as Consumable;
                    if(newItem.type == ConsumableType.Food)
                    {
                        //Heal
                        stats.Heal(stats.GetMaxHealth());
                        Debug.Log("HEALING");
                    }
                    else
                    {
                        //Ammo
                        if(inventory.GetItem(0) != null)
                        {
                            shooting.InitAmmo(0, inventory.GetItem(0));
                        }
                        if(inventory.GetItem(1) != null)
                        {
                            shooting.InitAmmo(1, inventory.GetItem(1));
                        }
                        Debug.Log("AMMO");
                    }
                }
                Destroy(hit.transform.gameObject);
            }

        }
    }

    public void TouchPickup()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
        {
            Debug.Log("Hit: " + hit.transform.name);
            if (hit.transform.GetComponent<ItemObject>().item as Weapon)
            {
                Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                inventory.AddItem(newItem);

            }
            else
            {
                Consumable newItem = hit.transform.GetComponent<ItemObject>().item as Consumable;
                if (newItem.type == ConsumableType.Food)
                {
                    //Heal
                    stats.Heal(stats.GetMaxHealth());
                    Debug.Log("HEALING");
                }
                else
                {
                    //Ammo
                    if (inventory.GetItem(0) != null)
                    {
                        shooting.InitAmmo(0, inventory.GetItem(0));
                    }
                    if (inventory.GetItem(1) != null)
                    {
                        shooting.InitAmmo(1, inventory.GetItem(1));
                    }
                    Debug.Log("AMMO");
                }
            }
            Destroy(hit.transform.gameObject);
        }
    }

    void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
        shooting = GetComponent<WeaponShooting>();
    }
}
