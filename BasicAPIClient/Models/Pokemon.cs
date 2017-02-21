using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BasicAPIClient.Models
{
    class Pokemon
    {
        public List<Form> forms { get; set; }
        public List<Ability> abilities { get; set; }
        public List<Stat> stats { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
        public List<Move> moves { get; set; }
        public PokeSprites sprites { get; set; }
        public List<object> held_items { get; set; }
        public string location_area_encounters { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; }
        public PokeSpecies species { get; set; }
        public int id { get; set; }
        public int order { get; set; }
        public List<PokeGameIndice> game_indices { get; set; }
        public int base_experience { get; set; }
        public List<PokeType> types { get; set; }
    }

    public class Form
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Ability2
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Ability
    {
        public int slot { get; set; }
        public bool is_hidden { get; set; }
        public Ability2 ability { get; set; }
    }

    public class Stat2
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Stat
    {
        public Stat2 stat { get; set; }
        public int effort { get; set; }
        public int base_stat { get; set; }
    }

    public class MoveLearnMethod
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class PokeVersionGroup
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class VersionGroupDetail
    {
        public MoveLearnMethod move_learn_method { get; set; }
        public int level_learned_at { get; set; }
        public VersionGroup version_group { get; set; }
    }

    public class Move2
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Move
    {
        public List<VersionGroupDetail> version_group_details { get; set; }
        public Move2 move { get; set; }
    }

    public class PokeSprites
    {
        public object back_female { get; set; }
        public object back_shiny_female { get; set; }
        public string back_default { get; set; }
        public object front_female { get; set; }
        public object front_shiny_female { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }

    public class PokeSpecies
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Version
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class PokeGameIndice
    {
        public Version version { get; set; }
        public int game_index { get; set; }
    }

    public class PokeType2
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class PokeType
    {
        public int slot { get; set; }
        public PokeType2 type { get; set; }
    }

    class PokemonCollection
    {
        public int Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
        public List<Pokemon> Results { get; set; }

        private PokemonCollection GetPage(HttpClient client, Uri page)
        {
            if (page != null)
            {
                string pageNumber = page.Query;
                var allPokemonResponse = client.GetAsync($"pokemon{pageNumber}").Result;
                return allPokemonResponse.Content.ReadAsAsync<PokemonCollection>().Result;
            }

            return this;
        }

        public PokemonCollection GetPrevious(HttpClient client)
        {
            return GetPage(client, Previous);
        }

        public PokemonCollection GetNext(HttpClient client)
        {
            return GetPage(client, Next);
        }
    }
}
