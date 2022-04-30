//cs_include Scripts/CoreBots.cs
using RBot;

public class SRoD
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        ShadowReaperOfDoom();

        Core.SetOptions(false);
    }

    public void ShadowReaperOfDoom()
    {
        if (Core.CheckInventory("ShadowReaper Of Doom"))
            return;

        Core.Logger("Farming for ShadowReaper Of Doom");

        Core.EquipClass(ClassType.Farm);
        Core.KillMonster("brightfall", "r1", "Down", "*", "Mirror Realm Token", 300, isTemp: false); 

        Core.EquipClass(ClassType.Solo);
        Core.KillMonster("overworld", "boss1", "Left", "Undead Artix", "Undead Paladin Token", isTemp: false);

        Core.BuyItem("overworld", 618, "ShadowReaper Of Doom", shopItemID: 1806);
    }
}
