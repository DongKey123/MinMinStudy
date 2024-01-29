using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MabiTableDataManager : Singleton<MabiTableDataManager>
{
    private TableLoader tableLoader;
    private JobTable jobTable;

    public override bool Initialize()
    {
        tableLoader = new TableLoader();
        SetTable();

        return base.Initialize();
    }


    public async void SetTable()
    {
        jobTable = await tableLoader.LoadFromFile<JobTable>("FilePath");
    }


    public MabiSkillSet GetSkillSet<TJob,TWeapon>()
    {
        MabiSkillSet skillSet = new MabiSkillSet();
        return skillSet;
    }

    public Animator GetAnimator<TJob,TWeapon>()
    {
        Animator animator = new Animator();
        return animator;
    }
}
