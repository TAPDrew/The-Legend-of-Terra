using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace openaitest
{
    public class ClimbingGlove : ModItem
    {
        public override void SetDefaults()
        {
            NPC.width = 34;
            NPC.height = 56;
            NPC.lifeMax = 10000;
            NPC.damage = 30;
            NPC.defense = 40;
        }
        public class ClimbingGlove : ModItem
{
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.gravControl2 = true;
        player.spiderSkid = true;
        player.spiderWall = true;
        player.noFallDmg = true;
    }
}