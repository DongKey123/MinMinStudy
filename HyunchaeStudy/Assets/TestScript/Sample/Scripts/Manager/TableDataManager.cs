using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDataManager : Singleton<TableDataManager>
{
    private TableLoader tableLoader;

    private JobTable jobTable;
    private SkillTable skillTable;
    private EquipTable equipTable;

    public async void Init()
    {
        tableLoader = new TableLoader();

        jobTable = await tableLoader.LoadFromFile<JobTable>("FilePath");
        skillTable = await tableLoader.LoadFromFile<SkillTable>("FilePath");
        equipTable = await tableLoader.LoadFromFile<EquipTable>("FilePath");
    }

    
}
