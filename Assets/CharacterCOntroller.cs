using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterCOntroller : MonoBehaviour
{
   public GameObject Character;
    private character Person;
    private void Start()
    {
        try
        {
        Person = Character.GetComponent<character>();
        }
        catch 
        {
            Debug.Log("Person ничего не получает");
           
        }
    }
    public void Jump()
    {
        Person.checkInput();
    }
    public void moveRight()
    {
        Person.HorizontalSpeed = Person.movementSpeed;
        if (Person.HorizontalSpeed <0)
        {
            ChangeSpeed();
        }
       
       
    }
    public void MoveLeft()
    {
        Person.HorizontalSpeed = Person.movementSpeed;
        if (Person.HorizontalSpeed > 0)
        {
            ChangeSpeed();
        }
       

    }

    private void ChangeSpeed()
    {
        Person.HorizontalSpeed *= -1;
    }
    public void Stop()
    {
        Person.HorizontalSpeed = 0;
    }
    public void Use()
    {
        Person.CheckInputUsed();
    }
    public void Equip()
    {
        Person.takeItem();
    }

    public void DropItem()
    {
        Person.CheckInputItem();
    }
}
