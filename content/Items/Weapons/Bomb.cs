using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheLegendofTerra.Content.Projectiles.Weapons;

namespace TheLegendofTerra.Content.Items.Weapons
{
    public class Bomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb");
            Tooltip.SetDefault("Placing may be difficult");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.knockBack = 8;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.width = 28;
            Item.height = 28;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Throwing;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.shoot = ModContent.ProjectileType<BombProj>();
            Item.shootSpeed = 1;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 28f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
    }
}
