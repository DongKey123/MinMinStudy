using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2
{
    private InventoryController2 inven = new InventoryController2();

    public void Init()
    {
        inven.equipDele += EquipItem;
        inven.unEquipDele += UnEquipItem;
    }

    private void EquipItem(BaseItem2 _item) { }
    private void UnEquipItem(BaseItem2 _item) { }
}