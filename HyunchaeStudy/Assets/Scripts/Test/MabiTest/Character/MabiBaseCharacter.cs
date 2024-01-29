using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MabiCharacterStatus
{
    public int hp;
    public int atk;
    public int def;
}

public class MabiBaseCharacter
{
    protected string charName;
    protected MabiSkillSet skillSet;
    protected MabiCharacterStatus status;
    private MabiIJob job;
    private MabiBaseWeapon weapon;
    private MabiBaseEquipItem[] equipItems;

    public MabiCharacterStatus GetStatus() => status;

    public void SetJob(MabiIJob _job)
    {
        job = _job;
    }

    public void SetWeapon(MabiBaseWeapon _weapon)
    {
        if(weapon != null)
        {
            weapon.UnEquipItem();
        }

        weapon = _weapon;
        weapon.EquipItem();
    }

    public void SetStatus(MabiCharacterStatus _status)
    {
        status = _status;
    }

    public void SetSkillSet(MabiSkillSet _skillSet)
    {
        skillSet = _skillSet;
    }

    public void SetAnimator(Animator _animator)
    {

    }

    public void Initialize<Tjob, TWeapon>() where Tjob : MabiIJob where TWeapon : MabiBaseWeapon
    {
        MabiCharacterCalculator.CalculateAll<Tjob, TWeapon>(this);
    }

}
