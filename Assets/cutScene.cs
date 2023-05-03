using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class cutScene : MonoBehaviour
{
   public Animation anim;
    public GameObject canvas , canvas1;

    private void Start()
    {
        
    }
    private void Update()
    {
        canvas1.SetActive(false);
        anim.Play();
        Invoke("destroyAnim", 18.0f);
    }
    private void destroyAnim()
    {
        canvas.SetActive(false);
        canvas1.SetActive(true);
    }

}
