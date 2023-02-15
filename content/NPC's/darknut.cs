using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace openaitest
{
    public class Darknut : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 34;
            NPC.height = 56;
            NPC.lifeMax = 10000;
            NPC.damage = 30;
            NPC.defense = 40;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 3;
            NPC.npcSlots = 1f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            NPC.TargetClosest(true);

            // Check if player is behind Darknut
            bool behindPlayer = false;
            if (Main.player[NPC.target].position.X < NPC.position.X)
            {
                behindPlayer = true;
            }

            // If player is not behind Darknut, Darknut takes reduced damage
            if (!behindPlayer)
            {
                NPC.defense = 400;
            }
            else
            {
                // If player is behind Darknut, Darknut takes increased damage
                NPC.defense = 40;
            }
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            // Check if player is attacking from the front, above, or below
            if (player.position.X > NPC.position.X + NPC.width || player.position.X + player.width < NPC.position.X || player.position.Y > NPC.position.Y + NPC.height || player.position.Y + player.height < NPC.position.Y)
            {
                // If player is attacking from the front, above, or below, Darknut takes no damage
                damage = 0;
            }

            base.OnHitByItem(player, item, damage, knockback, crit);
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            // Check if projectile is attacking from the front, above, or below
            if (projectile.position.X > NPC.position.X + NPC.width || projectile.position.X + projectile.width < NPC.position.X || projectile.position.Y > NPC.position.Y + NPC.height || projectile.position.Y + projectile.height < NPC.position.Y)
            {
                // If projectile is attacking from the front, above, or below, Darknut takes no damage
                damage = 0;
            }

            base.OnHitByProjectile(projectile, damage, knockback, crit);
        }
    }
}