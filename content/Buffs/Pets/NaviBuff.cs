using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static TheLegendOfTerra.TheLegendOfTerra;

namespace TheLegendOfTerra.Content.Buffs.Pets
{
	public class NaviBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Navi");
		    Description.SetDefault("Navi is following you around on your adventure!");
		    Main.buffNoTimeDisplay[Type] = true;
		    Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 999999;
            var modPlayer = Main.LocalPlayer.GetModPlayer<LinkPlayer>();
            modPlayer.HyrulePet = true;
			bool petProjectileNotSpawned = true;
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Navi").Type] > 0)
			{
				petProjectileNotSpawned = false;
			}
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                var entitySource = player.GetSource_Buff(buffIndex);
                Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, Mod.Find<ModProjectile>("Navi").Type, 0, 0f, player.whoAmI);
			}            
		}
	}
}
