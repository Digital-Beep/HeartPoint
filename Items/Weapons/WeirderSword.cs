using Terraria.ID;
using Terraria.ModLoader;

namespace Heartpoint.Items.Weapons
{
	public class WeirderSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
            // DisplayName.SetDefault("KnightsBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("You feel like you seen this before idk weird right");
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 100;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 12;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.melee = true;
		}
		
	}
}