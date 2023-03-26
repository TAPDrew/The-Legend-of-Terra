using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheLegendofTerra.Content.Projectiles;

namespace TheLegendofTerra.Content.Items/Tools
{
	internal class Hookshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmethystHook);
			Item.shootSpeed = 24f;
			Item.shoot = ModContent.ProjectileType<HookshotProjectile>();
            Item.UseSound = new SoundStyle($"{nameof(TheLegendofTerra)}/Content/Sounds/HookshotFire") {};
        }
	}
}
