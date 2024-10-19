using System.Collections;
using System.Collections.Generic;
using UnityEngine;

attackLogic:
float timer = 0;
public gameManager gameM;



private void OnTriggerStay2D(Collider2D collision)
{
    if (collision != null)
    {
        timer += Time.deltaTime;
        Debug.Log("Timer : " + timer);

        if (collision.gameObject.tag == "Player" && (int)timer == 2)
        {
            gameM.PlayerHit(1);
            Debug.Log("Hit");
            timer = 0;

        }
    }

}