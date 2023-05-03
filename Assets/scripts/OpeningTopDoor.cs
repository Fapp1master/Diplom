using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public  class OpeningTopDoor :Door , IcontrolledByMechanism 
{
    private Transform door;

   [SerializeField] private Vector2 endPoint;
   [SerializeField] private Vector2 startPoint;

    public float distanceToTheEnd;
    public float step;
    private void Start()
    {
        door = GetComponent<Transform>();
        startPoint = new Vector2(transform.position.x, transform.position.y);
        endPoint = new Vector2(transform.position.x , transform.position.y + distanceToTheEnd);
    }

    public void InActive()
    {
        Close();
    }
    public void Active()
    {
        Open();
    }
   override public  void Close()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint, step * Time.fixedDeltaTime);
        Debug.Log("Close");
    }

   override public  void Open()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPoint, step * Time.fixedDeltaTime);
        Debug.Log("Open"); 
    }

    public void Reload()
    {
        
    }

   
}
