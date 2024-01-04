using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill3 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    public GameObject lighting;
    public mpbar_player mpbar_Player;
    public int total_minus_mp=1500;
   // public gamemannager Gamemannager;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Update()
    {
        gamemannager gameManagerInstance = FindObjectOfType<gamemannager>();
        if (gameManagerInstance.player_skills.Count >= 1 && gameManagerInstance.player_skills[0] == 2)
        {
            if (Input.GetKeyDown(KeyCode.J) && mpbar_Player.MP >= total_minus_mp)
            {
                start_lighting();
            }

        }
        else if (gameManagerInstance.player_skills.Count >= 2 && gameManagerInstance.player_skills[1] == 2)
        {
            if (Input.GetKeyDown(KeyCode.K) && mpbar_Player.MP >= total_minus_mp)
            {
                start_lighting();
            }

        }
        else if (gameManagerInstance.player_skills.Count >= 3 && gameManagerInstance.player_skills[2] == 2)
        {
            if (Input.GetKeyDown(KeyCode.L) && mpbar_Player.MP >= total_minus_mp)
            {
                start_lighting();
            }

        }

    }
    void start_lighting()
    {
        for (int i = 0; i < total_minus_mp; i++)
        {
            mpbar_Player.minusMP();
        }

        if (spriteRenderer.flipX)
        {
            Vector3 newPosition = transform.position;
            newPosition.x -= 10;
            transform.position = newPosition;

            newPosition.x += 5;
            newPosition.y += 3;
            lighting.transform.position = newPosition;
            //GameObject newLight = Instantiate(lighting);
            StartCoroutine(TurnOffLightAfterDelay(lighting, 0.1f));
        }
        else
        {
            Vector3 newPosition = transform.position;
            newPosition.x += 10;
            transform.position = newPosition;

            newPosition.x -= 5;
            newPosition.y += 3;
            lighting.transform.position = newPosition;
            // GameObject newLight = Instantiate(lighting);
            StartCoroutine(TurnOffLightAfterDelay(lighting, 0.1f));
        }
    }
    IEnumerator TurnOffLightAfterDelay(GameObject newLight, float delayTime)
    {
        lighting.SetActive(true);

        yield return new WaitForSeconds(delayTime);

        lighting.SetActive(false);
    }
}
