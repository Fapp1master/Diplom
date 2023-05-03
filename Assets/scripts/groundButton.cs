using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundButton : MonoBehaviour, ImechanismsController
{
    public GameObject controllableMechanism;

    private SpriteRenderer sprite;
    private bool IsActive = false; 
    
    public float time = 1f;
    public Sprite buttonUp, buttonDown;

    private IcontrolledByMechanism controlledByMechanism;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        controlledByMechanism = controllableMechanism.GetComponent<IcontrolledByMechanism>();
    }

    private void Update()
    {
        if (IsActive)
        {
            Active();


        }

        else if (!IsActive)
        {
            TimeOutActive(time); 
           
        }
    }
    public void Active()
    {
        sprite.sprite = buttonDown;
        controlledByMechanism.Active();
        CancelInvoke();

    }

    public void InActive()
    {
        sprite.sprite = buttonUp;
        controlledByMechanism.InActive();
    }

    public void TimeOutActive(float time)
    {
        Invoke("InActive" ,time );
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" || collision.gameObject.tag == "Character")
        {
            IsActive = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsActive= false;
    }


}
