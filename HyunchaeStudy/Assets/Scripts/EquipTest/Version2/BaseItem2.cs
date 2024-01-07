using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEquipPartFlags
{
    NONE = 0x00,
    WEAPON = 0x01<< EEquipPart.WEAPON,
    SHEILD = 0x02 << EEquipPart.SHEILD,
    HELMET = 0x03 << EEquipPart.HELMET,
    ARMOR = 0x04 << EEquipPart.ARMOR,
    SHOES = 0x05 << EEquipPart.SHOES
}

public abstract class BaseItem2
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

    public BaseItem2(EEquipPart _equipPart,EEquipPartFlags _partFlag ,int _itemID,int _itemUID)
    {
        equipPart = _equipPart;
        partFlag = _partFlag;
        itemID = _itemID;
        itemUID = _itemUID;
    }

}



public class Helmet2 : BaseItem2
{
    public Helmet2(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Armor2 : BaseItem2
{
    public Armor2(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Shoes2 : BaseItem2
{
    public Shoes2(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Weapon2 : BaseItem2
{
    public Weapon2(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}

public class Shield2 : BaseItem2
{
    public Shield2(EEquipPart _equipPart, EEquipPartFlags _partFlag, int _itemID, int _itemUID)
        : base(_equipPart, _partFlag, _itemID, _itemUID) { }

    public override void EquipItem()
    {
    }

    public override void UnEquipItem()
    {
    }
}