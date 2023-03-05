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
            hunger = 6;
            happiness = 2;
            minutesAlive = 7 * 60 * 24;
            isAging = false;

            givenName = "Joel";
            weight = 22;
            age = 7;
            training = 3;

            parent1Nature = SpeciesInfo.Nature.Undetermined;
            parent2Nature = SpeciesInfo.Nature.Undetermined;
            isChildOfSenior = false;
            generationNumber = 4;

            hasBaby = false;
            minutesWithBaby = 0;

            numMentalMistakes = 0;
            numPhysicalMistakes = 0;

            careTier = CareTier.D;

            sex = Sex.Female;
            speciesInfo = new Masktchi();
        }
    }
}
