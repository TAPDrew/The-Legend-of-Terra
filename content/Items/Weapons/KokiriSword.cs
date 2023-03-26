using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
	public class KokiriSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 48;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 28;
			Item.useAnimation = 28;
			//Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 14;
			Item.knockBack = 3.5f;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
		}

		/*public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.Sparkle>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}*/

		public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CopperBroadsword)
            .AddTile(TileID.Anvils)
            .Register();
        }
	}
}
