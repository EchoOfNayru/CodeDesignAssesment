using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour {

    public static ServiceLocator instance;

	// Use this for initialization
	void Awake ()
    {
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
	}

    public PlayerManager playerManager;
    public EnemyManager enemyManager;

}
