using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TheLegendOfTerra.Buffs.Pets.Navi
{
	public class NaviBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Navi");
		    Description.SetDefault("Navi is following you around on your adventure!");
		    Main.buffNoTimeDisplay[Type] = true;
		    Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			//Navi Buffs
			
        
			player.buffTime[buffIndex] = 999999;
			LinkPlayer modPlayer = (LinkPlayer)player.GetModPlayer(mod, "LinkPlayer");
			modPlayer.HyrulePet = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("Navi")] > 0)
			{
				petProjectileNotSpawned = false;
			}
            
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, mod.ProjectileType("Navi"), 0, 0f, player.whoAmI, 0f, 0f);
			}            
		}
	}
}