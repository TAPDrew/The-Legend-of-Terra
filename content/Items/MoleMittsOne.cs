using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace openaitest
{
    public class MoleMittsOne : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mole Mitts");
            Tooltip.SetDefault("This pickaxe digs a 1x3 area");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.pick = 200;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useTurn = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (player.altFunctionUse == 2) // Right click
            {
                return base.UseItem(player);
            }
            else // Left click
            {
                // Dig 1x3 area centered around clicked block
                int x = (int)(Main.MouseWorld.X / 16);
                int y = (int)(Main.MouseWorld.Y / 16);
                for (int i = -1; i <= 1; i++)
                {
                    WorldGen.KillTile(x, y + i);
                }
                return true;
            }
        }
    }
}