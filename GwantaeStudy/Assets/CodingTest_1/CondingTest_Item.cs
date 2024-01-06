
// 문제
// player의 장비 아이템을 장착 / 해제 / 교체 / 하는 코드를 작성하시오
// [ 디아블로 시리즈의 장비 장착 시스템 참고 ]
// player / inventory class 는 필수적으로 존재해야 한다
// 장비 아이템에는 weapon/armor/shoes/shield/helmet 이 존재한다
namespace codingTest_1
{
    public enum ItemBitFlag
    {
        weapon = 0x00 << 0,
        armor = 0x00 << 1,
        shoes = 0x00 << 2,
        shield = 0x00 << 3,
        helmat = 0x00 << 4
    }
    public enum ItemType
    {
        weapon,
        armor,
        shoes,
        shield,
        helmat
    }


    public abstract class Item
    {
        public ItemBitFlag itemBitFlag;
        public ItemType itemType;
        public Item(ItemBitFlag _itemBitFlag, ItemType _itmeType)
        {
            itemBitFlag = _itemBitFlag;
            itemType = _itmeType;
        }
        public abstract ItemBitFlag EquipItem(ItemType _itemType);
        public abstract ItemBitFlag UnequipItem(ItemType _itemType);
    }
    public class Weapon : Item
    {
        public Weapon(ItemBitFlag _itemBitFlag, ItemType _itmeType) : base(_itemBitFlag, _itmeType) { }
        public override ItemBitFlag EquipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }
            return itemBitFlag;
        }

        public override ItemBitFlag UnequipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }
    }
    public class Armor : Item
    {
        public Armor(ItemBitFlag _itemBitFlag, ItemType _itmeType) : base(_itemBitFlag, _itmeType) { }
        public override ItemBitFlag EquipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }

        public override ItemBitFlag UnequipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }
    }
    public class Shoes : Item
    {
        public Shoes(ItemBitFlag _itemBitFlag, ItemType _itmeType) : base(_itemBitFlag, _itmeType) { }
        public override ItemBitFlag EquipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }

        public override ItemBitFlag UnequipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }
    }
    public class Shield : Item
    {
        public Shield(ItemBitFlag _itemBitFlag, ItemType _itmeType) : base(_itemBitFlag, _itmeType) { }
        public override ItemBitFlag EquipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }

        public override ItemBitFlag UnequipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }
    }
    public class Helmat : Item
    {
        public Helmat(ItemBitFlag _itemBitFlag, ItemType _itmeType) : base(_itemBitFlag, _itmeType) { }
        public override ItemBitFlag EquipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }

        public override ItemBitFlag UnequipItem(ItemType _itemType)
        {
            if (itemType != _itemType)
            {
                return 0;
            }

            return itemBitFlag;
        }
    }





    public class Player
    {
        private int itemEquipBitFlag = 0;
        private delegate ItemBitFlag ItemDelegate(ItemType _itemType);
        private ItemDelegate equipItmeDelegate;
        private ItemDelegate unequipItmeDelegate;
        private Item[] playerItems = new Item[] {new Weapon(ItemBitFlag.weapon  ,ItemType.weapon),
                                             new Armor(ItemBitFlag.armor    ,ItemType.armor),
                                             new Shoes(ItemBitFlag.shoes    ,ItemType.shoes),
                                             new Shield(ItemBitFlag.shield  ,ItemType.shield),
                                             new Helmat(ItemBitFlag.helmat  ,ItemType.helmat)};

        public Player()
        {
            int count = playerItems.Length;
            for (int i = 0; i < count; i++)
            {
                equipItmeDelegate += playerItems[i].EquipItem;
                unequipItmeDelegate += playerItems[i].UnequipItem;
            }
        }

        public void InvokeEquipItemDelegate(ItemType _itemType)
        {
            var bitFlag = equipItmeDelegate?.Invoke(_itemType);
            itemEquipBitFlag ^= (int)bitFlag;
        }
        public void InvokeUnquipItemDelegate(ItemType _itemType)
        {
            var bitFlag = unequipItmeDelegate?.Invoke(_itemType);
            itemEquipBitFlag ^= (int)bitFlag;
        }
    }



    public class Inventory
    {
        Player player = new Player();
        public void EquipPlayerItem(ItemType _itemType)
        {
            player.InvokeEquipItemDelegate(_itemType);
        }
        public void UnEquipPlayerItem(ItemType _itemType)
        {
            player.InvokeUnquipItemDelegate(_itemType);
        }
        public void ChangePlayerItem(ItemType _itemType)
        {
            player.InvokeEquipItemDelegate(_itemType);
            player.InvokeUnquipItemDelegate(_itemType);
        }
    }
}

