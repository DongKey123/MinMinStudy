using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	15.	동일한 UI구성으로 직업 + 장비 조합으로 모션 및 실행 가능 스킬이 달라질 수 있는 로직을 구현하시오 (참고 : 마영전 (아리샤)) [25점]

public enum Class
{
    Warrior = 10,
    Archer = 20,
    Thief = 30,
    Mage = 40
}

public enum WeaponType
{
    Sword = 0,
    Bow = 1,
    Dagger = 2,
    Wand = 3
}

public class Mabinogi : MonoBehaviour
{
    private Class CurClass;
    private WeaponType CurWeapon;
    private int skillSet;

    public void SelectClass(Class _class)
    {
        CurClass = _class;
        Debug.Log(CurClass);
    }

    public void SelectWeapon(WeaponType _weapon)
    {
        CurWeapon = _weapon;
        Debug.Log(CurWeapon);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectClass(Class.Warrior);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectClass(Class.Archer);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectClass(Class.Thief);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SelectClass(Class.Mage);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectWeapon(WeaponType.Sword);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SelectWeapon(WeaponType.Bow);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SelectWeapon(WeaponType.Dagger);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SelectWeapon(WeaponType.Wand);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Skill();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            SetSkilSet();
        }
    }

    private void SetSkilSet()
    {
        skillSet = (int)CurClass + (int)CurWeapon;
    }

    private void Skill()
    {
        Debug.Log(skillSet);
    }
}

