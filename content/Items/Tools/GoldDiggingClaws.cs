using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheLegendofTerra.content.Items.Tools
	public class GoldDiggingClaws : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Can mine Metiorite");
		}

		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2 ;
			Item.value = Item.buyPrice(silver: 20); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.pick = 55; // How strong the pickaxe is, see https://terraria.gamepedia.com/Pickaxe_power for a list of common values
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GoldBar, 10)
				.AddIngredient(ItemID.Wood, 4)
				.AddIngredient(ItemID.Leather, 3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
