using Terraria;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Projectiles.Weapons
{
    internal class BombExplosion : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 96;
            Projectile.height = 96;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.timeLeft = 30;
            Main.projFrames[Projectile.type] = 8;
        }

        public override void AI()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 2)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame > 7)
                {
                    Projectile.frame = 4;
                }
            }
        }
    }
}
