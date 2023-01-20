using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int wakeTime;
        public int sleepTime;

        public SpeciesInfo()
        {
            species = Species.Undetermined;
            nature = Nature.Undetermined;
            lifeStage = LifeStage.Egg;
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
            
            wakeTime = 0 * 60 * 60 +5;
            sleepTime = 25 * 60 * 60;  // sleep time is never reached b/c it does not sleep through the night until evolve to child
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
            
            wakeTime = 0 * 60 * 60;
            sleepTime = 25 * 60 * 60;  // sleep time is never reached b/c it does not sleep through the night until evolve to child
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

            wakeTime = 8 * 60 * 60;
            sleepTime = 20 * 60 * 60;
        }
    }

    internal class Kinakomotchi : SpeciesInfo
    {
        public Kinakomotchi()
        {
            species = Species.Kinakomotchi;
            nature = Nature.Undetermined;
            lifeStage = LifeStage.Child;

            wakeTime = 9 * 60 * 60;
            sleepTime = 20 * 60 * 60;
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

            wakeTime = 9 * 60 * 60;
            sleepTime = 20 * 60 * 60;
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

            wakeTime = 9 * 60 * 60;
            sleepTime = 20 * 60 * 60;
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

            wakeTime = 10 * 60 * 60;
            sleepTime = 21 * 60 * 60;
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

            wakeTime = 10 * 60 * 60;
            sleepTime = 21 * 60 * 60;
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
            
            wakeTime = 8 * 60 * 60;
            sleepTime = 21 * 60 * 60;
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

            wakeTime = 8 * 60 * 60;
            sleepTime = 21 * 60 * 60;
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

            wakeTime = 9 * 60 * 60;
            sleepTime = 22 * 60 * 60;
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

            wakeTime = 9 * 60 * 60;
            sleepTime = 22 * 60 * 60;
        }
    }

    internal class Tarakotchi : SpeciesInfo
    {
        public Tarakotchi()
        {
            species = Species.Tarakotchi;
            nature = Nature.Naughty;
            lifeStage = LifeStage.Adult;

            wakeTime = 8 * 60 * 60;
            sleepTime = 22 * 60 * 60;
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

            wakeTime = 9 * 60 * 60;
            sleepTime = 21 * 60 * 60;
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

            wakeTime = 9 * 60 * 60;
            sleepTime = 21 * 60 * 60;
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

            wakeTime = 10 * 60 * 60;
            sleepTime = 23 * 60 * 60;
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

            wakeTime = 10 * 60 * 60;
            sleepTime = 23 * 60 * 60;
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

            wakeTime = 9 * 60 * 60;
            sleepTime = 22 * 60 * 60;
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

            wakeTime = 7 * 60 * 60;
            sleepTime = 20 * 60 * 60;
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

            wakeTime = 7 * 60 * 60;
            sleepTime = 20 * 60 * 60;
        }
    }
}