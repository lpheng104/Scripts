using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

// Define a class to represent a Pokemon
public class Pokemon
{
    public string name;
    public string url;

    public Pokemon(string _name, string _url)
    {
        name = _name;
        url = _url;
    }
}

public class pokemonAPI : MonoBehaviour
{
    public Text displayText; 

    void Start()
    {
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/pokemon?offset=0&limit=2000"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                PokemonCollection pokemonCollection = JsonUtility.FromJson<PokemonCollection>(jsonResponse);
                foreach (Pokemon pokemon in pokemonCollection.results)
                {
                    displayText.text += "Name: " + pokemon.name + "\n";
                    displayText.text += "URL: " + pokemon.url + "\n\n";
                }
            }
        }
    }
}

public class PokemonCollection
{
    public Pokemon[] results;
}
