using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
    public class BombosMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Bombos Medallion");
            Tooltip.SetDefault("'This is the Bombos Medallion! Its magic makes the ground explode with power!'");
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.DamageType = DamageClass.Magic;
            Item.width = 38;
            Item.height = 38;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(1);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item34;
            Item.autoReuse = false;
            Item.shootSpeed = 16f;
            Item.mana = 40;

            Item.useTime = 4;
            Item.useAnimation = 40;
            Item.reuseDelay = 0;
        }

        public override bool? UseItem(Player player)
        {
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && npc.CanBeChasedBy() && npc.life > 0 && npc.Distance(player.Center) < 1000f)
                {
                    npc.StrikeNPC(Item.damage, 0f, 0, false, false, false);
                    for (int i = 0; i < 10; i++)
                    {
                        Projectile.NewProjectile(player.GetSource_FromAI(), npc.Center, Vector2.Zero, Mod.Find<ModProjectile>("BombExplosion").Type, (int)(Item.damage), Item.knockBack);
                    }
                }
            }

            return true;
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
