using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public CharacterBase tank;
    public CharacterBase magic;
    public CharacterBase healer;

    public CharacterBase activeCharacter;
    public CharacterBase currentEnemy;

    UIManager uiManager;

    public List<CharacterBase> TurnOrder = new List<CharacterBase>();

    public delegate void EnemyUpdate(CharacterBase.Stats stats);
    public EnemyUpdate UpdateEnemy;

    public delegate void NoEnemy();
    public NoEnemy enemyLost;

    public delegate void PlayerUpdate(CharacterBase.Stats stats);
    public PlayerUpdate UpdatePlayer;

    void Awake()
    {
        ServiceLocator.instance.playerManager = this;
    }

    void Start()
    {
        uiManager = ServiceLocator.instance.uiManager;

        TurnOrder.Add(tank);
        TurnOrder.Add(magic);
        TurnOrder.Add(healer);

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
                            Debug.Log(currentEnemy);
                        }
                    }
                }
            }
        }
    }

    public void EndTurn()
    {
        activeCharacter = TurnOrder[0];
        TurnOrder.Remove(activeCharacter);
        TurnOrder.Add(activeCharacter);
        if (activeCharacter.isPlayer)
        {
            UpdatePlayer(activeCharacter.myStats);
        }
    }
}
