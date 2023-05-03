using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelectedItemsDoor : OpeningTopDoor
{

    bool isActive = false;
   
    private void Update()
    {
        
        if (isActive)
            Open();
    }

    public void SwitchIsActive()
    {
        isActive = true;
    }
}
