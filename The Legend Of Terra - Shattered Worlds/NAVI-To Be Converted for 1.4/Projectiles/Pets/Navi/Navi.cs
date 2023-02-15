using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TheLegendOfTerra.Projectiles.Pets.Navi
{
	public class Navi : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Navi");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			
			projectile.width = 36;
			projectile.height = 24;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
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
			Player player = Main.player[projectile.owner];
			LinkPlayer modPlayer = (LinkPlayer)player.GetModPlayer(mod, "LinkPlayer");
			
			if (player.dead)
			{
				Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/OmoChaoPlayerDeath"));
				modPlayer.HyrulePet = false;
			}
			
			if (modPlayer.HyrulePet)
			{
				projectile.timeLeft = 2;
			}
			
			AdjustMagnitude(ref projectile.velocity);
			Vector2 move = Vector2.Zero;
			float distance = 800f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
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
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
				if (Timer > 300)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Navi/NaviWatchout"));
					Timer = 0;
				}
				
				if (Timer > 400)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Navi/NaviLook"));
					Timer = 0;
				}
				
				if (Timer > 900)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Navi/NaviHey"));
					Timer = 0;
				}
				Timer++;
			}

            if (player.breath == 80 && airtimer > 300)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Navi/NaviWatchout"));
                airtimer = 0;
            }
            airtimer++;
			
            if (player.statLife < player.statLifeMax2 / 2 && halfHP > 1000)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Navi/NaviWatchout"));
                halfHP = 0;
            }
                halfHP++;
		
			if (player.ZoneDesert)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
				if (Timer > 1000)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Navi/NaviHello"));
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