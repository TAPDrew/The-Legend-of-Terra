using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheLegendofTerra.content.Projectiles
{
    public class IceBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.FrostBeam);
            AIType = ProjectileID.FrostBeam;
            Projectile.friendly = true;
            Projectile.hostile = false;
        }

        public override string
          
            Texture => "Terraria/Images/Projectile_257";
    }
}
