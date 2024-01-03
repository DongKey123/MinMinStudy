using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    public Action<EquipItem> OnEquipItem;
    public Action<EquipItem> OnUnEquipItem;

    //Todo: ItemManager에서 관리
    private EquipItem[] curEquipItems = new EquipItem[(int)EEquipType.MAX];
    private EEquipFlag curEquipItemFlag = EEquipFlag.NULL;

    public void EquipItem(EquipItem item)
    {
        int itemTypeIndex = (int)item.ItemType;

        //Todo: 기획단계에서 아이템이 장착되어 있다면 교체로 진행 할건지
        bool isEquipItem = IsEquipItem(item);
        if (isEquipItem == true)
        {
            // 이미 장착할려는 부위 아이템이 장착되어 있음
            return;
        }

        curEquipItemFlag = curEquipItemFlag | item.ItemFlag;

        curEquipItems[(int)item.ItemType] = item;
        item.Equip();
        OnEquipItem?.Invoke(item);
    }

    public void UnEquipItem(EquipItem item)
    {

        //Todo: 기획단계에서 아이템이 장착되어 있지 않다면 어떻게 처리할지
        bool isEquipItem = IsEquipItem(item);
        if (isEquipItem == false)
        {
            // 장착 상태가 아님
            return;
        }

        curEquipItemFlag = (curEquipItemFlag ^ item.ItemFlag);

        curEquipItems[(int)item.ItemType] = null;
        item.UnEquip();
        OnUnEquipItem?.Invoke(item);
    }

    public void SwapItem(EquipItem item)
    {
        bool isEquipItem = IsEquipItem(item);
        if (isEquipItem == false)
        {
            // 장착 상태가 아님
            return;
        }

        EquipItem prevEquipItem = curEquipItems[(int)item.ItemType];
        prevEquipItem.UnEquip();
        OnUnEquipItem?.Invoke(prevEquipItem);


        curEquipItems[(int)item.ItemType] = item;
        item.Equip();
        OnEquipItem?.Invoke(item);
    }
    
    private bool IsEquipItem(EquipItem equipItem)
    {
        bool isEquipItem = (curEquipItemFlag & equipItem.ItemFlag) != EEquipFlag.NULL;
        return isEquipItem;
    }
}
