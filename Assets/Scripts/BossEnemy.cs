using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : Enemy {
    public StatusIndicator statusIndicator;
    private void Start()
    {
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(health, TotalHealth);
        }
    }

    public override void death() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public override void damageToEnemy(int damage) {
        health -= damage;

        if(statusIndicator != null){
            statusIndicator.SetHealth(health, TotalHealth);
        }

        if (health <= 0)
        {
            death();
        }
    }
}
