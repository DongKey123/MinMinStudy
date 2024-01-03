

// 문제
// player의 장비 아이템을 장착 / 해제 / 교체 / 하는 코드를 작성하시오
// [ 디아블로 시리즈의 장비 장착 시스템 참고 ]
// player / inventory class 는 필수적으로 존재해야 한다
// 장비 아이템에는 weapon/armor/shoes/shield/helmet 이 존재한다


namespace codingTest_2
{
    public enum EquipItemType
    {
        weapon,
        armor,
        shoes,
        shield,
        helmet
    }
    public enum EquipItemBitFlag
    {
        weapon = 0x01 << 0,
        armor = 0x01 << 1,
        shoes = 0x01 << 2,
        shield = 0x01 << 3,
        helmet = 0x01 << 4,
    }

    public abstract class EquipItem
    {
        protected EquipItemType equipItemType;
        protected EquipItemBitFlag equipItemBitFlag;
        public delegate void ItemEvnetDelegate();

        public abstract void CombineEquipItemDelegate(ItemEvnetDelegate _evnet);
        public abstract void CombineUnequipItemDelegate(ItemEvnetDelegate _evnet);
        public abstract void RemoveEquipItemDelegate(ItemEvnetDelegate _evnet);
        public abstract void RemoveUnequipItemDelegate(ItemEvnetDelegate _evnet);
        public abstract void InvokeEquipItemDelegate();
        public abstract void InvokeUnequipItemDelegate();
        public abstract EquipItemBitFlag GetEquipItemBitFlag();
    }

    public class PlayerEquipmentItem : EquipItem
    {
        public PlayerEquipmentItem(EquipItemType _itemType, EquipItemBitFlag _itemBitFlag)
        {
            equipItemType = _itemType;
            equipItemBitFlag = _itemBitFlag;
        }

        protected ItemEvnetDelegate equipItemDelegate;
        protected ItemEvnetDelegate unequipItemDelegate;

        public override void CombineEquipItemDelegate(ItemEvnetDelegate _evnet)
        {
            equipItemDelegate += _evnet;
        }

        public override void CombineUnequipItemDelegate(ItemEvnetDelegate _evnet)
        {
            equipItemDelegate -= _evnet;
        }

        public override void RemoveEquipItemDelegate(ItemEvnetDelegate _evnet)
        {
            unequipItemDelegate += _evnet;
        }

        public override void RemoveUnequipItemDelegate(ItemEvnetDelegate _evnet)
        {
            unequipItemDelegate -= _evnet;
        }

        public override void InvokeEquipItemDelegate()
        {
            equipItemDelegate?.Invoke();
        }

        public override void InvokeUnequipItemDelegate()
        {
            unequipItemDelegate?.Invoke();
        }

        public override EquipItemBitFlag GetEquipItemBitFlag()
        {
            return equipItemBitFlag;
        }
    }



    public class Player
    {
        // 장비 창작시 변경될 데이터 및 이벤트 메소드
        public int equipItemBitFlag = 0;
        private Inventory inventory = new Inventory();

        public void Initalize()
        {
            inventory.equipItems[(int)EquipItemType.weapon].CombineEquipItemDelegate(EquipWeaponEvent);
            inventory.equipItems[(int)EquipItemType.weapon].CombineUnequipItemDelegate(UnequipWeaponEvent);
        }



        private void EquipWeaponEvent()
        {
            equipItemBitFlag ^= (int)inventory.equipItems[(int)EquipItemType.weapon].GetEquipItemBitFlag();
            // 무기 장착 이벤트 메서드 바디
        }
        private void UnequipWeaponEvent()
        {
            equipItemBitFlag |= (int)inventory.equipItems[(int)EquipItemType.weapon].GetEquipItemBitFlag();
            // 무기 해제 이벤트 메서드 바디
        }

    }
    public class Inventory
    {
        public EquipItem[] equipItems = new EquipItem[]
        {
        new PlayerEquipmentItem(EquipItemType.weapon, EquipItemBitFlag.weapon),
        new PlayerEquipmentItem(EquipItemType.armor, EquipItemBitFlag.armor),
        new PlayerEquipmentItem(EquipItemType.shoes, EquipItemBitFlag.shoes),
        new PlayerEquipmentItem(EquipItemType.shield, EquipItemBitFlag.shield),
        new PlayerEquipmentItem(EquipItemType.helmet, EquipItemBitFlag.helmet)
        };

        // 장비 착용 해재의 실행 메소드
        private void EquipItem(EquipItemType _itemType)
        {
            equipItems[(int)_itemType].InvokeEquipItemDelegate();
        }
        private void UnequipItem(EquipItemType _itemType)
        {
            equipItems[(int)_itemType].InvokeUnequipItemDelegate();
        }
        private void ChangeItem(EquipItemType _itemType)
        {
            equipItems[(int)_itemType].InvokeUnequipItemDelegate();
            equipItems[(int)_itemType].InvokeEquipItemDelegate();
        }
    }
}
