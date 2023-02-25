using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.SpriteSheetClasses.Species
{
    internal class SpriteLocation
    {
        public int y;
        public int x;
        public enum spriteNames
        {
            angry,
            back,
            bath1,
            bath2,
            bed1,
            bed2,
            begging,
            boots,
            bow1,
            bow2,
            bowtie1,
            bowtie2,
            brushing_teeth1,
            brushing_teeth2,
            bubbles1,
            bubbles2,
            cap1,
            cap2,
            cape1,
            cape2,
            closeup1,
            closeup2,
            closeup3,
            crouching,
            darts1,
            darts2,
            eating1,
            eating2,
            eyes_closed,
            hair_gel1,
            hair_gel2,
            hatching,
            happy,
            idle1,
            idle2,
            kissing,
            maracas,
            matchmaking1,
            matchmaking2,
            no,
            pencil1,
            pencil2,
            pencil3,
            rolling1,
            rolling2,
            rolling3,
            rolling4,
            running1,
            running2,
            running3,
            sad,
            singing1,
            singing2,
            sitting1,
            sitting2,
            skateboard1,
            skateboard2,
            spark,
            wig1,
            wig2,
            wings1,
            wings2
        }

        public spriteNames spriteName;
        public bool isMirrored;

        public SpriteLocation(int y, int x, spriteNames spriteName, bool isMirrored=false)
        {
            this.y = y;
            this.x = x;
            this.spriteName = spriteName;
            this.isMirrored = isMirrored;
        }
    }
}
