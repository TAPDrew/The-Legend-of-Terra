using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
	public class MasterSwordWW : ModItem
	{
		public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Master Sword (Hurricane Splendor)");
      Tooltip.SetDefault("The fully restored Master Sword\n from the Age of the Great Sea.");
      CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 64;
			Item.height = 64;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 86;
			Item.knockBack = 15f;
      Item.value = Item.sellPrice(0, 5, 0, 0);
      Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
		}
	}
}
