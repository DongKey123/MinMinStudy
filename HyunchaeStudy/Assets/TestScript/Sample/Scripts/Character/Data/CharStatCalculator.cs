using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatCalculator
{
    private BaseCharController target = null;

    public CharStatCalculator(BaseCharController _target)
    {
        target = _target;
    }

    public void CalculateAll<Tjob, TWeapon>() where Tjob : IJob where TWeapon : WeaponBase
    {
        CalculateDefaultStat<Tjob>();
        CalculateEquipmentStat<TWeapon>();
        CalculateSkillSet<Tjob, TWeapon>();
        CalculateAnimator<Tjob, TWeapon>();
    }

    private void CalculateDefaultStat<T>() where T : IJob
    {

    }

    private void CalculateEquipmentStat<T>() where T : WeaponBase
    {

    }

    private void CalculateSkillSet<TJob, TWeapon>() where TJob : IJob where TWeapon : WeaponBase
    {

    }

    private void CalculateAnimator<TJob, TWeapon>() where TJob : IJob where TWeapon : WeaponBase
    {

    }
}
