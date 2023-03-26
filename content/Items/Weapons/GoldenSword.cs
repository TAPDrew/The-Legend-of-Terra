using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
	public class GoldenSword : ModItem
	{
		public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 56;
			Item.height = 56;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 160;
			Item.knockBack = 5f;
            Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
		}
	}
}
