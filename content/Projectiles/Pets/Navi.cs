using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static TheLegendOfTerra.TheLegendOfTerra;

namespace TheLegendOfTerra.Content.Projectiles.Pets
{
	public class Navi : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Navi");
			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
			AIType = ProjectileID.ZephyrFish;
			
			Projectile.width = 36;
			Projectile.height = 24;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		int Timer;
		int airtimer;
		int halfHP;
		int tooManyEnemies;
        //int tmeCounter;
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
            var modPlayer = Main.LocalPlayer.GetModPlayer<LinkPlayer>();

            if (player.dead)
			{
				//Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/OmoChaoPlayerDeath"));
				modPlayer.HyrulePet = false;
			}
			
			if (modPlayer.HyrulePet)
			{
				Projectile.timeLeft = 2;
			}
			
			AdjustMagnitude(ref Projectile.velocity);
			Vector2 move = Vector2.Zero;
			float distance = 800f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5
				&& Main.npc[k].type != NPCID.TargetDummy)
				{
					Vector2 newMove = Main.npc[k].Center - Projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove + new Vector2(0, -70);
						distance = distanceTo;
						target = true;
					}
				}
			}
			
			if (target)
			{
				AdjustMagnitude(ref move);
				Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
				AdjustMagnitude(ref Projectile.velocity);
				if (Timer > 300)
				{
					SoundEngine.PlaySound(new SoundStyle($"{nameof(TheLegendOfTerra)}/Content/Sounds/Pets/NaviWatchout"));
                    Timer = 0;
				}
				
				if (Timer > 400)
                {
                    SoundEngine.PlaySound(new SoundStyle($"{nameof(TheLegendOfTerra)}/Content/Sounds/Pets/NaviLook"));
					Timer = 0;
				}
				
				if (Timer > 900)
				{
					SoundEngine.PlaySound(new SoundStyle($"{nameof(TheLegendOfTerra)}/Content/Sounds/Pets/NaviHey"));
					Timer = 0;
				}
				Timer++;
			}

            if (player.breath == 80 && airtimer > 300)
            {
                SoundEngine.PlaySound(new SoundStyle($"{nameof(TheLegendOfTerra)}/Content/Sounds/Pets/NaviWatchout"));
                airtimer = 0;
            }
            airtimer++;
			
            if (player.statLife < player.statLifeMax2 / 2 && halfHP > 1000)
            {
                SoundEngine.PlaySound(new SoundStyle($"{nameof(TheLegendOfTerra)}/Content/Sounds/Pets/NaviWatchout"));
                halfHP = 0;
            }
                halfHP++;
		
			if (player.ZoneDesert)
			{
				AdjustMagnitude(ref move);
				Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
				AdjustMagnitude(ref Projectile.velocity);
				if (Timer > 1000)
                {
                    SoundEngine.PlaySound(new SoundStyle($"{nameof(TheLegendOfTerra)}/Content/Sounds/Pets/NaviHello"));
					Timer = 0;
				}
				Timer++;
			}
		}
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 10f) //Determines how fast it follows you, the higher the faster
			{
				vector *= 10f / magnitude; //Determines how fast it follows you, the higher the faster
			}
		}
	}
}
