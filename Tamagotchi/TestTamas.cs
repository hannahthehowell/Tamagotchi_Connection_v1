using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    internal class TestTama : Pet
    {
        public TestTama()
        {
            hunger = 4;
            happiness = 4;
            minutesAlive = 7 * 60 * 24;
            isAging = false;

            givenName = "";
            weight = 1;
            age = 7;
            training = 9;

            parent1Nature = SpeciesInfo.Nature.Undetermined;
            parent2Nature = SpeciesInfo.Nature.Undetermined;
            isChildOfSenior = false;
            generationNumber = 5;

            hasBaby = false;
            minutesWithBaby = 0;

            numMentalMistakes = 0;
            numPhysicalMistakes = 0;

            careTier = CareTier.D;

            sex = Sex.Male;
            speciesInfo = new Masktchi();
        }
    }
}
