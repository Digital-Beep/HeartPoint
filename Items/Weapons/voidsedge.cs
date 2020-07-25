using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.Items.Weapons
{
	public class VoidsEdge : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("VoidsEdge"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Why pick on the little guys eh");
		}

		public override void SetDefaults() 
		{
			item.damage = 45;
			item.summon = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 9;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.mana = 75;
			item.shoot = ProjectileID.BabySlime;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ImpStaff, 1);
			recipe.AddIngredient(ItemID.HornetStaff, 1);
			recipe.AddIngredient(ItemID.SlimeStaff, 1);
			recipe.AddIngredient(ItemID.FallenStar, 25);
            recipe.AddIngredient(ItemID.ManaCrystal, 5);
			recipe.AddIngredient(ItemID.NaturesGift, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}