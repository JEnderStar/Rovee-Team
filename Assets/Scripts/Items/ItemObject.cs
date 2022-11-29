using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, iDataPersistence
{
    public Items item;
    [SerializeField] private string id;
    bool collected;

    [ContextMenu("Generate guid for id")]

    void Start()
    {
        collected = !transform.gameObject.activeInHierarchy;
    }
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.pickupsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.pickupsCollected.ContainsKey(id))
        {
            data.pickupsCollected.Remove(id);
        }
        data.pickupsCollected.Add(id, collected);
    }
}
