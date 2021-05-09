using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : enemy
{

    public float stpDistance;
    private float attacktime;
    public float attackSpd;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(player!= null)
        {
            if (Vector2.Distance(transform.position, player.position) > stpDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if(Time.time >= attacktime)
                {
                    StartCoroutine(Attack());
                    attacktime = Time.time + timebtwAttacks;
                }
            }
        }
            
    }
    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);
        Vector2 originalP = transform.position;
        Vector2 targetP = player.position;

        float percent = 0;
        while(percent <= 1)
        {
            percent += Time.deltaTime*attackSpd;
            float formul = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalP, targetP, formul);
            yield return null;
        }
    }
}
