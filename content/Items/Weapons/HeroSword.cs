using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheLegendofTerra.Content.Projectiles;

namespace TheLegendofTerra.Content.Items.Weapons
{
    public class HeroSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hero's Sword");
            Tooltip.SetDefault("''It's dangerous to go alone.''");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.knockBack = 4.5f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 18;
            Item.useTime = 24;
            Item.width = 48;
            Item.height = 48;
            Item.UseSound = new Terraria.Audio.SoundStyle("TheLegendofTerra/Content/Sounds/heroswordswing");
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.reuseDelay = 16;
            Item.noUseGraphic = true; 
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 1, 9, 85);
            int proj = ModContent.ProjectileType<HeroSwordProjectile>();
            Item.shoot = ModContent.ProjectileType<HeroSwordProjectile>(); 
            Item.shootSpeed = 1.1f; 

        }
    }
}