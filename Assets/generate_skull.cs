using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_skull : MonoBehaviour
{
    private Animator animator;
   // public float attackSpeed =0.3f; 
    private float attackTimer = 2.0f;
    public GameObject skull;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >=8.0f )
        {
            Attack();
            attackTimer = 0.0f;
            animator.SetInteger("state", 1);
        }
      

      
    }
    void Attack()
    {
        StartCoroutine(wait_animate());
    }

    IEnumerator wait_animate()
    {
        yield return new WaitForSeconds(0.5f);
        skull.SetActive(true);
        yield return new WaitForSeconds(1f);
        skull.SetActive(false);
        animator.SetInteger("state", 0);


    }
}
