using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tamagotchi
{
    internal class Pet
    {
        public enum Sex
        {
            Undetermined,
            Male,
            Female
        }
        public enum CareTier
        {
            Undetermined,
            A, B, C, D
        }

        public double hunger = 0;
        public double happiness = 0;
        public double timeAlive = 0;
        public bool isAging = false;

        public string givenName = "";
        public int weight = 1;
        public int age = 0;
        public int training = 0;

        public SpeciesInfo.Nature parent1Nature = SpeciesInfo.Nature.Undetermined;
        public SpeciesInfo.Nature parent2Nature = SpeciesInfo.Nature.Undetermined;
        public bool isChildOfSenior = false;
        public int generationNumber = 0;

        public int numMentalMistakes = 0;
        public int numPhysicalMistakes = 0;

        public CareTier careTier = CareTier.Undetermined;

        public Sex sex;
        public SpeciesInfo speciesInfo;

        // When creating a pet for the first time
        public Pet()
        {
            generationNumber = 1;
            
            sex = Sex.Undetermined;
            speciesInfo = new SpeciesInfo();
        }

        // When creating a pet as the child of an existing pet
        public Pet(Pet PrimaryParent, Pet SecondParent)
        {
            parent1Nature = PrimaryParent.speciesInfo.nature;
            parent2Nature = SecondParent.speciesInfo.nature;
            generationNumber = PrimaryParent.generationNumber + 1;

            switch (PrimaryParent.speciesInfo.lifeStage)
            {
                case SpeciesInfo.LifeStage.Senior:
                    sex = Sex.Male;
                    isChildOfSenior = true;
                    break;
                default:
                    sex = (Sex)(new Random().Next(1, Enum.GetNames(typeof(Sex)).Length));
                    break;
            }

            switch (sex)
            {
                case Sex.Male:
                    speciesInfo = new Babytchi();
                    break;
                case Sex.Female:
                    speciesInfo = new Shirobabytchi();
                    break;
            }
        }

        // When creating an NPC pet
        public Pet(Pet CurrentPet, bool isFromMatchMaker = false)
        {
            // If the NPC is a marriage candidate from the Match Maker
            if (isFromMatchMaker)
            {
                // Set the sex to the opposite of your pet
                switch (CurrentPet.sex)
                {
                    case Sex.Female:
                        sex = Sex.Male;
                        break;
                    case Sex.Male:
                        sex = Sex.Female;
                        break;
                }

                // Get the species info based on senior or adult
                switch (CurrentPet.speciesInfo.lifeStage)
                {
                    case SpeciesInfo.LifeStage.Senior:
                        switch (sex)
                        {
                            case Sex.Male:
                                speciesInfo = new Ojitchi();
                                break;
                            case Sex.Female:
                                speciesInfo = new Otokitchi();
                                break;
                        }
                        break;
                    case SpeciesInfo.LifeStage.Adult:
                        SpeciesInfo.Species speciesName = (SpeciesInfo.Species)(new Random().Next(9, 18));
                        
                        string speciesNameStr = speciesName.ToString();
                        speciesInfo = (SpeciesInfo)Activator.CreateInstance(Type.GetType(speciesNameStr));

                        /*switch (speciesName)
                        {
                            case SpeciesInfo.Species.Mametchi:
                                speciesInfo = new Mametchi();
                                break;
                            case SpeciesInfo.Species.Mimitchi:
                                speciesInfo = new Mimitchi();
                                break;
                            case SpeciesInfo.Species.Kuchipatchi:
                                speciesInfo = new Kuchipatchi();
                                break;
                            case SpeciesInfo.Species.Memetchi:
                                speciesInfo = new Memetchi();
                                break;
                            case SpeciesInfo.Species.Tarakotchi:
                                speciesInfo = new Tarakotchi();
                                break;
                            case SpeciesInfo.Species.Hanatchi:
                                speciesInfo = new Hanatchi();
                                break;
                            case SpeciesInfo.Species.Androtchi:
                                speciesInfo = new Androtchi();
                                break;
                            case SpeciesInfo.Species.Masktchi:
                                speciesInfo = new Masktchi();
                                break;
                            case SpeciesInfo.Species.Gozarutchi:
                                speciesInfo = new Gozarutchi();
                                break;
                        }*/
                        break;
                        
                }
                
            }
            // If the NPC is a playmate
            else
            {
                // Get species info
                SpeciesInfo.Species speciesName = (SpeciesInfo.Species)(new Random().Next(3, Enum.GetNames(typeof(SpeciesInfo.Species)).Length));

                string speciesNameStr = speciesName.ToString();
                speciesInfo = (SpeciesInfo)Activator.CreateInstance(Type.GetType(speciesNameStr));

                // Get sex
                if (speciesInfo.SexExclusive)
                {
                    sex = speciesInfo.SexAvailable;
                }
                else
                {
                    sex = (Sex)(new Random().Next(1, Enum.GetNames(typeof(Sex)).Length));
                }
            }

            // Generate a name for the NPC based on sex
            string[] nameList;
            if (sex == Sex.Male)
            {
                nameList = File.ReadAllLines("AdditionalFiles/BoyNames.txt");
            }
            else
            {
                nameList = File.ReadAllLines("AdditionalFiles/GirlNames.txt");
            }

            Random rnd = new Random();
            int num = rnd.Next(0, nameList.Length);
            givenName = nameList[num];
        }

        // When hatching an egg for the first time
        public void Hatch()
        {
            sex = (Sex)(new Random().Next(1, Enum.GetNames(typeof(Sex)).Length));
            switch (sex)
            {
                case Sex.Male:
                    speciesInfo = new Babytchi();
                    break;
                case Sex.Female:
                    speciesInfo = new Shirobabytchi();
                    break;
            }
        }
        // When the parent leaves the baby
        public void BecomeIndependent()
        {
            speciesInfo.lifeStage = SpeciesInfo.LifeStage.Baby;
        }

        public void SetName(string name) { givenName = name; }

        public void BeginAging() { isAging = true; }

        public void StopAging() { isAging = false; }

        public void Evolve()
        {
            
        }

        public void Death()
        {

        }
    }
}
