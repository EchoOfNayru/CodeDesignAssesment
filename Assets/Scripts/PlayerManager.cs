using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public BasicPlayer tank;
    public BasicPlayer magic;
    public BasicPlayer healer;

    public CharacterBase activeCharacter;
    public BasicEnemy currentEnemy;

    UIManager uiManager;

    public Queue<CharacterBase> TurnOrder = new Queue<CharacterBase>();

    public delegate void EnemyUpdate(BasicEnemy.StatsToShow stats);
    public EnemyUpdate UpdateEnemy;

    public delegate void NoEnemy();
    public NoEnemy enemyLost;

    public delegate void PlayerUpdate(BasicPlayer.Stats stats);
    public PlayerUpdate UpdatePlayer;

    void Awake()
    {
        ServiceLocator.instance.playerManager = this;
    }

    void Start()
    {
        uiManager = ServiceLocator.instance.uiManager;

        TurnOrder.Enqueue(tank);
        TurnOrder.Enqueue(magic);
        TurnOrder.Enqueue(healer);

        activeCharacter = TurnOrder.Dequeue();
        TurnOrder.Enqueue(activeCharacter);
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
                    BasicEnemy targetCache = hit.collider.gameObject.GetComponent<BasicEnemy>();
                    if (targetCache != null)
                    {
                        currentEnemy = targetCache;
                        UpdateEnemy(currentEnemy.stats);
                        Debug.Log(currentEnemy);
                    }
                }
            }
        }
    }
}
