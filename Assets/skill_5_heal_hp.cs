using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_5_heal_hp : MonoBehaviour
{
    float Rate = 5.05f;
    float Timer = 5.05f;
    public mpbar_player mpbar_Player;
    public GameObject healing;
    public life_change Life_Change;
    public int total_minus_mp = 8000;
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
        if (gameManagerInstance.player_skills.Count >= 1 && gameManagerInstance.player_skills[0] == 4)
        {
            if (Input.GetKeyDown(KeyCode.J) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(heal());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 2 && gameManagerInstance.player_skills[1] == 4)
        {
            if (Input.GetKeyDown(KeyCode.K) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(heal());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 3 && gameManagerInstance.player_skills[2] == 4)
        {
            if (Input.GetKeyDown(KeyCode.L) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(heal());
                Timer = 0;
            }
        }

        
    }
    IEnumerator heal()
    {

        healing.SetActive(true);
        float elapsedTime = 0;
        float moveDuration =5f;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            for(int i = 0; i < 3; i++)
            {
                if(Life_Change.currlife<=Life_Change.maxHP)
                Life_Change.currlife++;
            }

             yield return null;
        };
        healing.SetActive(false);
    }
}
