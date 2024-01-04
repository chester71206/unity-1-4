using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_6_defence : MonoBehaviour
{
    float Rate = 7.05f;
    float Timer = 7.05f;
    public mpbar_player mpbar_Player;
    public GameObject defence;
    public life_change Life_Change;
    public int total_minus_mp = 3000;
    // public gamemannager Gamemannager;
    // Start is called before the first frame update
    void Start()
    {
    }
    IEnumerator defence_fun()
    {

        defence.SetActive(true);
        Life_Change.defence_on();
        yield return new WaitForSeconds(7f);
        Life_Change.defence_off();
        defence.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        gamemannager gameManagerInstance = FindObjectOfType<gamemannager>();
        Timer += Time.deltaTime;
        if (gameManagerInstance.player_skills.Count >= 1 && gameManagerInstance.player_skills[0] == 5)
        {
            if (Input.GetKeyDown(KeyCode.J) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(defence_fun());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 2 && gameManagerInstance.player_skills[1] == 5)
        {
            if (Input.GetKeyDown(KeyCode.K) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(defence_fun());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 3 && gameManagerInstance.player_skills[2] == 5)
        {
            if (Input.GetKeyDown(KeyCode.L) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(defence_fun());
                Timer = 0;
            }
        }

      
    }
}
