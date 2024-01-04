using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;

public class womanaction : MonoBehaviour
{
    [SerializeField] Text  score_text;
    public int targetscore;
    public int score;
    private Animator animator;
    private bool isback = false;
    public float moveX = 5.0f;
    public GameObject[] food;
    public HPTimeBar hptimebar;
    private int index;
    private GameObject copiedFood;
    private float food_move_distance=25;  //食物放到盤子的距離
    private bool istaking_food=false;
    private GameObject targetFood;
    public float targetFoodposition_y=35.6f;
    public float targetFoodposition_x=95.7f;
    public Vector3 targetFood_scale = new Vector3(30f, 30f, 1.0f); // 新的比例
    private int copiedFoodindex=-1;
    private int randomIndex;
    public int addscore;
    public int minusscore;
    public gamemannager Game;
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("PlayAnimation", 2.0f, 5.0f);
     //   hptimebar.StartTimer();
       randomIndex = Random.Range(0, food.Length-1);
        targetFood = Instantiate(food[randomIndex]);
        targetFood.transform.position = new Vector3(targetFoodposition_x, targetFoodposition_y, 0);
        targetFood.transform.localScale = targetFood_scale; 
    }
    void PlayAnimation()
    {
        
        if (!isback)
        {
            animator.SetInteger("state", 1);
           // StartCoroutine(ResetToState0AfterDelay(0.25f));
        }
       
    }
    /*IEnumerator ResetToState0AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetInteger("state", 0);
    }*/

    void Update()
    {        
            
            if (Input.GetKeyDown(KeyCode.Space) && isback == false && index==food.Length-1 && Game.endgame==false) //如果要送餐
             {
            if (copiedFoodindex == randomIndex)
                 {
                Destroy(copiedFood);
                Destroy(targetFood);
                //_timeText.text
                StartCoroutine(hp_up_wait());
                animator.SetInteger("state", 2);
                 }
            else
            {
                Destroy(copiedFood);
                Destroy(targetFood);
                StartCoroutine(hp_minus_wait());
                animator.SetInteger("state", 2);
            }
            copiedFoodindex = -1;
                 istaking_food = false;
                 isback = true;
                 StartCoroutine(back_to_stand_wait());
            }
            else if(Input.GetKeyDown(KeyCode.Space) && isback == false)    //拿取食物
            {
                if (istaking_food == false)
                {
                istaking_food = true;
                copiedFood = Instantiate(food[index]);
                copiedFoodindex = index;
                Vector3 characterPosition = this.transform.position;
                copiedFood.transform.position = new Vector3(characterPosition.x, characterPosition.y - food_move_distance, characterPosition.z);
                }
            else
            {
                Destroy(copiedFood);
                copiedFood = Instantiate(food[index]);
                copiedFoodindex = index;
                Vector3 characterPosition = this.transform.position;
                copiedFood.transform.position = new Vector3(characterPosition.x, characterPosition.y - food_move_distance, characterPosition.z);
            }
       
            }
    
            if(Input.GetKeyDown(KeyCode.D) && isback == false && index<food.Length-1)
            {
                 index++;
           // Debug.Log(index);
                 Vector3 currentPosition = transform.position;


                 Vector3 newPosition = new Vector3(currentPosition.x +moveX, currentPosition.y, currentPosition.z);
            if (istaking_food == true)
            {
                copiedFood.transform.position = new Vector3(currentPosition.x + moveX, currentPosition.y - food_move_distance, currentPosition.z);
            }
           
            transform.position = newPosition;
            }
            if (Input.GetKeyDown(KeyCode.A) && isback == false && index>=1)
            {
            index--;
            //Debug.Log(index);
            Vector3 currentPosition = transform.position;

      
             Vector3 newPosition = new Vector3(currentPosition.x - moveX, currentPosition.y, currentPosition.z);
            if (istaking_food == true)
            {
                copiedFood.transform.position = new Vector3(currentPosition.x - moveX, currentPosition.y - food_move_distance, currentPosition.z);
            }
         
            transform.position = newPosition;
        }
    }

    IEnumerator back_to_stand_wait()
    {
        yield return new WaitForSeconds(2f);
        animator.SetInteger("state", 0);
        randomIndex = Random.Range(0, food.Length - 1);
        targetFood = Instantiate(food[randomIndex]);
        targetFood.transform.position = new Vector3(targetFoodposition_x, targetFoodposition_y, 0);
        targetFood.transform.localScale = targetFood_scale;
        yield return new WaitForSeconds(0.3f);
        isback = false;
    }
    IEnumerator hp_up_wait()
    {
        yield return new WaitForSeconds(0.5f);
        score += addscore;
        if (score >= targetscore)
        {
            Game.win_level();
        }
        hptimebar.AddHP(); //獲得血量
        score_text.text = "Score: " + score.ToString();
    }
    IEnumerator hp_minus_wait()
    {
        yield return new WaitForSeconds(0.5f);
        if (score - minusscore <= 0)
        {
            score = 0;
        }
        else
        {
            score -= minusscore;
        }
        hptimebar.minusHP(); //獲得血量
        score_text.text = "Score: " + score.ToString();
    }
}

/*
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private int currentState = 0;
    private float switchInterval = 5.0f; 
    private float lastSwitchTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastSwitchTime = Time.time;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchToNextState();
        }

        
        if (Time.time - lastSwitchTime >= switchInterval && currentState == 0)
        {
            SwitchToBlinkState();
        }
    }

    void SwitchToNextState()
    {
        
        currentState = (currentState + 1) % 3;
        animator.SetInteger("state", currentState);

        
        lastSwitchTime = Time.time;
    }

    void SwitchToBlinkState()
    {
        
        currentState = 1;
        animator.SetInteger("state", currentState);

        
        lastSwitchTime = Time.time;
    }
}
*/
