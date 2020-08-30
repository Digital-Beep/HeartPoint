using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.Items.Weapons
{
	public class OscarsWrath : ModItem
	{
		public override void SetStaticDefaults() 
		{
            // DisplayName.SetDefault("BladeOfFlesh"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Wrath of Oscar");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.melee = true;
			item.width = 200;
			item.height = 200;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 100000;
			item.rare = 12;
			item.UseSound = SoundID.Item1;
            item.autoReuse = true;
			item.melee = true;
			item.shoot = ProjectileID.DemonScythe;
		}

		public override void AddRecipes() 
		{
		}
	}
}