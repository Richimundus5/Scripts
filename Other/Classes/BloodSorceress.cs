/*
name: BloodSorceress
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class BloodSorceress
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm => new();
    public CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetBSorc();

        Core.SetOptions(false);
    }

    public void GetBSorc(bool rankUpClass = true)
    {
        if (Core.CheckInventory("Blood Sorceress"))
        {
            if (rankUpClass)
                Adv.RankUpClass("Blood Sorceress");
            return;
        }

        Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("towerofmirrors", "Scarletta", "Blood Sorceress", isTemp: false);
        Bot.Wait.ForPickup("Blood Sorceress");
        
        if (rankUpClass)
            Adv.RankUpClass("Blood Sorceress");
    }
}
