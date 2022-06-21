//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Darkon/CoreDarkon.cs
//cs_include Scripts/Story/ElegyofMadness(Darkon)/CoreAstravia.cs
using RBot;

public class CoreDarkon
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreAdvanced Adv = new CoreAdvanced();
    public CoreStory Story = new CoreStory();
    public CoreFarms Farm = new CoreFarms();
    public CoreAstravia Astravia => new CoreAstravia();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.RunCore();
    }

    public void FarmReceipt(int Quantity = 222)
    {
        if (Core.CheckInventory("Darkon's Receipt", Quantity))
            return;

        SecondErrand(Quantity, true);
        FirstErrand(Quantity);
    }

    public void FirstErrand(int Quantity = 222)
    {
        if (Core.CheckInventory("Darkon's Receipt", Quantity))
            return;

        Core.AddDrop("Darkon's Receipt");
        Core.EquipClass(ClassType.Farm);

        while (!Bot.ShouldExit() && !Core.CheckInventory("Darkon's Receipt", Quantity))
        {
            Core.EnsureAccept(7324);

            Core.KillMonster("portalmaze", "r8", "Left", "*", "Banana", 22, false, log: false);

            Core.EnsureComplete(7324);
            Bot.Wait.ForPickup("Darkon's Receipt");
        }
    }

    public void SecondErrand(int Quantity = 222, bool escapeWhile = false)
    {
        if (Core.CheckInventory("Darkon's Receipt", Quantity))
            return;

        bool EnoughPeople = false;
        Core.AddDrop("Darkon's Receipt");
        Core.EquipClass(ClassType.Solo);

        Bot.Quests.UpdateQuest(2954);
        Core.Join("doomvault", "r5", "Left", true);

        while (!Bot.ShouldExit() && !Core.CheckInventory("Darkon's Receipt", Quantity))
        {
            if (Bot.Map.Name.ToLower() == "doomvault")
            {
                while (!Bot.ShouldExit() && Bot.Player.Cell != "r5")
                {
                    Core.Jump("r5", "Left");
                    Bot.Sleep(Core.ActionDelay);
                }
                if (Bot.Map.CellPlayers.Count >= 3)
                    EnoughPeople = true;
                else EnoughPeople = false;
            }

            if (!EnoughPeople && !Core.IsMember && escapeWhile)
                return;

            Core.EnsureAccept(7325);

            if (!EnoughPeople && Core.IsMember)
                Core.HuntMonster("ultravoid", "Ultra Kathool", "Ingredients?", 22, false, publicRoom: true, log: false);
            else Adv.KillUltra("doomvault", "r5", "Left", "Binky", "Ingredients?", 22, false, publicRoom: true, log: false);

            Core.EnsureComplete(7325);
            Bot.Wait.ForPickup("Darkon's Receipt");
        }
    }

    public void ThirdErrand(int Quantity = 222)
    {
        if (Core.CheckInventory("Darkon's Receipt", Quantity))
            return;

        Core.AddDrop("Darkon's Receipt");
        Core.EquipClass(ClassType.Solo);

        while (!Bot.ShouldExit() && !Core.CheckInventory("Darkon's Receipt", Quantity))
        {
            Core.EnsureAccept(7326);

            Core.HuntMonster("tercessuinotlim", "Nulgath", "Nulgath's mask", 1, false, publicRoom: true);

            Core.EnsureComplete(7326);
            Bot.Wait.ForPickup("Darkon's Receipt");
        }
    }


    public void Teeth(int Quantity = 300)
    {
        if (Core.CheckInventory("Teeth", Quantity))
            return;

        Core.AddDrop("Teeth");

        Astravia.Eridani();

        Core.EquipClass(ClassType.Solo);

        Core.Logger($"Farming {Quantity} Teeth");
        while (!Bot.ShouldExit() && (!Core.CheckInventory("Teeth", Quantity)))
        {
            Core.EnsureAccept(7780);
            Core.HuntMonster("eridani", "Wolf-Like Creature", "Tooth", 28, false, log: false);
            Bot.Options.AttackWithoutTarget = true;
            Core.KillMonster("eridani", "r4", "Left", "Creature 15", "Wisdom Tooth", 4, false, log: false);
            Bot.Options.AttackWithoutTarget = false;
            Core.EnsureComplete(7780);
        }
    }

    public void LasGratitude(int Quantity = 300)
    {
        if (Core.CheckInventory("La's Gratitude", Quantity))
            return;

        Core.AddDrop("La's Gratitude");

        Astravia.Astravia();

        Core.EquipClass(ClassType.Solo);

        Core.Logger($"Farming {Quantity} La's Gratitude");
        while (!Bot.ShouldExit() && (!Core.CheckInventory("La's Gratitude", Quantity)))
        {
            Core.EnsureAccept(8001);
            Core.HuntMonster("astravia", "Creature 27", "Broken Dog Tag", 20, log: false);
            Core.HuntMonster("astravia", "Creature 27", "Intact Dog Tag", 5, log: false);
            Core.EnsureComplete(8001);
        }
    }

    public void AstravianMedal(int Quantity = 300)
    {
        if (Core.CheckInventory("Astravian Medal", Quantity))
            return;

        Core.AddDrop("Astravian Medal");

        Astravia.AstraviaCastle();
        Core.Join("astraviacastle");

        Core.Logger($"Farming {Quantity} Astravian Medal");
        while (!Bot.ShouldExit() && (!Core.CheckInventory("Astravian Medal", Quantity)))
        {
            Core.EnsureAccept(8257);
            Core.EquipClass(ClassType.Farm);
            Bot.Options.AttackWithoutTarget = true;
            Core.HuntMonster("astraviacastle", "Creature 27", "Defaced Portrait", 10, log: false);
            Core.HuntMonster("astraviacastle", "Creature 20", "Smashed Sculpture", 4, log: false);
            Bot.Options.AttackWithoutTarget = false;
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("astraviacastle", "The Sun", "Burned Banana", log: false);
            Core.EnsureComplete(8257);
        }
    }

    public void AMelody(int Quantity = 300)
    {
        if (Core.CheckInventory("A Melody", Quantity))
            return;

        Core.AddDrop("A Melody");

        Astravia.AstraviaJudgement();

        Core.Logger($"Farming {Quantity} A Melody");
        while (!Bot.ShouldExit() && (!Core.CheckInventory("A Melody", Quantity)))
        {
            Core.EnsureAccept(8396);
            Core.HuntMonster("astraviajudge", "Trumpeter", "Brass", 10, log: false);
            Core.HuntMonster("astraviajudge", "Hand", "Sinew", 10, log: false);
            Core.HuntMonster("astraviajudge", "La", "Knight's Favor", log: false);
            Core.EnsureComplete(8396);
        }
    }

    public void BanditsCorrespondence(int Quantity = 3000)
    {
        if (Core.CheckInventory("Bandit's Correspondence", Quantity))
            return;

        Core.AddDrop("Bandit's Correspondence");

        Astravia.EridaniPast();

        Core.Logger($"Farming {Quantity} Bandit's Correspondence");
        while (!Bot.ShouldExit() && (!Core.CheckInventory("Bandit's Correspondence", Quantity)))
        {
            Bot.Quests.UpdateQuest(8531); //attempted fix
            Core.EnsureAccept(8531);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("eridanipast", "Bandit", "Bandit Contraband", 12, log: false);
            Bot.Options.AttackWithoutTarget = true;
            Core.KillMonster("eridanipast", "r10", "Left", "Suki", "Seraphic Sparred", log: false);
            Bot.Options.AttackWithoutTarget = false;
            Core.HuntMonster("eridanipast", "Dog", "Dogs Confiscated", 12, log: false);
            Core.EnsureComplete(8531);
        }
    }

    public void SukisPrestiege(int Quantity = 300)
    {
        if (Core.CheckInventory("Suki's Prestige", Quantity))
            return;

        Core.AddDrop("Suki's Prestige");
        Astravia.CompleteCoreAstravia();

        Core.Logger($"Farming {Quantity} Suki's Prestige");
        while (!Bot.ShouldExit() && (!Core.CheckInventory("Suki's Prestige", Quantity)))
        {
            Core.EnsureAccept(8602);
            Core.EquipClass(ClassType.Solo);
            Core.HuntMonster("astraviapast", "Regulus", "Regulus' Rematch Won", log: false);
            Core.HuntMonster("astraviapast", "Titania", "Titania's Rematch Won", log: false);
            Core.HuntMonster("astraviapast", "Aurola", "Aurola's Rematch Won", log: false);
            Core.EquipClass(ClassType.Farm);
            Core.HuntMonster("astraviapast", "Astravian Soldier", "Soldiers Trained", 8, log: false);
            Core.EnsureComplete(8602);
        }
    }
}