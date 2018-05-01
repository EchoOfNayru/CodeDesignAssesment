using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public CharacterBase tank;
    public CharacterBase magic;
    public CharacterBase healer;

    public CharacterBase activeCharacter;
    public CharacterBase currentEnemy;

    public List<CharacterBase> TurnOrder = new List<CharacterBase>();

    public delegate void EnemyUpdate(CharacterBase.Stats stats);
    public EnemyUpdate UpdateEnemy;

    public delegate void NoEnemy();
    public NoEnemy enemyLost;

    public delegate void PlayerUpdate(CharacterBase.Stats stats);
    public PlayerUpdate UpdatePlayer;

    UIManager uiManager;
    EnemyManager enemyManager;

    void Awake()
    {
        ServiceLocator.instance.playerManager = this;
    }

    void Start()
    {
        uiManager = ServiceLocator.instance.uiManager;
        enemyManager = ServiceLocator.instance.enemyManager;

        TurnOrder.Add(tank);
        TurnOrder.Add(magic);
        TurnOrder.Add(healer);
        TurnOrder.Add(enemyManager.enemies[0]);
        TurnOrder.Add(enemyManager.enemies[1]);
        TurnOrder.Add(enemyManager.enemies[2]);
        TurnOrder.Add(enemyManager.enemies[3]);
        TurnOrder.Add(enemyManager.enemies[4]);

        EndTurn();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider != null)
                {
                    CharacterBase targetCache = hit.collider.gameObject.GetComponent<CharacterBase>();
                    if (targetCache != null)
                    {
                        if (targetCache.isEnemy)
                        {
                            currentEnemy = targetCache;
                            UpdateEnemy(currentEnemy.myStats);
                            uiManager.arrowMovementTimer = 0;
                        }
                    }
                }
            }
        }
        
        if (activeCharacter.isEnemy)
        {
            uiManager.attackButton.interactable = false;
            uiManager.skillsButton.interactable = false;
            uiManager.defendButton.interactable = false;
            uiManager.itemButton.interactable = false;
            uiManager.runButton.interactable = false;
            if (!activeCharacter.isAttacking)
            {
                activeCharacter.isAttacking = true;
            }
        }
    }

    public void EndTurn()
    {
        activeCharacter = TurnOrder[0];
        uiManager.ShowActiveCharacter(activeCharacter);
        TurnOrder.Remove(activeCharacter);
        TurnOrder.Add(activeCharacter);
        if (activeCharacter.isPlayer)
        {
            UpdatePlayer(activeCharacter.myStats);
        }
    }
}
