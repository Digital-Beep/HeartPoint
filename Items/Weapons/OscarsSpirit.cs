using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.Items.Weapons
{
	public class OscarsSpirit : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("AquaBolt"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The Spirit of Oscar");
		}

		public override void SetDefaults() 
		{
			item.damage = 60;
			item.magic = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = -12;
			item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileID.SwordBeam;
            item.shootSpeed = 10f;
			item.mana = 0;
		}

		public override void AddRecipes() 
		{
		}
	}
}