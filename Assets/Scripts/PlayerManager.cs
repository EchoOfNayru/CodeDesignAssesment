using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject tank;
    public GameObject magic;
    public GameObject healer;

    void Start()
    {
        ServiceLocator.instance.playerManager = this;
    }

}
