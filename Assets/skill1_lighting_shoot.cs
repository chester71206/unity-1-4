using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill1_lighting_shoot : MonoBehaviour
{

    public GameObject particle;
    public count_score monsterlife_controller;
    public mpbar_player mpbar_Player;
    public int total_minus_mp=2000;
   // public gamemannager Gamemannager;
    //scoreTextController.minus_monster_life();
    // Start is called before the first frame update
    float Rate = 1.55f;
    float Timer = 1.55f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        gamemannager gameManagerInstance = FindObjectOfType<gamemannager>();
        Timer += Time.deltaTime;
        if(gameManagerInstance.player_skills.Count>=1 && gameManagerInstance.player_skills[0] == 0)
        {
            if (Input.GetKeyDown(KeyCode.J) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(shoot());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 2 && gameManagerInstance.player_skills[1] == 0)
        {
            if (Input.GetKeyDown(KeyCode.K) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(shoot());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 3 && gameManagerInstance.player_skills[2] == 0)
        {
            if (Input.GetKeyDown(KeyCode.L) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(shoot());
                Timer = 0;
            }
        }


    }
    IEnumerator shoot()
    {

        particle.SetActive(true);
        float elapsedTime = 0;
        float moveDuration =1.5f;
        while (elapsedTime <  moveDuration)
        {
            elapsedTime += Time.deltaTime;
            for(int i = 0; i < 3; i++)
            {
                monsterlife_controller.minus_monster_life();
            }
            yield return null;
        };
        particle.SetActive(false); 
    }
}
