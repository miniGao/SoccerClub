using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models
{
    public class FakeClubRepository /*: IClubRepository*/
    {
        private static List<Club> clubs = new List<Club>
        {
            new Club
            {
                Name = "Combative Cheetahs",
                Information="Founded in 2015, Combative Cheetahs Soccer Club is the largest recreational club in the City of Nicholasville.",
                Address="93 Illinois Ave. Nicholasville, KY 40356",
                Phone="(636) 234-1885",
                Players= new List<Player>
                {
                    new Player
                    {
                        Name="Ben Bannister",
                        Age=15,
                        Position="Goalkeeper"
                    },
                    new Player
                    {
                        Name="Eliza Russo",
                        Age=16,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Divine Dudley",
                        Age=18,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Mikolaj Morrison",
                        Age=17,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Piotr Houston",
                        Age=18,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Ernest Ahmed",
                        Age=16,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Kaine Strong",
                        Age=18,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Jordyn Love",
                        Age=15,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Jaden Bender",
                        Age=18,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Matei Alford",
                        Age=16,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Willard Gray",
                        Age=16,
                        Position="Midfielder"
                    }
                }
            },
            new Club
            {
                Name = "Dark Crocodiles",
                Information="Founded in 2017, Dark Crocodiles Soccer Club currently has 11 registrations.",
                Address="8772 East Acacia St. Mchenry, IL 60050",
                Phone="(312) 402-4161",
                Players= new List<Player>
                {
                    new Player
                    {
                        Name="Tracy Wilson",
                        Age=19,
                        Position="Goalkeeper"
                    },
                    new Player
                    {
                        Name="Wilbur Quinn",
                        Age=20,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Joe Aguilar",
                        Age=19,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Virgil Butler",
                        Age=20,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Kristopher Baker",
                        Age=21,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Shannon Sims",
                        Age=16,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Ryan Brock",
                        Age=21,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Harry Sanchez",
                        Age=15,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Samuel Green",
                        Age=17,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Horace Luna",
                        Age=20,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Jamie Moore",
                        Age=21,
                        Position="Defender"
                    }
                }
            },
            new Club
            {
                Name = "Striking Falcons",
                Information="Founded in 2020, Striking Falcons Soccer Club has approximately 95% of the club's members under the age of 19.",
                Address="983 Buttonwood St. Oak Lawn, IL 60453",
                Phone="(636) 234-1885",
                Players= new List<Player>
                {
                    new Player
                    {
                        Name="Jesse Simon",
                        Age=19,
                        Position="Goalkeeper"
                    },
                    new Player
                    {
                        Name="Walter Sanders",
                        Age=17,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Franklin Collier",
                        Age=21,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Ronald Lamb",
                        Age=20,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Loren Bates",
                        Age=16,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Sylvester Christensen",
                        Age=17,
                        Position="Forward"
                    },
                    new Player
                    {
                        Name="Miguel Henry",
                        Age=16,
                        Position="Midfielder"
                    },
                    new Player
                    {
                        Name="Billy Gomez",
                        Age=17,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Kenneth Porter",
                        Age=18,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Marc Parks",
                        Age=20,
                        Position="Defender"
                    },
                    new Player
                    {
                        Name="Brad Walton",
                        Age=19,
                        Position="Midfielder"
                    }
                }
            }
        };
        public IQueryable<Club> Clubs => clubs.AsQueryable<Club>();

        public void AddClub(Club club)
        {
            clubs.Add(club);
        }
    }
}
