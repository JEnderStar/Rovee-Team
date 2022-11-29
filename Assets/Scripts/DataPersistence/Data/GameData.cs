using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int primaryCurrentAmmo;
    public int primaryCurrentAmmoStorage;
    public int secondaryCurrentAmmo;
    public int secondaryCurrentAmmoStorage;
    public int health;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> pickupsCollected;

    public GameData()
    {
        this.primaryCurrentAmmo = 6;
        this.primaryCurrentAmmoStorage = 60;
        this.secondaryCurrentAmmo = 6;
        this.secondaryCurrentAmmoStorage = 60;
        this.health = 100;
        playerPosition = Vector3.zero;
        pickupsCollected = new SerializableDictionary<string, bool>();
    }
}
