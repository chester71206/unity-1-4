using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    // Start is called before the first frame update
    public HPTimeBar hPTimeBar;
    public hpbar_monster Hpbar_Monster;
    bool game_has_ended = false;
    public GameObject loselevelUI;
    public GameObject winlevelUI;
    public float restartdelay = 3f;
    public GameObject[] skills;
    public void Loselevel()
    {
        loselevelUI.SetActive(true);
        game_has_ended = true;
    }
    public void winlevel()
    {
        winlevelUI.SetActive(true);
        game_has_ended = true;
    }

    void Update()
    {
        if (hPTimeBar.HP <= 0)
        {
            SceneManager.LoadScene(3);
            //Loselevel();
        }
        if (Hpbar_Monster.HP <= 0)
        {
            SceneManager.LoadScene(4);
            // winlevel();
        }
        
            if (game_has_ended == true && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) )
            SceneManager.LoadScene(0);
    }
   
    /*public void EndGame()
    {
        if (game_has_ended == false)
        {
            game_has_ended = true;
            // Debug.Log("Game OVER!");
            Invoke("restart", restartdelay);
        }

    }*/
    /* public void restart()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }*/
}
