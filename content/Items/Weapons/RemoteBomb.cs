using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Items.Weapons
{
    public class RemoteBomb : Bomb
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Goes off when you want it to");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 28;
            Item.height = 22;
            Item.shoot = Mod.Find<ModProjectile>("RemoteBomb").Type;
        }
    }
}
