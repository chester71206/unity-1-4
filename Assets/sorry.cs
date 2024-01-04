using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;
public class sorry : MonoBehaviour
{
    [SerializeField] Text score_text;
    public womanaction woamnobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "   Sorry Game is Over~\n        Your Score: " + woamnobject.score.ToString() + "\n Press enter to restart";
    }
}
