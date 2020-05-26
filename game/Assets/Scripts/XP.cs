using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    int xp = 0;
    int expPoint = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            addXP(50);
            Debug.Log("xp" + xp);
            Debug.Log("expieriencePoint" + expPoint);
        }
        if (xp == 100)
        {
            expPoint++;
            xp = 0;
        }
    }

    public void addXP(int newXP)
    {
        xp += newXP;
    }
}
