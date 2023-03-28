using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
    public class FleetingXiphos : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("An alternative design to the ever-popular Fighter's Sword. This weapon is chosen \nfor its superior handling and agility, making up for its lesser strength \nin a plethora of situations. \n\nThis weapon can perform a Spin Attack (except it can't yet).\nSpin attacks with this weapon are \nfaster to charge up than their heavier counterpart but they also spend less time active. \nDamage resets per enemy when they stop receiving damage.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
            Item.damage = 24;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
        }
    }
}