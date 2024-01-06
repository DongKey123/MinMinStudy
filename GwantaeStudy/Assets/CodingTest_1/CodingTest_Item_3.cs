

// 문제
// player의 장비 아이템을 장착 / 해제 / 교체 / 하는 코드를 작성하시오
// [ 디아블로 시리즈의 장비 장착 시스템 참고 ]
// player / inventory class 는 필수적으로 존재해야 한다
// 장비 아이템에는 weapon/armor/shoes/shield/helmet 이 존재한다

namespace codingTest_3
{
    public enum ItemType
    {
        weapon,
        armor,
        shoes,
        shield,
        helmet
    }
    public enum ItemBitFlag
    {
        none = 0,
        weapon = 0x01 << 0,
        armor  = 0x01 << 1,
        shoes  = 0x01 << 2,
        shield = 0x01 << 3,
        helmet = 0x01 << 4,
    }

    public interface IEquipAble
    {
        public void EquipItem();
        public void UnEquipItem();
        public ItemBitFlag GetItemBitFlag();
    }
    public abstract class Item
    {
        protected bool isEquipItem;
        protected int itemUid;
        protected ItemType itemType;
        protected ItemBitFlag itemBitFlag;
        public abstract ItemType GetItemType();
        public abstract int GetItemUid();
    }
    public class Weapon : Item, IEquipAble
    {
        public Weapon()
        {
            itemType = ItemType.weapon;
            itemBitFlag = ItemBitFlag.weapon;
            isEquipItem = false;
        }
        public void EquipItem()
        {
            isEquipItem = true;
        }
        public void UnEquipItem()
        {
            isEquipItem = false;
        }

        public ItemBitFlag GetItemBitFlag()
        {
            return itemBitFlag;
        }

        public override ItemType GetItemType()
        {
            return itemType;
        }

        public override int GetItemUid()
        {
            return itemUid;
        }

    }
    public class Armor : Item, IEquipAble
    {
        public Armor()
        {
            itemType = ItemType.shoes;
            itemBitFlag = ItemBitFlag.shoes;
            isEquipItem = false;
        }
        public void EquipItem()
        {
            isEquipItem = true;
        }

        public void UnEquipItem()
        {
            isEquipItem = false;
        }

        public ItemBitFlag GetItemBitFlag()
        {
            return itemBitFlag;
        }

        public override ItemType GetItemType()
        {
            return itemType;
        }

        public override int GetItemUid()
        {
            return itemUid;
        }

    }
    public class Shoes : Item, IEquipAble
    {
        public Shoes()
        {
            itemType = ItemType.shoes;
            itemBitFlag = ItemBitFlag.shoes;
            isEquipItem = false;
        }
        public void EquipItem()
        {
            isEquipItem = true;
        }

        public void UnEquipItem()
        {
            isEquipItem = false;
        }

        public ItemBitFlag GetItemBitFlag()
        {
            return itemBitFlag;
        }

        public override ItemType GetItemType()
        {
            return itemType;
        }

        public override int GetItemUid()
        {
            return itemUid;
        }

    }
    public class Shield : Item, IEquipAble
    {
        public Shield()
        {
            itemType = ItemType.shield;
            itemBitFlag = ItemBitFlag.shield;
            isEquipItem = false;
        }
        public void EquipItem()
        {
            isEquipItem = true;
        }

        public void UnEquipItem()
        {
            isEquipItem = false;
        }

        public ItemBitFlag GetItemBitFlag()
        {
            return itemBitFlag;
        }

        public override ItemType GetItemType()
        {
            return itemType;
        }

        public override int GetItemUid()
        {
            return itemUid;
        }

    }
    public class Helmet : Item, IEquipAble
    {
        public Helmet()
        {
            itemType = ItemType.helmet;
            itemBitFlag = ItemBitFlag.helmet;
            isEquipItem = false;
        }
        public void EquipItem()
        {
            isEquipItem = true;
        }

        public void UnEquipItem()
        {
            isEquipItem = false;
        }

        public ItemBitFlag GetItemBitFlag()
        {
            return itemBitFlag;
        }

        public override ItemType GetItemType()
        {
            return itemType;
        }

        public override int GetItemUid()
        {
            return itemUid;
        }

    }

    public class Inventory
    {
        public IEquipAble[] EquipItemArr = new IEquipAble[]
        {
            new Weapon(),
            new Armor(),
            new Shoes(),
            new Shield(),
            new Helmet()
        };



        public delegate void ItemEventDelegate(ItemType _itemType);
        public ItemEventDelegate EquipItemEvent;
        public ItemEventDelegate UnEquipItemEvnet;
        public int playerEquipItemBitFlag = 0;

        public void InvokeEquipItem(ItemType _itemType)
        {
            EquipItemEvent?.Invoke(_itemType);
            EquipItemArr[(int)_itemType].EquipItem();
            playerEquipItemBitFlag |= (int)EquipItemArr[(int)_itemType].GetItemBitFlag();
        }

        public void InvokeUnEquipItem(ItemType _itemType)
        {
            UnEquipItemEvnet?.Invoke(_itemType);
            EquipItemArr[(int)_itemType].UnEquipItem();
            playerEquipItemBitFlag ^= (int)EquipItemArr[(int)_itemType].GetItemBitFlag();
        }

        public void ChangeItem(ItemType _itemType)
        {
            UnEquipItemEvnet?.Invoke(_itemType);
            EquipItemArr[(int)_itemType].UnEquipItem();
            

            EquipItemEvent?.Invoke(_itemType);
            EquipItemArr[(int)_itemType].EquipItem();

            playerEquipItemBitFlag |= (int)EquipItemArr[(int)_itemType].GetItemBitFlag();
        }
    }

    public class Player
    {
        private Inventory inventory = new Inventory();

        public void Initalize()
        {
            inventory.EquipItemEvent += EquipItem;
            inventory.UnEquipItemEvnet += UnEquipItem;
        }

        private void EquipItem(ItemType _itemType)
        {

        }
        private void UnEquipItem(ItemType _itemType)
        {

        }
    }
    
}