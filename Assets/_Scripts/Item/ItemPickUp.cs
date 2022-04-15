using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private ItemScript pickupItem;

    [Tooltip("Manual override settings for drop amount, if left at -1, it will use the amount from the scriptable object")]
    [SerializeField]
    int amount = 1;

    [SerializeField] MeshRenderer propMeshRenderer;
    [SerializeField] MeshFilter propMeshFilter;
    [SerializeField] private ItemTable itemTable;

    ItemScript itemInstance;

    // Start is called before the first frame update
    void Start()
    {
        if (itemTable != null)
        {
            int randomItemIndex = (int)Random.Range(0, itemTable.itemTable.Count);
            pickupItem = itemTable.getItemIndex(randomItemIndex);
        }
        InstantiateItem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InstantiateItem()
    {
        itemInstance = Instantiate(pickupItem);
        if (amount > 0)
        {
            itemInstance.SetAmount(amount);
        }
        else
        {
            itemInstance.SetAmount(pickupItem.amountValue);
        }
        ApplyMesh();
    }

    private void ApplyMesh()
    {
        if (propMeshFilter) propMeshFilter.mesh = pickupItem.itemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        if (propMeshRenderer) propMeshRenderer.materials = pickupItem.itemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        InventoryComponent playerInventory = other.GetComponent<InventoryComponent>();
        if (playerInventory)
        {
            playerInventory.AddItem(itemInstance, amount);
        }

        if (itemInstance.itemCategory == ItemCategory.WEAPON)
        {
            WeaponHolder weaponHolder = other.GetComponent<WeaponHolder>();
            WeaponComponent tempWeaponData = itemInstance.itemPrefab.GetComponent<WeaponComponent>();
            if (weaponHolder.weaponAmmoDictionary.ContainsKey(tempWeaponData.weaponStats.weaponType))
            {
                WeaponStats tempWeaponStats = weaponHolder.weaponAmmoDictionary[tempWeaponData.weaponStats.weaponType];
                tempWeaponStats.totalBullets += itemInstance.amountValue;
                weaponHolder.weaponAmmoDictionary[tempWeaponData.weaponStats.weaponType] = tempWeaponStats;
                if (weaponHolder.GetEquippedWeapon != null)
                {
                    weaponHolder.GetEquippedWeapon.weaponStats = weaponHolder.weaponAmmoDictionary[tempWeaponStats.weaponType];
                }

                GameManager.GetInstance().PromptUser("ammo");
            }
            else
            {
                weaponHolder.weaponAmmoDictionary.Add(tempWeaponData.weaponStats.weaponType, tempWeaponData.weaponStats);

                GameManager.GetInstance().PromptUser("ak47");
            }

        }

        if (itemInstance.itemCategory == ItemCategory.EQUIPMENT)
        {
            GameManager.GetInstance().PromptUser("c4");
        }

        Destroy(gameObject);
    }
}