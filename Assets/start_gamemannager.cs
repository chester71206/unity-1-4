using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Text = TMPro.TextMeshProUGUI;
using UnityEngine.UI;
public class start_gamemannager : MonoBehaviour
{
    public GameObject[] explainButton;
    public gamemannager Gamemannager;
    public other_gamemannager other_Gamemannager;
    public skill_1_dissappear[] Skill_1_Dissappear;
    public skill_1_dissappear The_Skills_You_Have;
    public GameObject Choose_any_you_Like;
    bool flag = false;
    List<int> selectedSkills;
    bool next_round = false;
    bool start_choose = false; //讓玩家進入選擇階段之前不能按按鈕
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < explainButton.Length; i++)
        {
            explainButton[i].SetActive(false);
        }
        for (int i = 0; i < 10; i++)
        {
            if (!other_Gamemannager.skills.Contains(i))
            {
                Skill_1_Dissappear[i].turn_animate();
            }

        }

        StartCoroutine(choose());
    }
    IEnumerator choose()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 10; i++)
        {
            Skill_1_Dissappear[i].turn_animate();
        }
        The_Skills_You_Have.turn_animate();
        yield return new WaitForSeconds(1f);
        Choose_any_you_Like.SetActive(true);

        Gamemannager.ClearPlayerSkills(); //清掉玩家的所有技能，開始選
        start_choose = true;

        for (int i = 0; i < 3; i++)
        {
            next_round = false;
            if (other_Gamemannager.skills.Length >= 3)
            {
                selectedSkills = new List<int>();
                int skillsCount = other_Gamemannager.skills.Length;
                while (selectedSkills.Count < 3)
                {
                    int randomIndex = Random.Range(0, skillsCount);
                    int selectedSkill = other_Gamemannager.skills[randomIndex];

                    // 確保選出的技能不重複
                    if (!selectedSkills.Contains(selectedSkill))
                    {
                        selectedSkills.Add(selectedSkill);
                    }
                }
                foreach (int skill in selectedSkills)
                {
                    explainButton[skill].SetActive(true);
                    Skill_1_Dissappear[skill].turn_on();
                    Skill_1_Dissappear[skill].start_press();
                }

            }
            else if (other_Gamemannager.skills.Length >= 2)
            {
                selectedSkills = new List<int>();
                int skillsCount = other_Gamemannager.skills.Length;
                while (selectedSkills.Count < 2)
                {
                    int randomIndex = Random.Range(0, skillsCount);
                    int selectedSkill = other_Gamemannager.skills[randomIndex];

                    // 確保選出的技能不重複
                    if (!selectedSkills.Contains(selectedSkill))
                    {
                        selectedSkills.Add(selectedSkill);
                    }
                }
                foreach (int skill in selectedSkills)
                {
                    explainButton[skill].SetActive(true);
                    Skill_1_Dissappear[skill].turn_on();
                    Skill_1_Dissappear[skill].start_press();
                }

            }
            else if (other_Gamemannager.skills.Length >= 1)
            {
                selectedSkills = new List<int>();
                int skillsCount = other_Gamemannager.skills.Length;
                while (selectedSkills.Count < 1)
                {
                    int randomIndex = Random.Range(0, skillsCount);
                    int selectedSkill = other_Gamemannager.skills[randomIndex];

                    // 確保選出的技能不重複
                    if (!selectedSkills.Contains(selectedSkill))
                    {
                        selectedSkills.Add(selectedSkill);
                    }
                }
                foreach (int skill in selectedSkills)
                {
                    explainButton[skill].SetActive(true);
                    Skill_1_Dissappear[skill].turn_on();
                    Skill_1_Dissappear[skill].start_press();
                }

            }
            else
            {
                next_round = true;
                goto end;
            }
            while (next_round == false)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1f);

        }
        end:
        DontDestroyOnLoad(Gamemannager);
        SceneManager.LoadScene(1);

    }
    public void press_skill(int skillIndex)
    {
        if (start_choose == true)
        {
            Gamemannager.player_skills.Add(skillIndex);
            other_Gamemannager.remove_array_membor(skillIndex);
            foreach (int skill in selectedSkills)
            {
                explainButton[skill].SetActive(false);
                Skill_1_Dissappear[skill].turn_off();
                Skill_1_Dissappear[skill].stop_press();
            }
            selectedSkills.Clear();
            next_round = true;
        }
       

    }
    public void press_skill_explanation(GameObject explain)
    {
        if (explain.activeSelf)
        {
            explain.SetActive(false);
        }
        else
        {
            explain.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
