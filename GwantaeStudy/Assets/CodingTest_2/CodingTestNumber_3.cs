using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 15.	동일한 UI구성으로 직업 + 장비 조합으로 모션 및 실행 가능 스킬이 달라질 수 있는 로직을 구현하시오 (참고 : 마영전 (아리샤)) 

public class CodingTestNumber_3 : MonoBehaviour
{
    private PlayerBaseClass player = null;
    private Atuer atuer = null;
    private Worrier worrier = null;
    private Magiction magiction = null;

    private Sword sword = null;
    private Bow bow = null;
    private Wonde wonde = null;

    private void Awake()
    {
        atuer = new Atuer();
        worrier = new Worrier();
        magiction = new Magiction();

        sword = new Sword();
        bow = new Bow();
        wonde = new Wonde();
    }
    private void Start()
    {
        Debug.Log("chose your class q : Atuer , w : worrier , e : magiction");
        Debug.Log("choes your weapon a : sword , s : bow , d : wonde");
    }
    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            player = atuer;
            Debug.Log("Player class is = " + player.GetClassType());
        }
        if (Input.GetKeyDown("w"))
        {
            player = worrier;
            Debug.Log("Player class is = " + player.GetClassType());
        }
        if (Input.GetKeyDown("e"))
        {
            player = magiction;
            Debug.Log("Player class is = " + player.GetClassType());
        }

        if(player != null)
        {
            if (Input.GetKeyDown("a"))
            {
                player.SetWeapon(sword);
                Debug.Log("Player weapon is = " + player.GetWeaponType());
            }
            if (Input.GetKeyDown("s"))
            {
                player.SetWeapon(bow);
                Debug.Log("Player weapon is = " + player.GetWeaponType());
            }
            if (Input.GetKeyDown("d"))
            {
                player.SetWeapon(wonde);
                Debug.Log("Player weapon is = " + player.GetWeaponType());
            }
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Player class and weapon is =" + player.GetClassAndWaepon());
        }

    }
}

public enum EPLAYER_CLASS_TYPE
{
    None = 0x00,
    Atuer = 0x01 << 4,
    Worrier = 0x01 << 5,
    Magiction = 0x01 << 6
}
public enum EWEAPON_TYPE
{
    None = 0x00,
    Sword = 0x01 << 0,
    Bow = 0x01 << 1,
    Wonde = 0x01 << 2,
}

public class PlayerBaseClass
{
    protected EPLAYER_CLASS_TYPE classType = EPLAYER_CLASS_TYPE.None;
    protected Weapon weapon;

    public EPLAYER_CLASS_TYPE GetClassType()
    {
        return classType;
    }
    public EWEAPON_TYPE GetWeaponType()
    {
        return weapon.GetWeaponType();
    }
    public void SetWeapon(Weapon _weapon)
    {
        weapon = _weapon;
    }
    public int GetClassAndWaepon()
    {
        if(weapon == null)
        {
            Debug.Log("you dont set weapon");
            return 0;
        }

        return (int)classType | (int)weapon.GetWeaponType();
    }
}
public class Atuer : PlayerBaseClass
{
    public Atuer()
    {
        classType = EPLAYER_CLASS_TYPE.Atuer;
    }
}
public class Worrier : PlayerBaseClass
{
    public Worrier()
    {
        classType = EPLAYER_CLASS_TYPE.Worrier;
    }
}
public class Magiction : PlayerBaseClass
{
    public Magiction()
    {
        classType = EPLAYER_CLASS_TYPE.Magiction;
    }
}


public class Weapon
{
    protected EWEAPON_TYPE weaponType = EWEAPON_TYPE.None;
    public EWEAPON_TYPE GetWeaponType()
    {
        return weaponType;
    }
}
public class Sword : Weapon
{
    public Sword()
    {
        weaponType = EWEAPON_TYPE.Sword;
    }
}
public class Bow : Weapon
{
    public Bow()
    {
        weaponType = EWEAPON_TYPE.Bow;
    }
}
public class Wonde : Weapon
{
    public Wonde()
    {
        weaponType = EWEAPON_TYPE.Wonde;
    }
}