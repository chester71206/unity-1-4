using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class jump2 : MonoBehaviour
{
    public GameObject swordbomb;
    public int impact_minus_monster_life = 1000;
    private bool flipx = false;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private bool isOnGround = true;
    public float speed = 10f;
    public int life = 10;
    private float jumpcounter;
    //public int jumppower;
    public GameObject boom;
    int sprites_index = 0;
    public count_score monsterlife_controller;
    public time_controler Time_controler;
    public life_change life_controler;
    public float minX = -3.54f;
    public float maxX = 2.94f;
    public float forwardforce = 30f;
    public GameObject[] attackboom;
    public float jumpingPower = 10f;
    private float horizontal;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isjumping;
    public float jumptime;

    //public GameObject other;
    //private Animator animator;
    //  bool isgrounded=true;
    Vector2 vecgravity;
    // public float fallmultipier;
    //public Transform groundcheck;
    // public LayerMask groundlayer;
    [SerializeField] float jumpMultipiler;
    [SerializeField] float fallMultipiler;
    [SerializeField] float lMultipiler;
    bool game_has_ended = false;
    //public GameObject boom_animation;


    private bool canHitMonster = true;
    private float lastMonsterHitTime;

    public super_light superlight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    IEnumerator EnableMonsterHit()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < attackboom.Length; i++)
        {
            attackboom[i].SetActive(false);
        }

        //yield return new WaitForSeconds(1.5f);
        canHitMonster = true;
    }
    public void OnTriggerEnter2D(Collider2D other) //撞到物體
    {

        if (other.gameObject.CompareTag("monster") && canHitMonster)
        {
            canHitMonster = false;
            for (int i = 0; i < attackboom.Length; i++)
            {
                attackboom[i].SetActive(true);
            }
            StartCoroutine(EnableMonsterHit());
            Vector2 direction = (other.transform.position - transform.position).normalized;
            rb.velocity = -direction * forwardforce;
            for (int i = 0; i < impact_minus_monster_life; i++)
            {
                monsterlife_controller.minus_monster_life();
            }
        }
        if (other.gameObject.CompareTag("hot_water")) //skull
        {
            for (int i = 0; i < 100; i++)
            {
                life_controler.minusDisplay();
            }
        }
        if (other.gameObject.CompareTag("sword"))
        {
            // GameObject sword = Instantiate(swordbomb, this.transform.position, swordbomb.transform.rotation);
            // sword.SetActive(true);
            // Destroy(sword, 2f);
            StartCoroutine(sword_animate());
            for (int i = 0; i < 400; i++)
            {
                life_controler.minusDisplay();
            }
        }

    }

    IEnumerator sword_animate()
    {

        swordbomb.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        swordbomb.SetActive(false);
    }

    private bool IsGrounded()
    { // 確認是否著地
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }
    void Update()
    {
        if (this.transform.position.x >= maxX)
        {
            Vector3 newPosition = this.transform.position;
            newPosition.x = maxX;
            this.transform.position = newPosition;
        }
        if (this.transform.position.x <= minX)
        {
            Vector3 newPosition = this.transform.position;
            newPosition.x = minX;
            this.transform.position = newPosition;
        }
        {

        }
        if (Time_controler.GET_time() <= 0)
        {
            if (game_has_ended == false)
            {
                FindObjectOfType<game>().Loselevel();
                game_has_ended = true;
            }
        }
        float dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * speed, rb.velocity.y);

        horizontal = Input.GetAxisRaw("Horizontal"); // 確認左右

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x <= maxX)
        {
            if (flipx == false)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                flipx = true;
            }
            // 檢查角色是否面向右邊，如果是，則將其轉向左邊
            if (Mathf.Approximately(this.transform.eulerAngles.y, 0f))
            {
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }


            this.transform.position += new Vector3((speed + 7) * Time.fixedDeltaTime, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.A) && transform.position.x >= minX)
        {
            if (flipx == true)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                flipx = false;
            }
            // 檢查角色是否面向右邊，如果是，則將其轉向左邊

            if (Mathf.Approximately(this.transform.eulerAngles.y, 180f)) // 檢查角色是否面向左邊，如果是，則將其轉向右邊
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            this.transform.position += new Vector3(-(speed + 2) * Time.fixedDeltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.Space) && (isOnGround == true))
        { // 當接觸地面時 向上跳
            if (superlight.incircle())
            {
                jumpcounter = 0;
                isjumping = true;
                isOnGround = false;
                rb.velocity += new Vector2(0, jumpingPower * 2);
            }
            else
            {
                jumpcounter = 0;
                isjumping = true;
                isOnGround = false;
                rb.velocity += new Vector2(0, jumpingPower);
            }

        }
        if (rb.velocity.y > 0 && isjumping)
        {
            jumpcounter += Time.deltaTime;
            if (jumpcounter > jumptime)
            {
                isjumping = false;
            }
            float t = jumpcounter / jumptime;
            float currentjumpM = jumpMultipiler;
            if (t > 0.5f)
            {
                currentjumpM = jumpMultipiler * (1 - t);
            }
            rb.velocity += vecgravity * currentjumpM * Time.deltaTime;
        }

        /*if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        { // 跳越高速度越小(拋物線)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/
        if (dirx * transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(-1 * this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        }


    }
}