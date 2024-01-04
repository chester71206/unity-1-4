using UnityEngine;
using System.Collections;

public class grabberscript : MonoBehaviour
{
	private Animator animator;
	private float attackInterval = 3.75f; 
	private bool isAttacking = false;
    public GameObject bomb;
    public float throwForceLeft = 10f; 
    public float throwForceUp = 10f;
    public int bombsize = 5;
    public Transform playerTransform;
   //public GameObject healcircle;
    public count_score monster_life_change;
    //public int throwup_min=5;
    //public int throwup_max=15;
    //public int throwleft_min=5;
   // public int throwleft_max=15;
    public bool heal_or_not = false;
    public ParticleSystem laserParticleSystem; // 采╰参

    //穝
    public Vector3 targetPosition=new Vector3(11.6f,5.3f,0f); // 璶簿笆ヘ夹竚Transform
    public float movementSpeed = 10.0f; // 簿笆硉
    private bool isMoving = false;
    private Vector2 initialPosition;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start()
	{
		animator = GetComponent<Animator>();
        //  rb = GetComponent<Rigidbody2D>();

       // InvokeRepeating("heallife", 30f, 30f);
        InvokeRepeating("Attack", 0, attackInterval);

        //穝
        initialPosition = transform.position;
        animator.SetInteger("state", 0);


    }
    void Update()
    {
        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector2.Lerp(initialPosition, targetPosition, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
    /*public void heallife()
    {
        if(heal_or_not)
        {
            monster_life_change.plus_monster_life();
            healcircle.SetActive(true);
            StartCoroutine(wait_for_heal());
        }
       
    }*/
    /*IEnumerator wait_for_heal()
    {
        yield return new WaitForSeconds(3f);
        healcircle.SetActive(false) ;
    }*/
    // Update is called once per frame
    private void Attack()
    {


        Vector3 spawnPosition = this.transform.position;
        Vector3 direction = (playerTransform.position - spawnPosition).normalized;

        // ネΘ縀
        ParticleSystem newLaserParticles = Instantiate(laserParticleSystem, spawnPosition, Quaternion.identity);
        // 砞﹚采╰参硉よㄏ采絬甮產
        ParticleSystem.VelocityOverLifetimeModule velocity = newLaserParticles.velocityOverLifetime;
        velocity.enabled = true; // 币ノ硉跑て
        velocity.x = direction.x * 10f; // 砞竚 x よ硉
        velocity.y = direction.y * 10f; // 砞竚 y よ硉
        velocity.z = direction.z * 10f; // 砞竚 z よ硉

        // 冀采╰参
        newLaserParticles.Play();

        // 篟反采╰参硂柑ㄏノ3
        Destroy(newLaserParticles.gameObject, 3f);

        // 篟反采╰参硂柑ㄏノ3
        // Destroy(newLaserParticles.gameObject, 3f);
        /*GameObject newBomb = Instantiate(bomb, this.transform.position, Quaternion.identity); //  this 竚承 bomb
        newBomb.SetActive(true);
        Vector3 direction = (playerTransform.position - this.transform.position).normalized; // 璸衡绰產よ
        newBomb.GetComponent<Rigidbody2D>().velocity = direction * 50f; // 砞竚 bomb 硉

        Destroy(newBomb, 3f); // 琿丁篟反 bomb*/

        /*if (!isAttacking)
        {
            animator.SetInteger("state", 1);
           // Debug.Log("1");
            isAttacking = true;
           // StartCoroutine(ResetAttack());
        }*/
    }

    /*private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.25f);
        ThrowBomb();
       // Debug.Log("2");
        animator.SetInteger("state", 0);
        isAttacking = false;
    }*/

    /*void ThrowBomb()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 5, 0); // 穝ネΘ竚
       // Debug.Log("3");
        for (int i = 0; i < bombsize; i++)
        { 
            GameObject newBomb = Instantiate(bomb, spawnPosition, Quaternion.identity);
            newBomb.SetActive(true);
            Rigidbody2D rb = newBomb.GetComponent<Rigidbody2D>();
             Vector2 throwDirection = new Vector2(-1, 1).normalized;
             throwForceUp = Random.Range(throwup_min, throwup_max);
             throwForceLeft = Random.Range(throwleft_min, throwleft_max);
            throwDirection.x *= throwForceLeft;
             throwDirection.y *= throwForceUp;
             rb.AddForce(throwDirection, ForceMode2D.Impulse);

        }
       

    }*/


}