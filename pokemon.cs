using UnityEngine;

[System.Serializable]
public class Pokemon
{
    public string name;
    public string url;

    public Pokemon(string name, string url)
    {
        this.name = name;
        this.url = url;
    }

    public void display()
    {
        Debug.Log($"Name: {this.name}, URL: {this.url}");
    }
}

[System.Serializable]
public class CollectionOfPokemon
{
    public int count;
    public string next;
    public string previous;
    public Pokemon[] results;
}