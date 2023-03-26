using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TheLegendOfTerra.Content.Items.Pets
{
	public class Navi : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Annoying Fairy Bell");
			Tooltip.SetDefault("Summons Navi to aid you on your adventure!");
		}

		public override void SetDefaults()
		{		
			Item.width = 30;
			Item.height = 28;
			Item.useTime = 20;
			Item.useStyle = 4;
			Item.useAnimation = 1;			
			Item.UseSound = new SoundStyle($"{nameof(TheLegendOfTerra)}/Content/Sounds/Pets/NaviHello");
			Item.shoot = Mod.Find<ModProjectile>("Navi").Type;
			Item.buffType = Mod.Find<ModBuff>("NaviBuff").Type;
			Item.rare = 1;
			Item.value = Item.sellPrice(0, 0, 0, 0);
			Item.noMelee = true;
			Item.accessory = true;
		}
	}
}
