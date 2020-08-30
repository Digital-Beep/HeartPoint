using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.NPCs.Boss.TerraGuardian
{
    public class TerraGuardianTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("TerraGuardian");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = -12;
            item.maxStack = 999;
            item.expert = true;      //add this if it's expert mode only
        }

        public override void OpenBossBag(Player player)
        {                                         //below it's a choice from 3 items that will drop randomly
            int choice = Main.rand.Next(3);
            if (choice == 0)
            {
                player.QuickSpawnItem(ItemID.CobaltShield, 1);
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("WeirdSword"));
            }
            if (choice == 2)
            {
                player.QuickSpawnItem(mod.ItemType("GuardiansBuildingBlocks"));
            }
            //and this is the items that will 100% drop from the treasure bag
            player.QuickSpawnItem(ItemID.Hellstone, 100);
            player.QuickSpawnItem(ItemID.GreaterHealingPotion, 15);
        }
    }
}