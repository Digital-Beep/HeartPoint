using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.UI.ModBrowser;
using static Terraria.ModLoader.ModContent;

namespace heartpoint.Items.projectiles
{
    public class VortexBullet : ModItem
    {
        public override void SetDefaults()
        {
            item.Size = new Vector2(8);
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Purple;

            item.consumable = true;
            item.maxStack = 999;

            item.ranged = true;
            item.damage = 20;
            item.knockBack = 3.25f;

            item.shoot = ProjectileType<Heartpoint.Items.projectiles.VortexBullet>();
            item.shootSpeed = 30f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 1);
            recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}