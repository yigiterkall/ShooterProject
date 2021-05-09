using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rigidbody;
    private Vector2 moveAmount;
    private Animator animator;
    public int health;

    public Image[] hearth;
    public Sprite fulhearth;
    public Sprite emptyhearth;

    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = move.normalized * speed;

        if(move != Vector2.zero)
        {
            animator.SetBool("runs",true);
        }
        else
        {
            animator.SetBool("runs", false);
        }
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void UpdateHealthUI(int cHealth)
    {
        for(int i = 0; i < hearth.Length; i++)
        {
            if(i < cHealth)
            {
                hearth[i].sprite = fulhearth;
            }
            else
            {
                hearth[i].sprite = emptyhearth;
            }
        }
    }
}
