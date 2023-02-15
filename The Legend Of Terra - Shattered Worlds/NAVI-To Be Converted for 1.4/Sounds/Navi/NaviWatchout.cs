using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace TheLegendOfTerra.Sounds.Navi
{
    public class NaviWatchout : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
        {
            soundInstance = sound.CreateInstance();
            soundInstance.Volume = volume * 0.3f;
            soundInstance.Pan = pan;
            soundInstance.Pitch = 0f;
            return soundInstance;
        }
    }
}