using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TheLegendofTerra.Content.Items.Weapons
{
	public class GanonTowerBat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Hammer");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 150;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
		}
	}
}