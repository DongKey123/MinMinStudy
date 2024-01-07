using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController2
{
    public delegate void ItemDelegate(BaseItem2 _item);
    public ItemDelegate equipDele;
    public ItemDelegate unEquipDele;

    private List<BaseItem2> itemList = new List<BaseItem2>();
    private BaseItem2[] equipItemArr = new BaseItem2[]
        {
            new Weapon2(EEquipPart.WEAPON, EEquipPartFlags.WEAPON, 0, 0),
            new Shield2(EEquipPart.SHEILD, EEquipPartFlags.SHEILD, 1, 1),
            new Helmet2(EEquipPart.HELMET, EEquipPartFlags.HELMET, 2, 2),
            new Armor2(EEquipPart.ARMOR, EEquipPartFlags.ARMOR, 3, 3),
            new Shoes2(EEquipPart.SHOES, EEquipPartFlags.SHOES, 4, 4)
        };

    private EEquipPartFlags equipFlags = 0;

    public void DoubleClickItem(BaseItem2 _item)
    {
        int flagsResult = (int)(equipFlags & _item.GetItemFlag);

        if (flagsResult == 0) //해당 부위 미장착중
        {
            EquipItem(_item);
        }
        else if (flagsResult >= 1)// 해당 부위 장착중
        {
            if (equipItemArr[(int)_item.GetItemPart].GetItemUID == _item.GetItemUID)
            {
                UnEquipItem(_item);
            }
            else
            {
                SwapItem(_item);
            }
        }
    }

    private void EquipItem(BaseItem2 _item)
    {
        int equipPart = (int)_item.GetItemPart;

        itemList.Remove(_item);
        equipFlags |= _item.GetItemFlag;
        equipItemArr[equipPart] = _item;

        equipDele.Invoke(_item);
        _item.EquipItem();
    }

    private void UnEquipItem(BaseItem2 _item)
    {
        int equipPart = (int)_item.GetItemPart;

        itemList.Add(_item);
        equipFlags ^= _item.GetItemFlag;
        equipItemArr[equipPart] = null;

        unEquipDele.Invoke(_item);
        _item.UnEquipItem();
    }

    private void SwapItem(BaseItem2 _item)
    {
        int equipPart = (int)_item.GetItemPart;
        BaseItem2 curEquipItem = equipItemArr[equipPart];

        itemList.Add(curEquipItem);
        equipFlags ^= _item.GetItemFlag;
        equipItemArr[equipPart] = null;
        curEquipItem.UnEquipItem();

        unEquipDele.Invoke(_item);

        itemList.Remove(_item);
        equipFlags |= _item.GetItemFlag;
        equipItemArr[equipPart] = _item;
        _item.EquipItem();

        equipDele.Invoke(_item);
    }
}