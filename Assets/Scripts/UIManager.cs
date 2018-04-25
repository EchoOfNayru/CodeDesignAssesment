using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Button attackButton;
    public Button skillsButton;
    public Button defendButton;
    public Button itemButton;
    public Button runButton;

    public GameObject targetArrow;
    public GameObject skillSelection;
    public GameObject itemSelection;
    public GameObject selectTarget;

    public EnemyStatsText enemyStats;
    public PlayerStatsText playerStats;

    PlayerManager playerManager;

    void Awake()
    {
        ServiceLocator.instance.uiManager = this;
        if (ServiceLocator.instance.playerManager != null)
        {
            ServiceLocator.instance.playerManager.UpdatePlayer += ShowPlayerStats;
        }
    }

    void Start()
    {
        playerManager = ServiceLocator.instance.playerManager;
        playerManager.UpdateEnemy += ShowTargetedEnemy;
        playerManager.enemyLost += NoTargetedEnemy;
    }

    public void OnAttackClick()
    {
        if (playerManager.currentEnemy != null)
        {
            playerManager.activeCharacter.Attack(playerManager.currentEnemy);
            HideSelectTarget();
        }
        else
        {
            Debug.Log("failed");
            ShowSelectTarget();
        }
        

        attackButton.interactable = true;
        skillsButton.interactable = true;
        defendButton.interactable = true;
        itemButton.interactable = true;
        runButton.interactable = true;
        skillSelection.SetActive(false);
        itemSelection.SetActive(false);
    }

    public void OnSkillsClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = false; 
        defendButton.interactable = true;
        itemButton.interactable = true;
        runButton.interactable = true;
        skillSelection.SetActive(true);
        itemSelection.SetActive(false);
    }

    public void OnDefendClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = true;
        defendButton.interactable = false;
        itemButton.interactable = true;
        runButton.interactable = true;
        skillSelection.SetActive(false);
        itemSelection.SetActive(false);
    }

    public void OnItemClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = true;
        defendButton.interactable = true;
        itemButton.interactable = false;
        runButton.interactable = true;
        skillSelection.SetActive(false);
        itemSelection.SetActive(true);
    }

    public void OnRunClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = true;
        defendButton.interactable = true;
        itemButton.interactable = true;
        runButton.interactable = false;
        skillSelection.SetActive(false);
        itemSelection.SetActive(false);
    }

    public void ShowSelectTarget()
    {
        selectTarget.SetActive(true);
    }

    public void HideSelectTarget()
    {
        selectTarget.SetActive(false);
    }

    public void ShowTargetedEnemy(CharacterBase.Stats stats)
    {
        // arrow pointing to enemy
        Vector3 targetPosition = ServiceLocator.instance.mainCamera.WorldToScreenPoint(playerManager.currentEnemy.transform.position);
        targetPosition += new Vector3(10, 40, 0);
        targetArrow.transform.position = targetPosition;
        targetArrow.SetActive(true);

        //show enemy stats in enemy stat UI
        enemyStats.Health.text = "Health : " + stats.health;
        enemyStats.Strength.text = "Att : " + (stats.str + stats.weaponDamage);
        enemyStats.Dex.text = "Def : " + (stats.dex + stats.armor);
        enemyStats.Res.text = "Res : " + stats.res;
        string weaknessString;
        if (stats.weakness == 1)
        {
            weaknessString = "none";
        }
        else
        {
            weaknessString = "none";
        }
        enemyStats.Weakness.text = "Weak : " + weaknessString;
    }

    public void NoTargetedEnemy()
    {
        targetArrow.SetActive(false);
        enemyStats.Health.text = "Health : ???";
        enemyStats.Strength.text = "Att : ???";
        enemyStats.Dex.text = "Def : ???";
        enemyStats.Res.text = "Res : ???";
        enemyStats.Weakness.text = "Weak : ???";
        playerManager.currentEnemy = null;
    }

    public void ShowPlayerStats(CharacterBase.Stats stats)
    {
        playerStats.Name.text = stats.name;
        playerStats.Health.text = "Health : " + stats.health;
        playerStats.Str.text = "Att : " + (stats.str + stats.weaponDamage);
        playerStats.Dex.text = "Def : " + (stats.dex + stats.armor);
        playerStats.Mag.text = "Mag : " + stats.mag;
        playerStats.Res.text = "Res : " + stats.res;
        playerStats.Pie.text = "Pie : " + stats.pie;
    }
}
