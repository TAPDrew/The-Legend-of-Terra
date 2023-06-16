using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheLegendofTerra.Content.Projectiles;

namespace TheLegendofTerra.Content.Projectiles
{

    public class HeroSwordBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 30;
            DisplayName.SetDefault("Spin Attack");
        }


        public override void SetDefaults()
        {
            Projectile.width = 48; // The width of projectile hitbox
            Projectile.height = 48; // The height of projectile hitbox
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.DamageType = DamageClass.Melee; // Is the projectile shoot by a ranged weapon?
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = false; // Can the projectile collide with tiles?
            Projectile.timeLeft = 30;
        }
        //UNFINISHED
        public override void AI()
        {
            Projectile.position = //to be added
            Projectile.frameCounter++;
            /*if (Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= 2)
                    Projectile.frame = 0;
            }*/
            //No clue if this works
            Projectile.rotation = Projectile.frameCounter * 12 * Projectile.spriteDirection;
            //OLD CODE: Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
        }
    }
}
