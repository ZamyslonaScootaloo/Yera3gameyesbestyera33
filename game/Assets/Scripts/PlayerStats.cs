using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int XP=0;
    public int thirst=100;
    public int HP = 100;
    public int stamina = 100;

   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    //aby dodać XP wpisujemy w skrypcie addXP(ilość);
    public void addXP(int addedXP)
    {
        XP = XP + addedXP;
    }
}
