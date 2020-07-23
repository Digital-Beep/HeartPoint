using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using heartpoint.Items.projectiles;

namespace Heartpoint.NPCs.Boss.OscarEye
{
    public class OscarEye : ModNPC
    {
        NPC orbit0;
        NPC orbit1;
        internal Player target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oscar Eye");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 4;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.scale = 2;
            npc.lifeMax = 19000;
            npc.width = 110;
            npc.height = 152;
            npc.damage = 120;
        Main.npcFrameCount[npc.type] = 2;


        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.life < 19000)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }
        public override void NPCLoot()
        {

            Rectangle r = npc.getRect();
            Item.NewItem(r, ModContent.ItemType<GrenadeArrow>(), Main.rand.Next(15, 36));
            if (Main.rand.NextBool(4))
                Item.NewItem(r, ModContent.ItemType<SmokeArrow>());
        }
    }
}