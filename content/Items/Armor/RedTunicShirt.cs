using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TheLegendofTerra.content.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class RedTunicShirt : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The green cap worn by a hero.");
		}

		public override void SetDefaults()
		{
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 15; // The amount of defense the item will give when equipped
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DirtBlock)
				.Register();
		}
	}
}
