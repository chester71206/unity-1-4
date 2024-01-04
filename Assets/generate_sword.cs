using System.Collections;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public GameObject leftsword;
    public GameObject rightsword;
    public GameObject sword1Prefab;
    // public GameObject sword2Prefab;
    private Animator animator;
    public float throwForceUp = -70f;
    public float throwForceLeft = 50f;
    private bool isAttacking = false;
    private float attackTimer = 2.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("state", 0);
    }
    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= 4.0f)
        {
            StartCoroutine(Attack());
           
            attackTimer = 0.0f;
          
        }



    }

    IEnumerator Attack()
    {
        animator.SetInteger("state", 1);
        yield return new WaitForSeconds(0.5f);
        //animator.SetInteger("state", 1);
        //animator.SetInteger("state", 2);
        isAttacking = true;

        Vector3 position = transform.position;
        InstantiateleftSword(leftsword.transform.position);
        InstantiaterightSword(rightsword.transform.position);
        InstantiateSword(position + Vector3.left * 10);
        InstantiateSword(position);
        InstantiateSword(position + Vector3.right * 10);
    }
    void InstantiateleftSword(Vector3 position)
    {
        GameObject sword = Instantiate(leftsword, position, leftsword.transform.rotation);
        Destroy(sword, 3f); // 10秒後刪除劍
        sword.SetActive(true);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        StartCoroutine(ThrowAfterDelay_left(rb, sword.transform));
    }
    void InstantiaterightSword(Vector3 position)
    {
        GameObject sword = Instantiate(rightsword, position, rightsword.transform.rotation);
        Destroy(sword, 3f); // 10秒後刪除劍
        sword.SetActive(true);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        StartCoroutine(ThrowAfterDelay_right(rb, sword.transform));
    }

    void InstantiateSword(Vector3 position)
    {
        GameObject sword = Instantiate(sword1Prefab, position, sword1Prefab.transform.rotation);
        Destroy(sword, 3f); // 10秒後刪除劍
        sword.SetActive(true);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        StartCoroutine(ThrowAfterDelay(rb, sword.transform));
    }
    IEnumerator ThrowAfterDelay_left(Rigidbody2D rb, Transform swordTransform)
    {
        Vector3 initialPosition = swordTransform.position;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(1f);
        animator.SetInteger("state", 0);

       // rb.gravityScale = 1f;

        swordTransform.position = initialPosition;

        Vector2 throwDirection = new Vector2(-1, 1).normalized;
        throwDirection.x *= -100;
        throwDirection.y *= 0;
        rb.AddForce(throwDirection, ForceMode2D.Impulse);

    }

    IEnumerator ThrowAfterDelay_right(Rigidbody2D rb, Transform swordTransform)
    {
        Vector3 initialPosition = swordTransform.position;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(1f);
        animator.SetInteger("state", 0);

        //rb.gravityScale = 1f;

        swordTransform.position = initialPosition;

        Vector2 throwDirection = new Vector2(-1, 1).normalized;
        throwDirection.x *= 100;
        throwDirection.y *= 0;
        rb.AddForce(throwDirection, ForceMode2D.Impulse);

    }

    IEnumerator ThrowAfterDelay(Rigidbody2D rb, Transform swordTransform)
    {
        Vector3 initialPosition = swordTransform.position;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(1f);
      animator.SetInteger("state", 0);

        rb.gravityScale = 1f;

        swordTransform.position = initialPosition;

        Vector2 throwDirection = new Vector2(-1, 1).normalized;
        throwDirection.x *= throwForceLeft;
        throwDirection.y *= throwForceUp;
        rb.AddForce(throwDirection, ForceMode2D.Impulse);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}