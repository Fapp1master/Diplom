using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Tutorial : MonoBehaviour
{
   public  Animation anim;
   public TMP_Text text;
    private void Update()
    {
        anim.Play();
    }
    
    public void changeText()
    {
        text.text = "Thanks, go to finish";   
    }

}
