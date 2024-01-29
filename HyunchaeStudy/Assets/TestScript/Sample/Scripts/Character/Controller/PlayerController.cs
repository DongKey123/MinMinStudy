using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseCharController
{
    private CharacterInfo info = null;

    private CharStatCalculator calculator = null;

    private SkillSet skillSet = null;

    public PlayerController()
    {
        calculator = new CharStatCalculator(this);
    }

    public void Initialize<Tjob, TWeapon>() where Tjob : IJob where TWeapon : WeaponBase
    {
        calculator.CalculateAll<Tjob, TWeapon>();
    }
}
