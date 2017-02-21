using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAPIClient.Models
{
    class Game
    {
        public List<object> abilities { get; set; }
        public string name { get; set; }
        public List<GameVersionGroup> version_groups { get; set; }
        public int id { get; set; }
        public List<GameName> names { get; set; }
        public List<PokemonSpecy> pokemon_species { get; set; }
        public List<GameMove> moves { get; set; }
        public MainRegion main_region { get; set; }
        public List<GameType> types { get; set; }
    }

    public class GameVersionGroup
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class GameLanguage
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class GameName
    {
        public string name { get; set; }
        public GameLanguage language { get; set; }
    }

    public class PokemonSpecy
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class GameMove
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class MainRegion
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class GameType
    {
        public string url { get; set; }
        public string name { get; set; }
    }
}