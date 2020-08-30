using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace heartpoint.NPCs.Boss.MechanicalGuardian
{
    public class MechanicalGuardian : ModNPC
    {
        Player target;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 8;
            DisplayName.SetDefault("Mechanical Guardian");
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = -1f;
            npc.aiStyle = -1;
            npc.width = 50;
            npc.height = 254;
            npc.lifeMax = 90000;
            npc.damage = 100;
            bossBag = mod.ItemType("MGuardianTreasureBag");
            npc.ichor = true;
        }

        public override void AI()
        {
            // ai 0 - state
            // ai 1 - general timer
            // ai 2 - general counter
            // ai 3 - ???
            // behavior:
            if (!ValidOrTarget()) // despawn handler
            {
                npc.velocity.Y += 2;
                npc.timeLeft = 2;
            }
            UpdatePhase();
            if (npc.ai[0] == 0f)
            {
                npc.ai[0] = 0.1f; // first tic
            }
            // -same attack patterns as a enchanted sword, but it spins by a shorter time and the dash is longer and faster
            else if (npc.ai[0] == 0.1f)
            {
                // speen
                npc.rotation += npc.ai[2] += 0.005f;
                if (npc.ai[1]++ > 90)
                {
                    npc.velocity = Vector2.Normalize(target.MountedCenter - npc.Center) * 20f;
                    npc.rotation = npc.velocity.ToRotation() + MathHelper.PiOver2;
                    npc.ai[0] = 0.2f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                }

            }



            else if (npc.ai[0] == 0.2f) // dash cooldown
            {
                const int dashcooldown = 0;
                if (npc.ai[1]++ > dashcooldown)
                {
                    npc.ai[0] = 0.3f;
                    npc.ai[1] = 0f;
                }
                npc.velocity *= 1.50f;
            }
            // -stops and shoots fast pink lasers that when hit something it explodes in 6 smaller pink lasers that pass through walls and home into the player, dealing 2 times less damage than the normal pink laser
            else if (npc.ai[0] == 0.3f)
            {
                Vector2 dist = target.Center - npc.Center;
                npc.rotation = Utils.AngleLerp(npc.rotation, dist.ToRotation() + MathHelper.PiOver2, 0.1f);
                if (npc.ai[1]++ > 2)
                {
                    Vector2 toPlayer = Vector2.UnitX.RotatedBy(npc.rotation - MathHelper.PiOver2) * 10;
                    Projectile.NewProjectile(npc.Center, toPlayer, ProjectileID.PinkLaser, npc.damage, 50, Main.myPlayer, BuffID.Electrified, 600f);
                    Projectile.NewProjectile(npc.Center, toPlayer, ProjectileID.EyeLaser, npc.damage, 10, Main.myPlayer, BuffID.Electrified, 600f);
                    npc.ai[2]++;
                    npc.ai[1] = 0;
                }

                npc.velocity *= 0.95f;

                if(npc.ai[2] > 5)
                {
                    npc.ai[0] = 0.1f;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                }
            }
            // -spins and shoots a pink deathray(200 / 250 / 350 damage) that pass through walls into the player
        }

        private void UpdatePhase()
        {

        }


        private static bool IsValidTarget(Player player) => player?.active is true && !(player.dead || player.ghost);

        private bool ValidOrTarget()
        {
            if (IsValidTarget(target))
                return true;

            if(Main.netMode == NetmodeID.SinglePlayer)
            {
                if (IsValidTarget(Main.LocalPlayer))
                {
                    target = Main.LocalPlayer;
                    return true;
                }
            }

            for(int i = 0; i < Main.player.Length; i++)
            {
                Player p = Main.player[i];
                if (IsValidTarget(p))
                {
                    target = p;
                    return true;
                }
            }
            return false;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.frameCounter++ > 10)
            {
                npc.frameCounter = 0;
                if ((npc.frame.Y += frameHeight) > frameHeight * 7)
                    npc.frame.Y = 0;
            }
        }               public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {

                Rectangle r = npc.getRect();
                Item.NewItem(r, ItemID.SoulofLight, 100);
                Item.NewItem(r, ItemID.SoulofNight, 100);
                if (Main.rand.NextBool(4))
                    Item.NewItem(r, ItemID.GreaterHealingPotion, 15);
                Item.NewItem(r, ItemID.GoldCoin, 70);
                int choice = Main.rand.Next(2);
            }
        }
    }
}

