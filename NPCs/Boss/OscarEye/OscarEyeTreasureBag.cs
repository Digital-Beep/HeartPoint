using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.NPCs.Boss.OscarEye
{
    public class OscarEyeTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("OscarEye");

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
            int choice = Main.rand.Next(2);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("OscarsSpirit"));
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("OscarsWrath"));
            }
            //and this is the items that will 100% drop from the treasure bag
            player.QuickSpawnItem(ItemID.Obsidian, 85);
            player.QuickSpawnItem(ItemID.Hellstone, 200);
            player.QuickSpawnItem(ItemID.SuperHealingPotion, 15);
        }
    }
}