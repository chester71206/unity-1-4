using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_random_sword : MonoBehaviour
{
    public GameObject[] sword1Prefab;
    float minx = 5.7f;
    float maxx = 50f;
    float miny = 10f;
    float maxy = 28f;
    public int sword_sum=6;
    private Animator animator;
    float Rate =2.1f;
    float Timer = 2.1f;
    // Start is called before the first frame update

    IEnumerator Attack()
    {
        for (int i = 0; i < sword_sum; i++)
        {
            int randomNumber = UnityEngine.Random.Range(0, 8);
            float randomx = UnityEngine.Random.Range(minx, maxx);
            float randomy = UnityEngine.Random.Range(miny, maxy);
            Vector3 position = new Vector3(randomx, randomy, 0);
            InstantiateSword(position, randomNumber);
            yield return new WaitForSeconds(0.3f);
            Debug.Log("Random x value: " + randomx + "\n");
            Debug.Log("Random y value: " + randomy + "\n");
        }
        //animator.SetInteger("state", 2);


    }
    void InstantiateSword(Vector3 position, int randomNumber)
    {
        GameObject sword = Instantiate(sword1Prefab[randomNumber], position, sword1Prefab[randomNumber].transform.rotation);
        Destroy(sword, 3f);
        sword.SetActive(true);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        if (randomNumber==0)
        {
            StartCoroutine(ThrowAfterDelay(rb, sword.transform, 75, -70));
        }
        else if(randomNumber == 1)
        {
            StartCoroutine(ThrowAfterDelay(rb, sword.transform, 50, -70));
        }
        else if (randomNumber ==2)
        {
            StartCoroutine(ThrowAfterDelay(rb, sword.transform, 25, -70));
        }
        else if (randomNumber == 3)
        {
            StartCoroutine(ThrowAfterDelay(rb, sword.transform, 0, -70));
        }
        else if (randomNumber == 4)
        {
            StartCoroutine(ThrowAfterDelay(rb, sword.transform, -25, -70));
        }
        else if (randomNumber == 5)
        {
            StartCoroutine(ThrowAfterDelay(rb, sword.transform, -50, -70));
        }
        else if (randomNumber == 6)
        {
            StartCoroutine(ThrowAfterDelay(rb, sword.transform, -75, -70));
        }

    }

    IEnumerator ThrowAfterDelay(Rigidbody2D rb, Transform swordTransform,float speedx,float speedy)
    {
        Vector3 initialPosition = swordTransform.position;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(1f);

        rb.gravityScale = 1f;

        swordTransform.position = initialPosition;

        Vector2 throwDirection = new Vector2(-1, 1).normalized;
        throwDirection.x *= speedx;
        throwDirection.y *= speedy;
        rb.AddForce(throwDirection, ForceMode2D.Impulse);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer>= Rate)
        {

            StartCoroutine(Attack());
            Timer = 0;
        }
    }
}
