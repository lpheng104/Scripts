using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ItemController : MonoBehaviour
{
    public TextMeshProUGUI[] itemLabels;
    private List<Item> itemsList;
    private int currentIndex = 0;

    
    void Start()
    {
        itemsList = ParseJsonFile();

        DisplayItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = Mathf.Min(currentIndex + 4, itemsList.Count - 1);
            DisplayItems();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex = Mathf.Max(currentIndex - 4, 0);
            DisplayItems();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentIndex < itemsList.Count)
        {
            Debug.Log("Selected item: " + itemsList[currentIndex].name);
        }
    }

    void DisplayItems()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = currentIndex + i;
            if (index < itemsList.Count)
            {
                itemLabels[i].text = $"{index + 1}. {itemsList[index].name}";
            }
            else
            {
                itemLabels[i].text = "";
            }
        }
    }

    List<Item> ParseJsonFile()
    {
        return new List<Item>(); 
    }
}
