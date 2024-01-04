using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill4_invincible : MonoBehaviour
{
    public life_change life_controller;
    public GameObject lightcircle;
    float Rate = 10.5f;
    float Timer = 10.5f;
    public mpbar_player mpbar_Player;
    public int total_minus_mp = 6000;
    // public gamemannager Gamemannager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gamemannager gameManagerInstance = FindObjectOfType<gamemannager>();
        Timer += Time.deltaTime;
        if (gameManagerInstance.player_skills.Count >= 1 && gameManagerInstance.player_skills[0] == 3)
        {
            if (Input.GetKeyDown(KeyCode.J) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(skill());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 2 && gameManagerInstance.player_skills[1] == 3)
        {
            if (Input.GetKeyDown(KeyCode.K) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(skill());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 3 && gameManagerInstance.player_skills[2] == 3)
        {
            if (Input.GetKeyDown(KeyCode.L) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(skill());
                Timer = 0;
            }
        }
        
    }
    IEnumerator skill()
    {
        lightcircle.SetActive(true);
        life_controller.invincible_on();
        yield return new WaitForSeconds(10f);
        lightcircle.SetActive(false);
        life_controller.invincible_off();

    }
}
