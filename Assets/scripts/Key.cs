
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public   class Key : MonoBehaviour, ICelectedItems
{
    public Transform holdItems;
    public Transform parent;
    public GameObject anObjectThatCanBeUsed;

    [SerializeField] private bool isFasingRight;
    private Vector2 lauchOffset;
    private Rigidbody2D item;
    private BoxCollider2D collider ;
    private bool OnisRight = true;
    private Transform isRight;
    private IcontrolledByMechanism CelectedItems;
    
    CelectedItemsDoor celectedItemsDoor;
    
    public float forceDropX;
    public float forceDropY;
    public int Id;
    private void Start()
    {
        item = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
       CelectedItems = anObjectThatCanBeUsed.GetComponent<IcontrolledByMechanism>();
        celectedItemsDoor = anObjectThatCanBeUsed.GetComponent<CelectedItemsDoor>();

    }
    public void OnDestroy()
    {
    
    }
    public void drop()
    {

        OnCollider();
        RigidBodyIsDynamic();
        DestroyParent(); ;
        ImpulseItem();
        

    }

    public void equip()
    {
      transform.position = holdItems.position;
      GetParent();
      RigidBodyIsKinematic();
      OnEnabledCollider();
    }

    public void use()
    {
        

        CelectedItems.Active();

        gameObject.SetActive(false);

        celectedItemsDoor.SwitchIsActive();
        
       
    }
    public void OnEnabledCollider()
    {
        collider.enabled = !collider.enabled;
    }

    public void RigidBodyIsKinematic()
    {
        item.bodyType = RigidbodyType2D.Kinematic;
    }

    public void GetParent()
    {
        transform.SetParent(parent, true);
    }

    public void DestroyParent()
    {
        gameObject.transform.parent = null;
    }
    public void RigidBodyIsDynamic()
    {
        item.bodyType = RigidbodyType2D.Dynamic;
    }

    public void OnCollider()
    {
        collider.enabled = true;
    }
   
    public void SwitchIsRight(bool isRight)
    {
        OnisRight = isRight;
    }

    void ImpulseItem()
    {


        item.velocity = new Vector2(transform.localScale.x * forceDropY, 3) ;
    }

   

    public void Flip()
    {
       transform.Rotate(0.0f, 180.0f, 0.0f);

       forceDropY *= -1;
    }



}
