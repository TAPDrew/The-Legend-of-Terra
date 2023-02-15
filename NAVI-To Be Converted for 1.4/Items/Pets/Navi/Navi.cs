using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheLegendOfTerra.Items.Pets.Navi
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
			item.width = 30;
			item.height = 28;
			
			item.useTime = 20;
			item.useStyle = 4;
			item.useAnimation = 1;			
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Navi/NaviHello");
			
			item.shoot = mod.ProjectileType("Navi");
			item.buffType = mod.BuffType("NaviBuff");
			
			item.rare = 1;
			item.value = Item.sellPrice(0, 0, 0, 0);
			
			item.noMelee = true;
			item.accessory = true;
		}
	}
}