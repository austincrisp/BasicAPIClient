using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BasicAPIClient.Models;
using Newtonsoft.Json;

namespace BasicAPIClient
{
    class Program
    {
        public static string Read(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        public static HttpClient client = new HttpClient();

        private static void SetUpClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        static void Main(string[] args)
        {
            SetUpClient();

            bool active = true;
            int choice = 0;

            while (active && choice != 7)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Pokemon API!");
                Console.WriteLine("Please make a choice from the list below to get started!");

                Console.WriteLine("1) List of Pokemon");
                Console.WriteLine("2) Inspect the details of a specific Pokemon");
                Console.WriteLine("3) List of Games");
                Console.WriteLine("4) Inspect the details of a specific Game");
                Console.WriteLine("5) List of Items");
                Console.WriteLine("6) Inspect the details of a specific Item");
                Console.WriteLine("7) Exit");
                choice = int.Parse(Read("> "));

                switch (choice)
                {
                    case 1:
                        GetAllPokemon(client);
                        break;
                    case 2:
                        GetPokemon(client);
                        break;
                    case 3:
                        GetAllGames(client);
                        break;
                    case 4:
                        GetGame(client);
                        break;
                    case 5:
                        GetAllItems(client);
                        break;
                    case 6:
                        GetItem(client);
                        break;
                    case 7:
                        active = false;
                        break;
                    default:
                        break;

                }
            }
        }

        public static void GetPokemon(HttpClient client)
        {
            Console.WriteLine("Choose a pokemon.");
            string id = Console.ReadLine();

            var response = client.GetAsync($"pokemon/{id}").Result;
            Pokemon pokemon = response.Content.ReadAsAsync<Pokemon>().Result;

            
            Console.WriteLine("-Name: " + pokemon.name);
            Console.WriteLine("-Base Exp: " + pokemon.base_experience);
            Console.WriteLine("-Height: " + pokemon.height);
            Console.WriteLine("-Weight: " + pokemon.weight);
            Console.WriteLine("-Order: " + pokemon.order);
            Console.WriteLine("-Default: " + pokemon.is_default);
            Console.WriteLine("-Moves: ");

            foreach (var move in pokemon.moves)
            {
                Console.WriteLine($"->> {move.move.name}");
            }

            /* used this for help - http://www.newtonsoft.com/json/help/html/SerializingJSON.htm
             practice with serialize/deserialize for objects inside the field classes
            string output = JsonConvert.SerializeObject(pokemon);
            Pokemon deserPokemon = JsonConvert.DeserializeObject<Pokemon>(output);

            foreach (PokeType type in deserPokemon.types)
            {
                Console.WriteLine($"{type.slot} - {type.type.name}");
            }
            */

            Console.ReadLine();
        }

        public static void GetAllPokemon(HttpClient client)
        {
            var allPokemonResp = client.GetAsync("pokemon").Result;
            PokemonCollection pokemons = allPokemonResp.Content.ReadAsAsync<PokemonCollection>().Result;

            foreach (var pokemon in pokemons.Results)
            {
                Console.WriteLine($"->> {pokemon.name}");
            }

            Console.ReadLine();
        }

        public static void GetGame(HttpClient client)
        {
            Console.WriteLine("Choose a game (generation).");
            string id = Console.ReadLine();

            var response = client.GetAsync($"generation/{id}").Result;
            Game game = response.Content.ReadAsAsync<Game>().Result;

            Console.WriteLine(game.name);

            foreach (var species in game.pokemon_species)
            {
                Console.WriteLine($"->> {species.name}");
            }

            Console.ReadLine();
        }

        public static void GetAllGames(HttpClient client)
        {
            var allGameResp = client.GetAsync("generation").Result;
            GameCollection games = allGameResp.Content.ReadAsAsync<GameCollection>().Result;

            foreach (var game in games.Results)
            {
                Console.WriteLine($"->> {game.name}");
            }

            Console.ReadLine();
        }

        public static void GetItem(HttpClient client)
        {
            Console.WriteLine("Choose an item.");
            string id = Console.ReadLine();

            var response = client.GetAsync($"item/{id}").Result;
            Item item = response.Content.ReadAsAsync<Item>().Result;

            Console.WriteLine("-Name: " + item.name);
            Console.WriteLine("-Cost: " + item.cost);
            Console.WriteLine("-Attributes: ");

            foreach (var attribute in item.attributes)
            {
                Console.WriteLine($"->> {attribute.name}");
            }

            Console.ReadLine();
        }

        public static void GetAllItems(HttpClient client)
        {
            var allItemResp = client.GetAsync("item").Result;
            ItemCollection items = allItemResp.Content.ReadAsAsync<ItemCollection>().Result;

            foreach (var item in items.Results)
            {
                Console.WriteLine($"->> {item.name}");
            }

            Console.ReadLine();
        }
    }
}
