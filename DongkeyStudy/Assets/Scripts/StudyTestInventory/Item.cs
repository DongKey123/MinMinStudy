using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class ItemBase 
{
    protected int id;
    public int ID { get { return id; } }
    protected int uid;
    public int UID { get { return uid; } }
}

public enum EEquipType
{
    Weapon,
    Armor,
    Shoes,
    Shield,
    Helmet,
    
    MAX
}

public enum EEquipFlag
{
    NULL = 0x00000000 ,

    Weapon = 0x00000001 << EEquipType.Weapon,
    Armor = 0x00000001 << EEquipType.Armor,
    Shoes = 0x00000001 << EEquipType.Shoes,
    Shield = 0x00000001 << EEquipType.Shield,
    Helmet = 0x00000001 << EEquipType.Helmet,

    MAX = 0x00000001 << EEquipType.MAX
}

public class EquipItem : ItemBase
{
    protected EEquipType itemType;
    public EEquipType ItemType { get { return itemType; } }
    protected EEquipFlag itemFlag;
    public EEquipFlag ItemFlag { get { return itemFlag; } }

    public virtual void Equip() { }
    public virtual void UnEquip() { }

    public EquipItem(int _id, int _uid)
    {
        this.id = _id;
        this.uid = _uid;
    }
}

public class Weapon : EquipItem
{
    public Weapon(int _id, int _uid) : base (_id,_uid)
    {
        itemType = EEquipType.Weapon;
        itemFlag = EEquipFlag.Weapon;
    }

    public override void Equip()
    {
        base.Equip();
    }

    public override void UnEquip()
    {
        base.UnEquip();
    }
}

