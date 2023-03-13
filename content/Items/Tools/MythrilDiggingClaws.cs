using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace The-Legend-of-Terra.content.Items.Tools
{
	public class MythrilDiggingClaws : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Can mine Adamantite and Titanium");
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(gold: 1); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.pick = 150; // How strong the pickaxe is, see https://terraria.gamepedia.com/Pickaxe_power for a list of common values
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MythrilBar, 13)
				.AddIngredient(ItemID.Leather, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}

	}
}
