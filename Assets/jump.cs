using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



    public class jump : MonoBehaviour
    {
        // Start is called before the first frame update
        public Animator animator;
        private bool isOnGround = true;
        public float speed = 10f;
        public int life = 10;
        private float jumpcounter;
        //public int jumppower;
        public GameObject boom;
        int sprites_index = 0;
        public count_score scoreTextController;
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
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
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
            if (other.gameObject.CompareTag("bomb"))
            {
                other.gameObject.SetActive(false);
                GameObject newBoom = Instantiate(boom, other.transform.position, Quaternion.identity);
                newBoom.SetActive(true);
                StartCoroutine(HideBombInspector(newBoom));

                //boom.SetActive(false);
                boom.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                if (life > 1)
                {
                    life_controler.minusDisplay();
                    life--;
                }
                else
                {
                    life_controler.minusDisplay();
                    //scoreTextController.score_to_zero();
                    Time_controler.time_stop();
                    if (game_has_ended == false)
                    {
                        FindObjectOfType<game>().Loselevel();
                        game_has_ended = true;
                    }

                }

            }
            if (other.gameObject.CompareTag("monster") && canHitMonster)
            {
                canHitMonster = false;
                for (int i = 0; i < attackboom.Length; i++)
                {
                    attackboom[i].SetActive(true);
                }
                StartCoroutine(EnableMonsterHit());
                scoreTextController.minus_monster_life();
                if (scoreTextController.GET_life() <= 0)
                {
                    FindObjectOfType<game>().winlevel();
                }
            }
            /*if(!other.gameObject.CompareTag("ground"))
            {
            int randomFruitIndex = Random.Range(1, fruits.Length);
            other.gameObject.SetActive(false);
            fruits[randomFruitIndex].gameObject.transform.position= new Vector3(10, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            //GameObject newFruit = Instantiate(fruits[randomFruitIndex], other.gameObject.transform.position, Quaternion.identity);
            //other.gameObject.transform.position = new Vector3(10, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            fruits[randomFruitIndex].SetActive(true);
                if (!other.gameObject.CompareTag("bomb"))
                {
                     scoreTextController.AddScoreAndDisplay();
                }

            }*/
            //Debug.Log("Collision Detected!");

        }

        IEnumerator HideBombInspector(GameObject newboom)  //炸到炸藥
        {
            yield return new WaitForSeconds(3.0f); // 等待三秒
            newboom.SetActive(false);
            //delete
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
                                                         // isgrounded = Physics2D.OverlapCapsule(groundcheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundlayer);
            /*RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f);
            if (hit.collider != null)
            {
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = 1;
            }*/


            if (!isOnGround)
            {
                animator.SetInteger("state", 2);
            }
            else if (dirx != 0)
            {
                animator.SetInteger("state", 1);
            }
            else
            {
                animator.SetInteger("state", 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.position += new Vector3((speed + 7) * Time.fixedDeltaTime, 0f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
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

            /* if (rb.velocity.y < 0)
             {
                 rb.velocity -= vecgravity * fallmultipier * Time.deltaTime;
             }*/
            /*if (Jumpcount >= 0)
            {
                if (Jumpcount < 20)
                {
                    this.transform.position += new Vector3(0f, speed * Time.fixedDeltaTime, 0f);
                }
                else
                {
                    this.transform.position += new Vector3(0f, -speed * Time.fixedDeltaTime, 0f);
                }
                Jumpcount++;
                if (Jumpcount > 39)
                {
                    IsJump = false;
                    Jumpcount = -1;
                }
            }*/
        }
    }

