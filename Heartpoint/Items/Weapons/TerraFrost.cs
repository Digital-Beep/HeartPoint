using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.Items.Weapons
{
	public class TerraFrost : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("TerraFrost"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This the sword of the gods bloodshed.");
		}

		public override void SetDefaults() 
		{
			item.damage = 300;
			item.melee = true;
			item.width = 300;
			item.height = 300;
			item.useTime = 9;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 2000000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
            item.autoReuse = true;
			item.melee = true;
			item.shoot = ProjectileID.FrostBlastFriendly;
		}

	}
}