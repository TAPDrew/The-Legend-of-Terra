using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
    public class FightersSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fighter's Sword");
            Tooltip.SetDefault("A simple sword wielded by most Hylian knights, even the most \nhigh-ranking swordsmen. \nDespite its simplicity, there is much depth to this blade that \nmay come to light should a great hero brandish it... \n\nThis weapon can perform a Spin Attack (except it can't yet).\nSpin attacks with this weapon progressively \ndeal more damage as they pierce enemies.\nDamage resets at the end of the spin.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
            Item.damage = 35;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
        }
    }
}