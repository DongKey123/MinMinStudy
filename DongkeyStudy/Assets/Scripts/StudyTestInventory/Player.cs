using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Inventory inventory = new Inventory();

    private void Initialize()
    {
        inventory.OnEquipItem += OnEquipItem;
        inventory.OnUnEquipItem += OnUnEquipItem;
    }

    private void OnUnEquipItem(EquipItem item)
    {
    }

    private void OnEquipItem(EquipItem item)
    {
    }

    
}
