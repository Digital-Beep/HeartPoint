using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.Items.Weapons
{
	public class Rezor : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Rezor"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is Forged with bloody crimson.");
		}

		public override void SetDefaults() 
		{
			item.damage = 15;
			item.magic = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 2;
			item.UseSound = SoundID.Item42;
            item.autoReuse = true;
            item.shoot = ProjectileID.RubyBolt;
            item.shootSpeed = 10f;
			item.mana = 3;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 15);
			recipe.AddIngredient(ItemID.Book, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}