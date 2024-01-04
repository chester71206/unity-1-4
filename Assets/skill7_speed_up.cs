using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill7_speedup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lighting;
    public jump2 Jump2;
    float Rate = 5.05f;
    float Timer = 5.05f;
    public mpbar_player mpbar_Player;
    public int total_minus_mp = 3000;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gamemannager gameManagerInstance = FindObjectOfType<gamemannager>();
        Timer += Time.deltaTime;
        if (gameManagerInstance.player_skills.Count >= 1 && gameManagerInstance.player_skills[0] == 6)
        {
            if (Input.GetKeyDown(KeyCode.J) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(run());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 2 && gameManagerInstance.player_skills[1] == 6)
        {
            if (Input.GetKeyDown(KeyCode.K) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(run());
                Timer = 0;
            }
        }
        else if (gameManagerInstance.player_skills.Count >= 3 && gameManagerInstance.player_skills[2] == 6)
        {
            if (Input.GetKeyDown(KeyCode.L) && Timer >= Rate && mpbar_Player.MP >= total_minus_mp)
            {
                for (int i = 0; i < total_minus_mp; i++)
                {
                    mpbar_Player.minusMP();
                }
                StartCoroutine(run());
                Timer = 0;
            }
        }
    }
    IEnumerator run()
    {
        lighting.SetActive(true);
        Jump2.speed = 20;
        yield return new WaitForSeconds(5f);
        lighting.SetActive(false);
        Jump2.speed = 10;
    }
}
