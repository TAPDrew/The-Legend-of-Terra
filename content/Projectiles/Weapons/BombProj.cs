using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Projectiles.Weapons
{
	public class BombProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = -1;
			Projectile.timeLeft = 120;
            Main.projFrames[Projectile.type] = 2;
        }

        public override bool? CanHitNPC(NPC npc)
        {
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void AI()
        {
			Projectile.ai[0]++;
			if (Projectile.ai[0] == 1)
                Projectile.velocity = Vector2.Zero;
            Projectile.velocity.Y += 0.4f;
            if (Projectile.velocity.Y > 16f)
				Projectile.velocity.Y = 16f;
            if (Projectile.timeLeft < 60)
			{
				if (Projectile.timeLeft % 5 == 0)
				{
                    Projectile.frame = (Projectile.frame == 0) ? Projectile.frame = 1 : Projectile.frame = 0;
                }
			}
        }

		public override void Kill(int timeLeft)
		{
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, Mod.Find<ModProjectile>("BombExplosion").Type, (int)(Projectile.damage), Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
        }
	}
}
