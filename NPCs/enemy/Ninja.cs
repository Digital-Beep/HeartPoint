using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.NPCs.enemy
{

    public class Ninja : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ninja");

            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];

        }


        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 20;
            npc.lifeMax = 250;
            npc.damage = 20;
            npc.defense = 5;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 10f;
            npc.knockBackResist = 0.75f;
            npc.aiStyle = 3;
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
            banner = Item.NPCtoBanner(NPCID.Zombie);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.15f;
        }

        public override void NPCLoot()
        {
            
            int choice = Main.rand.Next(5);
            if (choice == 0)
            {
                Item.NewItem(npc.position, ItemID.NinjaHood, 1);
            }
            if (choice == 1)
            {
                Item.NewItem(npc.position, ItemID.NinjaPants, 1);
            }
            if (choice == 2)
            {
                Item.NewItem(npc.position, ItemID.NinjaShirt, 1);
            }
            if (choice == 3)
            {
                Item.NewItem(npc.position, ItemID.RottenEgg, 3);
            }
            if (choice == 4)
            {
                Item.NewItem(npc.position, ItemID.SmokeBomb, 5);
            }

        }
    }
}