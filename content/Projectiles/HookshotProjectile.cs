using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLegendofTerra.Content.Projectiles
{
	internal class HookshotProjectile : ModProjectile
	{
		private static Asset<Texture2D> chainTexture;

		public override void Load()
		{
			chainTexture = ModContent.Request<Texture2D>("TheLegendofTerra/Content/Projectiles/HookshotChain");
		}

		public override void Unload()
		{		
			chainTexture = null;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
		}

		/*public override bool? CanUseGrapple(Player player)
		{
			int hooksOut = 0;
			for (int l = 0; l < 1000; l++)
			{
				if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == Projectile.type)
				{
					hooksOut++;
				}
			}
			return hooksOut <= 1;
		}*/

		public override bool? SingleGrappleHook(Player player)
		{
			return true;
		}

		public override float GrappleRange()
		{
			return 512f;
		}

		public override void NumGrappleHooks(Player player, ref int numHooks)
		{
			numHooks = 1;
		}

		public override void GrappleRetreatSpeed(Player player, ref float speed)
		{
			speed = 24f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed)
		{
			speed = 16;
		}

		public override void GrappleTargetPoint(Player player, ref float grappleX, ref float grappleY)
		{
			Vector2 dirToPlayer = Projectile.DirectionTo(player.Center);
			float hangDist = 32f;
			grappleX += dirToPlayer.X * hangDist;
			grappleY += dirToPlayer.Y * hangDist;
		}

		public override bool PreDrawExtras()
		{
			Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
			Vector2 center = Projectile.Center;
			Vector2 directionToPlayer = playerCenter - Projectile.Center;
			float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
			float distanceToPlayer = directionToPlayer.Length();

			while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
			{
				directionToPlayer /= distanceToPlayer;
				directionToPlayer *= chainTexture.Height();

				center += directionToPlayer;
				directionToPlayer = playerCenter - center;
				distanceToPlayer = directionToPlayer.Length();

				Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

				Main.EntitySpriteDraw(chainTexture.Value, center - Main.screenPosition,
					chainTexture.Value.Bounds, drawColor, chainRotation,
					chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);
			}
			return false;
		}
	}
}
