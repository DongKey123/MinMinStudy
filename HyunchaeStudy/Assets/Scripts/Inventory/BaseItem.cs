using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EEquipPart
{
    WEAPON = 0,
    SHEILD = 1,
    HELMET = 2,
    ARMOR = 3,
    SHOES = 4,
    END = 5
}


public abstract class BaseItem
{
    protected EEquipPartFlags partFlag;
    protected EEquipPart equipPart;

    protected int itemID;
    protected int itemUID;

    public abstract void EquipItem();
    public abstract void UnEquipItem();

    public EEquipPartFlags GetItemFlag => partFlag;
    public EEquipPart GetItemPart => equipPart;
    public int GetItemID => itemID;
    public int GetItemUID => itemUID;

    public BaseItem(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
    {
        equipPart = _equipPart;
        partFlag = _partFlag;
        itemID = _itemID;
        itemUID = _itemUID;
    }

}



public class Helmet : BaseItem
{
    public Helmet(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Armor : BaseItem2
{
    public Armor(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Shoes : BaseItem
{
    public Shoes(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Weapon : BaseItem
{
    public Weapon(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Shield : BaseItem
{
    public Shield(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}