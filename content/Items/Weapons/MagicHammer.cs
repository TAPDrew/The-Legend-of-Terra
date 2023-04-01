using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TheLegendofTerra.Content.Items.Weapons
{
	public class MagicHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Hammer");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Melee;
			Item.damage = 200;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
		}
		private int cooldown;

		public override void HoldItem(Player player)
		{
			if (cooldown > 0)
			{
				cooldown--;
			}
		}
		public override bool? UseItem(Player player)
		{
			if (Main.rand.Next(10) == 0) // 10% chance
			{
				if (cooldown == 0)
				{
					Vector2 playerPos = player.position;
					int radius = 700;
					int damage = Item.damage;

					for (int i = 0; i < Main.npc.Length; i++)
					{
						NPC target = Main.npc[i];
						if (target.active && !target.friendly && Vector2.Distance(playerPos, target.position) <= radius)
						{
							target.StrikeNPC(damage, 0f, player.direction);
							if (Main.netMode != NetmodeID.SinglePlayer)
							{
								NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, target.whoAmI, damage, 0f, player.direction);
							}
						}
					}

					for (int i = 0; i < 20; i++)
					{
						int dustType = DustID.WhiteTorch;
						Dust.NewDust(playerPos, player.width, player.height, dustType, 0f, -1.5f, 100, default(Color), 2f);
					}

					cooldown = 1800;
				}

				return true;
			}
			return false;
		}

	}
}
