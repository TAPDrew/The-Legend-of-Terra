using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.content.Items.Weapons
{
    public class FightersSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fighter's Sword");
            Tooltip.SetDefault("A simple sword wielded by most knights, even the high-ranking swordsmen.\n Despite its simplicity, there is much depth to this blade that may come to light should a great hero brandish it... \nThis weapon can perform a Spin Attack (except it can't yet).\nSpin attacks with this weapon progressively deal more damage as it pierces enemies.\nDamage resets at the end of the spin.");
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