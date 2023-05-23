using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
	public class GreatFairySword : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Forged by the Great Fairy of Kindness for a Hero that proved worthy by returning her to form.");
		}

		public override void SetDefaults()
		{
			Item.damage = 87;
      //April 27 2000 (40 + 27 + 20)
			Item.DamageType = DamageClass.Melee;
			Item.width = 86;
			Item.height = 86;
			Item.useTime = 37;
			Item.useAnimation = 43;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 4272000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	 }
}
