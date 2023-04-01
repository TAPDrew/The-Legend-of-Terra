using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLegendOfTerra.Content.Players;

namespace TheLegendOfTerra.Content.Items.Weapons
{
    public class HylianShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hylian Shield");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 19;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 5;
            Item.accessory = true;
            Item.shieldSlot = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
        }
    }
}
