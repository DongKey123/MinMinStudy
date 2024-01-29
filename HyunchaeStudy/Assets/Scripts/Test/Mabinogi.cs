using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	15.	동일한 UI구성으로 직업 + 장비 조합으로 모션 및 실행 가능 스킬이 달라질 수 있는 로직을 구현하시오 (참고 : 마영전 (아리샤)) [25점] 추상화 일반화

public class MabiCharacterClass
{
    protected string className;

    public string GetClassName() => className;

    public MabiCharacterClass()
    {
        className = this.ToString();
    }
}

public class MabiClassOne : MabiCharacterClass
{
}
public class MabiClassTwo : MabiCharacterClass
{
}
public class MabiClassThree : MabiCharacterClass
{
}
public class MabiClassFour : MabiCharacterClass
{
}

public class MabiWeaponType
{
    protected string weaponTypeName;

    public string GetWeaponType() => weaponTypeName;

    public MabiWeaponType()
    {
        weaponTypeName = this.ToString();
    }
}


public class MabiWeaponOne : MabiWeaponType
{
}
public class MabiWeaponTwo : MabiWeaponType
{
}
public class MabiWeaponThree : MabiWeaponType
{
}
public class MabiWeaponFour : MabiWeaponType
{
}

public class mabiCharacter
{
    private MabiCharacterClass charClass;
    private MabiWeaponType charWeapon;

    public MabiCharacterClass GetCharClass() => charClass;
    public MabiWeaponType GetCharWeapon() => charWeapon;

    public void SetClass(MabiCharacterClass _class)
    {
        charClass = _class;
    }

    public void SetWeapon(MabiWeaponType _weapon)
    {
        charWeapon = _weapon;
    }
}

public class Mabinogi : MonoBehaviour
{
    private mabiCharacter character;
    private int skillSet;

    private void Awake()
    {
        character = new mabiCharacter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            character.SetClass(new MabiClassOne());
            Debug.Log("직업 선택" + character.GetCharClass().GetClassName());
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            character.SetClass(new MabiClassTwo());
            Debug.Log("직업 선택" + character.GetCharClass().GetClassName());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            character.SetClass(new MabiClassThree());
            Debug.Log("직업 선택" + character.GetCharClass().GetClassName());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            character.SetClass(new MabiClassFour());
            Debug.Log("직업 선택" + character.GetCharClass().GetClassName());
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            character.SetWeapon(new MabiWeaponOne());
            Debug.Log("무기 선택" + character.GetCharWeapon().GetWeaponType());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            character.SetWeapon(new MabiWeaponTwo());
            Debug.Log("무기 선택" + character.GetCharWeapon().GetWeaponType());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            character.SetWeapon(new MabiWeaponThree());
            Debug.Log("무기 선택" + character.GetCharWeapon().GetWeaponType());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            character.SetWeapon(new MabiWeaponFour());
            Debug.Log("무기 선택" + character.GetCharWeapon().GetWeaponType());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Skill();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
        }
    }

    private void Skill()
    {
        Debug.Log(skillSet);
    }
}

