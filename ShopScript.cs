using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;


public class ShopScript : MonoBehaviour
{
    public GameObject powerCherry;
    public TextMeshPro priceDisplay;
    public TextMeshProUGUI Narrator, PelletDisplay;
    private int cherryPrice = 1;
    private bool isItemBought = false;
    private int tickCounter = 0;
    private bool tickSwitch = false;


    void Start()
    {
        this.priceDisplay.text = "" + cherryPrice;
        this.PelletDisplay.text = "Pellets: " + MySingleton.PelletCounter;
        checkPrice();
    }

    void Update()
    {
        updatePellets();
        if (MySingleton.PelletCounter >= this.cherryPrice && Input.GetKeyUp(KeyCode.Y))
        {
            buyItem();
            tickSwitch = true;
        }
        if (MySingleton.PelletCounter >= this.cherryPrice && Input.GetKeyUp(KeyCode.N))
        {
            EditorSceneManager.LoadScene("Dungeon1");
        }
        if (tickSwitch)
        {
            tickCounter = tickCounter + 1;
            //print(tickCounter);
        }
        if(tickCounter >= 500)
        {
            tickSwitch = false;
            this.Narrator.text = "Press Space to Return to the Dungeon";
        }
        if(isItemBought == true && Input.GetKeyUp(KeyCode.Space))
        {
            EditorSceneManager.LoadScene("Dungeon1");
        }


    }
    void checkPrice()
    {
            if(MySingleton.PelletCounter >= this.cherryPrice)
            {
                 this.Narrator.text = "You can afford the item! \n Press Y to buy \n Press N to decline";
            }
            else
            {
                this.Narrator.text = "You don't have enough pellets :(\n Press Space to Return to the Dungeon";
            this.isItemBought = true;
            }
    
    }

    void updatePellets()
    {
        this.PelletDisplay.text = "Pellets: " + MySingleton.PelletCounter;
    }

    void buyItem()
    {
        powerCherry.gameObject.SetActive(false);
        MySingleton.attackBonus = MySingleton.attackBonus + 1;
        this.Narrator.text = "Your Attack Power has increased by 1! \n NEW ATTACK POWER IS " + MySingleton.attackBonus;
        MySingleton.PelletCounter = MySingleton.PelletCounter - 1;
        this.isItemBought = true;

    }
}
