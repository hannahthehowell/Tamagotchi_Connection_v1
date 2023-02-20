using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tamagotchi.SpriteSheetClasses.Species;
using static Tamagotchi.SpriteSheetClasses.Species.SpriteLocation;

namespace Tamagotchi
{
    internal class SpeciesInfo
    {
        public enum Generation
        {
            Even,
            Odd
        }
        public enum Species
        {
            Undetermined,

            //BabySpecies
            Babytchi,
            Shirobabytchi,

            //ChildSpecies
            Marutchi,
            Kinakomotchi,

            //TeenSpecies
            Ichigotchi,
            Young_Mimitchi,
            Hinotamatchi,
            Oniontchi,

            //AdultSpecies
            Mametchi,
            Mimitchi,
            Kuchipatchi,
            Memetchi,
            Tarakotchi,
            Hanatchi,
            Androtchi,
            Masktchi,
            Gozarutchi,
            Oyajitchi,

            //SeniorSpecies
            Ojitchi,
            Otokitchi
        }
        public enum Nature
        {
            Undetermined,
            Serious,
            Normal,
            Naughty,
            Frail,
            Stubborn
        }
        public enum LifeStage
        {
            Egg,
            Dependent,
            Baby,
            Child,
            Teen,
            Adult,
            Senior
        }

        public Species species;
        public Nature nature;
        public LifeStage lifeStage;

        public bool GenerationExclusive = false;
        public Generation GenerationAvailable;
        public bool SexExclusive = false;
        public Pet.Sex SexAvailable;

        public TimeSpan wakeTime;
        public TimeSpan sleepTime;

        public SpeciesSprites sprites;
        public SpriteLocation[] idleSequence1;
        public SpriteLocation[] idleSequence2;

        public SpeciesInfo()
        {
            species = Species.Undetermined;
            nature = Nature.Undetermined;
            lifeStage = LifeStage.Egg;

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/EggSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);

            idleSequence1 = new SpriteLocation[] {
                new SpriteLocation(19, 11, spriteNames.idle1),
                new SpriteLocation(19, 11, spriteNames.idle1),
                new SpriteLocation(21, 10, spriteNames.idle2),
                new SpriteLocation(21, 10, spriteNames.idle2)
            };
        }
    }


    // Baby Species
    internal class Babytchi : SpeciesInfo
    {
        public Babytchi(bool isFirstGen = false)
        {
            species = Species.Babytchi;
            nature = Nature.Undetermined;
            lifeStage = isFirstGen ? LifeStage.Baby : LifeStage.Dependent;
            
            GenerationExclusive = false;
            SexExclusive = true;
            SexAvailable = Pet.Sex.Male;
            
            wakeTime = TimeSpan.Parse("00:00");
            sleepTime = TimeSpan.Parse("11:59:59");  // sleep time is never reached b/c it does not sleep through the night until evolve to child

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/BabytchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Shirobabytchi : SpeciesInfo
    {
        public Shirobabytchi(bool isFirstGen = false)
        {
            species = Species.Shirobabytchi;
            nature = Nature.Undetermined;
            lifeStage = isFirstGen ? LifeStage.Baby : LifeStage.Dependent;

            SexExclusive = true;
            SexAvailable = Pet.Sex.Female;
            
            wakeTime = TimeSpan.Parse("00:00");
            sleepTime = TimeSpan.Parse("11:59:59");  // sleep time is never reached b/c it does not sleep through the night until evolve to child

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/ShirobabytchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    // Child Species
    internal class Marutchi : SpeciesInfo
    {
        public Marutchi()
        {
            species = Species.Marutchi;
            nature = Nature.Undetermined;
            lifeStage = LifeStage.Child;

            wakeTime = TimeSpan.Parse("08:00");
            sleepTime = TimeSpan.Parse("20:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/MarutchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Kinakomotchi : SpeciesInfo
    {
        public Kinakomotchi()
        {
            species = Species.Kinakomotchi;
            nature = Nature.Undetermined;
            lifeStage = LifeStage.Child;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("20:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/KinakomotchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    // Teen Species
    internal class Ichigotchi : SpeciesInfo
    {
        public Ichigotchi()
        {
            species = Species.Ichigotchi;
            nature = Nature.Serious;
            lifeStage = LifeStage.Teen;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Odd;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("20:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/IchigotchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Young_Mimitchi : SpeciesInfo
    {
        public Young_Mimitchi()
        {
            species = Species.Young_Mimitchi;
            nature = Nature.Serious;
            lifeStage = LifeStage.Teen;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Even;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("20:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/Young_MimitchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Hinotamatchi : SpeciesInfo
    {
        public Hinotamatchi()
        {
            species = Species.Hinotamatchi;
            nature = Nature.Normal;
            lifeStage = LifeStage.Teen;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Odd;

            wakeTime = TimeSpan.Parse("10:00");
            sleepTime = TimeSpan.Parse("21:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/HinotamotchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Oniontchi : SpeciesInfo
    {
        public Oniontchi()
        {
            species = Species.Oniontchi;
            nature = Nature.Normal;
            lifeStage = LifeStage.Teen;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Even;

            wakeTime = TimeSpan.Parse("10:00");
            sleepTime = TimeSpan.Parse("21:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/OniontchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    // Adult Species
    internal class Mametchi : SpeciesInfo
    {
        public Mametchi()
        {
            species = Species.Mametchi;
            nature = Nature.Serious;
            lifeStage = LifeStage.Adult;
            
            GenerationExclusive = true;
            GenerationAvailable = Generation.Odd;
            
            wakeTime = TimeSpan.Parse("08:00");
            sleepTime = TimeSpan.Parse("21:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/MametchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Mimitchi : SpeciesInfo
    {
        public Mimitchi()
        {
            species = Species.Mimitchi;
            nature = Nature.Serious;
            lifeStage = LifeStage.Adult;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Even;

            wakeTime = TimeSpan.Parse("08:00");
            sleepTime = TimeSpan.Parse("21:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/MimitchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Kuchipatchi : SpeciesInfo
    {
        public Kuchipatchi()
        {
            species = Species.Kuchipatchi;
            nature = Nature.Normal;
            lifeStage = LifeStage.Adult;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Odd;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("22:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/KuchipatchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Memetchi : SpeciesInfo
    {
        public Memetchi()
        {
            species = Species.Memetchi;
            nature = Nature.Normal;
            lifeStage = LifeStage.Adult;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Even;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("22:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/MemetchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Tarakotchi : SpeciesInfo
    {
        public Tarakotchi()
        {
            species = Species.Tarakotchi;
            nature = Nature.Naughty;
            lifeStage = LifeStage.Adult;

            wakeTime = TimeSpan.Parse("08:00");
            sleepTime = TimeSpan.Parse("22:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/TarakotchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Hanatchi : SpeciesInfo
    {
        public Hanatchi()
        {
            species = Species.Hanatchi;
            nature = Nature.Frail;
            lifeStage = LifeStage.Adult;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Odd;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("21:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/HanatchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Androtchi : SpeciesInfo
    {
        public Androtchi()
        {
            species = Species.Androtchi;
            nature = Nature.Frail;
            lifeStage = LifeStage.Adult;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Even;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("21:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/AndrotchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Masktchi : SpeciesInfo
    {
        public Masktchi()
        {
            species = Species.Masktchi;
            nature = Nature.Stubborn;
            lifeStage = LifeStage.Adult;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Odd;

            wakeTime = TimeSpan.Parse("10:00");
            sleepTime = TimeSpan.Parse("23:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/MasktchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);

            idleSequence1 = new SpriteLocation[] {  // sequence to go left and jump, then right and crouch
                new SpriteLocation(9, 9, spriteNames.idle1),
                new SpriteLocation(8, 9, spriteNames.idle2),
                new SpriteLocation(9, 7, spriteNames.idle1),
                new SpriteLocation(8, 7, spriteNames.idle2),
                new SpriteLocation(9, 7, spriteNames.idle1),
                new SpriteLocation(8, 7, spriteNames.idle2),
                new SpriteLocation(9, 1, spriteNames.idle1),
                new SpriteLocation(9, 1, spriteNames.idle1),
                new SpriteLocation(5, 1, spriteNames.idle2),
                new SpriteLocation(8, 1, spriteNames.idle2),
                new SpriteLocation(11, 1, spriteNames.eyes_closed),
                new SpriteLocation(8, 1, spriteNames.idle2),
                new SpriteLocation(11, 1, spriteNames.eyes_closed),
                new SpriteLocation(8, 1, spriteNames.idle2),
                new SpriteLocation(9, 5, spriteNames.idle1),
                new SpriteLocation(8, 5, spriteNames.idle2),
                new SpriteLocation(9, 9, spriteNames.idle1),
                new SpriteLocation(8, 9, spriteNames.idle2),
                new SpriteLocation(9, 11, spriteNames.idle1),
                new SpriteLocation(8, 13, spriteNames.idle2),
                new SpriteLocation(9, 13, spriteNames.idle1),
                new SpriteLocation(8, 17, spriteNames.idle2),
                new SpriteLocation(11, 17, spriteNames.eyes_closed),
                new SpriteLocation(8, 17, spriteNames.idle2),
                new SpriteLocation(11, 17, spriteNames.eyes_closed),
                new SpriteLocation(8, 17, spriteNames.idle2),
                new SpriteLocation(9, 13, spriteNames.idle1),
                new SpriteLocation(5, 11, spriteNames.idle2),
                new SpriteLocation(9, 9, spriteNames.idle1),
                new SpriteLocation(8, 9, spriteNames.idle2),
                new SpriteLocation(9, 9, spriteNames.idle1),
                new SpriteLocation(8, 9, spriteNames.idle2)
            };

            idleSequence2 = new SpriteLocation[] {  // sequence to go right and crouch
                new SpriteLocation(9, 9, spriteNames.idle1),
                new SpriteLocation(8, 9, spriteNames.idle2),
                new SpriteLocation(9, 11, spriteNames.idle1),
                new SpriteLocation(8, 13, spriteNames.idle2),
                new SpriteLocation(9, 13, spriteNames.idle1),
                new SpriteLocation(8, 17, spriteNames.idle2),
                new SpriteLocation(11, 17, spriteNames.eyes_closed),
                new SpriteLocation(8, 17, spriteNames.idle2),
                new SpriteLocation(11, 17, spriteNames.eyes_closed),
                new SpriteLocation(8, 17, spriteNames.idle2),
                new SpriteLocation(9, 13, spriteNames.idle1),
                new SpriteLocation(5, 11, spriteNames.idle2),
                new SpriteLocation(9, 9, spriteNames.idle1),
                new SpriteLocation(8, 9, spriteNames.idle2),
                new SpriteLocation(9, 9, spriteNames.idle1),
                new SpriteLocation(8, 9, spriteNames.idle2)
            };
        }
    }

    internal class Gozarutchi : SpeciesInfo
    {
        public Gozarutchi()
        {
            species = Species.Gozarutchi;
            nature = Nature.Stubborn;
            lifeStage = LifeStage.Adult;

            GenerationExclusive = true;
            GenerationAvailable = Generation.Even;

            wakeTime = TimeSpan.Parse("10:00");
            sleepTime = TimeSpan.Parse("23:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/GozarutchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Oyajitchi : SpeciesInfo
    {
        public Oyajitchi()
        {
            species = Species.Oyajitchi;
            nature = Nature.Stubborn;
            lifeStage = LifeStage.Adult;

            SexExclusive = true;    
            SexAvailable = Pet.Sex.Male;

            wakeTime = TimeSpan.Parse("09:00");
            sleepTime = TimeSpan.Parse("22:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/OyajitchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    // Senior Species
    internal class Ojitchi : SpeciesInfo
    {
        public Ojitchi()
        {
            species = Species.Ojitchi;
            nature = Nature.Undetermined;
            lifeStage = LifeStage.Senior;

            SexExclusive = true;
            SexAvailable = Pet.Sex.Male;

            wakeTime = TimeSpan.Parse("07:00");
            sleepTime = TimeSpan.Parse("20:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/OjitchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }

    internal class Otokitchi : SpeciesInfo
    {
        public Otokitchi()
        {
            species = Species.Otokitchi;
            nature = Nature.Undetermined;
            lifeStage = LifeStage.Senior;

            SexExclusive = true;
            SexAvailable = Pet.Sex.Female;

            wakeTime = TimeSpan.Parse("07:00");
            sleepTime = TimeSpan.Parse("20:00");

            string jsonString = File.ReadAllText("../../../SpriteSheets/Species/OtokitchiSpriteSheet.json");
            sprites = JsonSerializer.Deserialize<SpeciesSprites>(jsonString);
        }
    }
}