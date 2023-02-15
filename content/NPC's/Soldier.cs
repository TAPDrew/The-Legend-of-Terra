using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OpenAITest
{
    public class Soldier : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soldier");
            Main.npcFrameCount[NPC.type] = 1;
        }

        public override void SetDefaults()
        {
            NPC.width = 34;
            NPC.height = 56;
            NPC.aiStyle = -1;
            NPC.damage = 12;
            NPC.defense = 5;
            NPC.lifeMax = 50;
            NPC.knockBackResist = 0.5f;
            NPC.value = 25f;
            NPC.scale = 1.2f;
            NPC.npcSlots = 1f;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.15f;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * NPC.height;
        }

        public override void AI()
        {
            NPC.TargetClosest(true);

            // If the player is within 3 blocks, turn around and target the player
            if (NPC.Distance(Main.player[NPC.target].Center) <= 48f)
            {
                NPC.TargetClosest(true);
                if (Main.player[NPC.target].position.X < NPC.position.X)
                {
                    NPC.direction = -1;
                }
                else
                {
                    NPC.direction = 1;
                }
                NPC.velocity.X = 0;
            }
            else // Otherwise, patrol back and forth
            {
                if (NPC.ai[0] == 0) // Start patrolling to the left
                {
                    NPC.velocity.X = -2f;
                    if (NPC.collideX)
                    {
                        NPC.ai[0] = 1; // Switch to patrolling to the right
                    }
                }
                else // Start patrolling to the right
                {   
                    NPC.velocity.X = 2f;
                    if (NPC.collideX)
                    {
                        NPC.ai[0] = 0; // Switch to patrolling to the left
                    }
                }
            }
        }
    }
}
