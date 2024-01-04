using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class other_gamemannager : MonoBehaviour
{
    public int[] skills= { 2,3,4,5,6};
    public  void remove_array_membor(int number)
    {
        List<int> listFromArray = skills.ToList(); 
        if (listFromArray.Contains(number))
        {
            listFromArray.Remove(number); 
            skills = listFromArray.ToArray(); 
           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
