//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
//cs_include Scripts/Legion/Revenant/CoreLR.cs
//cs_include Scripts/Legion/JoinLegion[UndeadWarrior].cs
//cs_include Scripts/Legion/InfiniteLegionDarkCaster.cs
//cs_include Scripts/Story/NecroDungeon.cs
using RBot;

public class LegionFealty2
{
    public CoreBots Core => CoreBots.Instance;
    public CoreLR LR = new CoreLR();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        LR.ConquestWreath();

        Core.SetOptions(false);
    }
}