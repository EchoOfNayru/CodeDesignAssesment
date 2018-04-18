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

    public GameObject attackTargeter;

    void Awake()
    {
        ServiceLocator.instance.uiManager = this;
    }

    public void OnAttackClick()
    {
        attackButton.interactable = false;
        skillsButton.interactable = true;
        defendButton.interactable = true;
        itemButton.interactable = true;
        runButton.interactable = true;
        attackTargeter.SetActive(true);
    }

    public void OnSkillsClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = false; 
        defendButton.interactable = true;
        itemButton.interactable = true;
        runButton.interactable = true;
        attackTargeter.SetActive(false);
    }

    public void OnDefendClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = true;
        defendButton.interactable = false;
        itemButton.interactable = true;
        runButton.interactable = true;
        attackTargeter.SetActive(false);
    }

    public void OnItemClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = true;
        defendButton.interactable = true;
        itemButton.interactable = false;
        runButton.interactable = true;
        attackTargeter.SetActive(false);
    }

    public void OnRunClick()
    {
        attackButton.interactable = true;
        skillsButton.interactable = true;
        defendButton.interactable = true;
        itemButton.interactable = true;
        runButton.interactable = false;
        attackTargeter.SetActive(false);
    }
}
