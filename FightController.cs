using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshProUGUI hero_hp_TMP;
    public TextMeshProUGUI monster_hp_TMP;
    public TextMeshProUGUI fightManagerTMP;
    public GameObject PlayerStartPosition, PlayerAttackPosition, MonsterStartPosition, MonsterAttackPosition;
    private bool PlayerTurn = true;
    private int TurnNumber = 1;
    private float speed = 1f;
    private bool PlayerMoving = false;
    private bool MonsterMoving = false;

    private int heroHP = 20;
    private int monsterHP = 40;
    private int monsterAC = 10;
    private int heroAC = 15;


    // Start is called before the first frame update
    void Start()
    {
        this.hero_GO.transform.position = this.PlayerStartPosition.transform.position;
        this.monster_GO.transform.position = this.MonsterStartPosition.transform.position;
        //fightManagerTMP.text = "test 1";
        fightManagerTMP.text = "Player's Turn press SpaceBar to attack";
        setMonsterHP();
        setHeroHP();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTurn == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                AttackMonster();
                TurnNumber = TurnNumber + 1;
                PlayerMoving = true;
                //fightManagerTMP.text = "Press Enter to end your Turn";
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                PlayerMoving = false;
                PlayerTurn = false;
            }

        }

        if(PlayerTurn == false) 
        {
            MonsterMoving = true;
            fightManagerTMP.text = "The Monster attacks! Press SpaceBar to continue";
            if (Input.GetKeyUp(KeyCode.Space))
            {
                AttackPlayer();
                TurnNumber = TurnNumber + 1;
                MonsterMoving = true;
            }
        }

        if(PlayerMoving == true)
        {
            moveHero_GO();
        }

        if(PlayerMoving == false)
        {
            moveHeroBack();
        }
        if(MonsterMoving == true)
        {
            moveMonster_GO();
        }
        if(MonsterMoving == false)
        {
            moveMonsterBack();
        }

        if(heroHP <= 0)
        {
            fightManagerTMP.text = "YOU DIED";
        }

        if(monsterHP <= 0)
        {
            fightManagerTMP.text = "ENEMY FELLED";
        }
    }
    
    void setFightManager()
    {
        fightManagerTMP.text = "Round" + TurnNumber;
    }

    void setHeroHP()
    {
        hero_hp_TMP.text = "HP: " + heroHP;
    }

    void setMonsterHP()
    {
        monster_hp_TMP.text = "HP: " + monsterHP;
    }

    void moveHero_GO()
    {
        Vector3 PlayerCurrentPosition = hero_GO.transform.position;
        Vector3 PlayerTargetPosition = PlayerAttackPosition.transform.position;
        Vector3 newPosition = Vector3.MoveTowards(PlayerCurrentPosition, PlayerTargetPosition, speed * Time.deltaTime);
        hero_GO.transform.position = newPosition;
    }

    void moveHeroBack()
    {
        Vector3 PlayerCurrentPosition = hero_GO.transform.position;
        Vector3 PlayerTargetPosition = PlayerStartPosition.transform.position; 
        Vector3 NewPlayerPosition = Vector3.MoveTowards(PlayerCurrentPosition, PlayerTargetPosition, speed * Time.deltaTime);
        hero_GO.transform.position = NewPlayerPosition;
    }

    void moveMonster_GO()
    {
        Vector3 MonsterCurrentPosition = monster_GO.transform.position;
        Vector3 MonsterTargetPosition = MonsterAttackPosition.transform.position;
        Vector3 NewMonsterPosition = Vector3.MoveTowards(MonsterCurrentPosition, MonsterTargetPosition, speed * Time.deltaTime);
        monster_GO.transform.position = NewMonsterPosition;
    }

    void moveMonsterBack() 
    {
        Vector3 MonsterCurrentPosition = monster_GO.transform.position;
        Vector3 MonsterTargetPosition = MonsterStartPosition.transform.position;
        Vector3 NewMonsterPosition = Vector3.MoveTowards(MonsterCurrentPosition, MonsterTargetPosition, speed * Time.deltaTime);
        monster_GO.transform.position = NewMonsterPosition;
    }

    void AttackMonster()
    {
        print("attack");
        int d20 = Random.Range(1, 21); 
        if(d20 > monsterAC) 
        {
            print("hit");
            int damage = Random.Range(1, 7); 
            monsterHP = monsterHP - damage;
            fightManagerTMP.text = "Hit for " + damage + " damage! Press Enter to end your turn";
            setMonsterHP();
        }
        else
        {
            print("miss");
            fightManagerTMP.text = "Miss! Press Enter to end your turn";
        }
    }

    void AttackPlayer()
    {
        print("attack");
        int d20 = Random.Range(1, 21);
        if (d20 > heroAC)
        {
            print("hit");
            int damage = Random.Range(1, 7);
            heroHP = heroHP - damage;
            fightManagerTMP.text = "Hit for " + damage + " damage! press enter to end the turn";
            setHeroHP();
            PlayerTurn = true;
            MonsterMoving = false;
        }
        else
        {
            print("miss");
            fightManagerTMP.text = "Miss! Press enter to end the Turn";
            PlayerTurn = true;
            MonsterMoving = false;
        }
        PlayerTurn = true;
    }
}
