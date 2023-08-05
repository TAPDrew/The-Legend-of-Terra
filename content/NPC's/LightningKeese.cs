﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;

//Need to fix animation on all Keese

namespace TheLegendofTerra.Content.NPCs
{
    public class LightningKeese : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electric Keese");

            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.CaveBat];

        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 14; // Fighter AI, important to choose the aiStyle that matches the NPCID that we want to mimic

            AIType = NPCID.CaveBat;
            AnimationType = NPCID.CaveBat;
            Banner = Item.NPCtoBanner(NPCID.CaveBat);
            BannerItem = Item.BannerToItem(Banner);

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Jungle.Chance * 0.5f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Confetti)); // 1% chance to drop Confetti
        }
    }
}