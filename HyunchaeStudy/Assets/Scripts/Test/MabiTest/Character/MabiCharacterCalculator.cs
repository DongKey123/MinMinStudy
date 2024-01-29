using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MabiCharacterCalculator
{
     static MabiCharacterCalculator()
    {
        MabiTableDataManager.getInstance.Initialize();
    }

    public static void CalculateAll<TJob,TWeapon>(MabiBaseCharacter _character) where TJob : MabiIJob where TWeapon : MabiBaseWeapon
    {
        CalculateJobStatus<TJob>(_character);
        CalculateEquipStatus<TWeapon>(_character);
        CalculateSkillSet<TJob, TWeapon>(_character);
        CalculateSkillSet<TJob, TWeapon>(_character);
    }

    public static void CalculateJobStatus<TJob>(MabiBaseCharacter _character) where TJob : MabiIJob
    {
        MabiCharacterStatus status = new MabiCharacterStatus();

        _character.GetStatus();

        _character.SetStatus(status);
    }

    public static void CalculateEquipStatus<TWeapon>(MabiBaseCharacter _character) where TWeapon : MabiBaseWeapon
    {
        MabiCharacterStatus status = new MabiCharacterStatus();

        _character.GetStatus();

        _character.SetStatus(status);
    }

    public static void CalculateSkillSet<TJob, TWeapon>(MabiBaseCharacter _character) where TJob : MabiIJob where TWeapon : MabiBaseWeapon
    {
        // 테이블데이터에서 받아오기
        MabiSkillSet skillSet = MabiTableDataManager.getInstance.GetSkillSet<TJob, TWeapon>();
        _character.SetSkillSet(skillSet);
    }

    public static void CalculateAnimator<TJob, TWeapon>(MabiBaseCharacter _character) where TJob : MabiIJob where TWeapon : MabiBaseWeapon
    {

        Animator animator = MabiTableDataManager.getInstance.GetAnimator<TJob, TWeapon>();
        _character.SetAnimator(animator);
    }

}
