using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Projectiles.Weapons
{
	public class RemoteBomb : BombProj
	{
		public override void SetDefaults()
		{
            base.SetDefaults();
            Main.projFrames[Projectile.type] = 3;
        }

		public override void AI()
        {
			Projectile.ai[0]++;
			if (Projectile.ai[0] == 1)
                Projectile.velocity = Vector2.Zero;
            Projectile.velocity.Y += 0.4f;
            if (Projectile.velocity.Y > 16f)
                Projectile.velocity.Y = 16f;
            Projectile.timeLeft++;
            //ChatGPT
            Projectile.frame = (Projectile.ai[0] % 20 == 0) ? 1 - Projectile.frame : Projectile.frame;
            /*Player player = Main.player[Projectile.owner];
            if (KeybindSystem.RemoteBombDetonate.JustPressed && Projectile.owner == player)
				Projectile.Kill();*/
        }

		public override void Kill(int timeLeft)
		{
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, Mod.Find<ModProjectile>("BombExplosion").Type, (int)(Projectile.damage), Projectile.knockBack, Main.player[Projectile.owner].whoAmI);
        }
	}
}
