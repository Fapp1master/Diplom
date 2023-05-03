using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class character :MonoBehaviour
{
    private Rigidbody2D rb;

    public bool isFasingRight = true;
    private bool isRunning;
    private  Collider2D items;
    private GameObject item;
    private bool isUsed;
    private ICelectedItems celevtedItems;

   [SerializeField] private bool isGrounded;
   [SerializeField] private bool canJump;
   [SerializeField] private bool isEquided;
   [SerializeField] private bool isEquip = false;

    private Animator CharacterAnimator;

    public float groundCheckRadius;
    public float checkEuipItemsRadius;
    public float movementSpeed = 10.0f;
    public float HorizontalSpeed;
    public float jumpForce = 10.0f;

    public Transform checkEquipItems;
    public Transform grounCheck;

    public LayerMask whatIsItems;
    public LayerMask whatIsGround;
    public LayerMask whatIsUsed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
          CharacterAnimator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
       
        checkMovementDirection();
        ChangeAnimations();
        CheckSurroundings();
        CheckIfCanJump();
        CheckIfcanEquip();
        CheckCelectedItems();
        TakeCollider();
        
        
        CheckUsed();
    }
    public void checkInput ()
    {
        Jump();
    }
     public void Move()
    {
        rb.velocity = new Vector2(HorizontalSpeed,rb.velocity.y);
    }
   

    private void checkMovementDirection()
    {
        if (isFasingRight && HorizontalSpeed < 0)
        {
            Flip();
        }
        else if (!isFasingRight && HorizontalSpeed > 0)
        {
            Flip();
        }

        if (HorizontalSpeed != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        
    }
    private void Flip()
    {
        isFasingRight = !isFasingRight;
        transform.Rotate(0.0f , 180.0f,0.0f);
        if (isEquip)
        {
            FlipCelectedItems();
        }
      
    }
    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
    }    
    private void ChangeAnimations()
    {
        CharacterAnimator.SetBool("IsRunning",isRunning);
    }

    void CheckCelectedItems()
    {
       isEquided = Physics2D.OverlapCircle(checkEquipItems.position, checkEuipItemsRadius, whatIsItems);
       
    }
    void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(grounCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(grounCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(checkEquipItems.position, checkEuipItemsRadius);
    }
    private void CheckIfCanJump()
    {
        if (isGrounded )
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
    private void CheckIfcanEquip()
    {
        if (isEquided)
        {
            TakeGameObject();
        }
        else
        { 
        isEquided = false;
        }
    }
    
	public void takeItem()
    {
        if (isEquided  && !isEquip) 
        {
            TakeGameObject();

            celevtedItems.equip();

            isEquip = true;
        }
    }

   public  void TakeGameObject()
    {
        if (items != null) 
        { 
        item = items.gameObject;
        celevtedItems = item.GetComponent<ICelectedItems>();
        }
        else
        {
            isEquided = false;
        }
        
    }
    public void TakeCollider()
    {
        items = Physics2D.OverlapCircle(checkEquipItems.position, checkEuipItemsRadius, whatIsItems);

    }

    public void DropItem()
    {
        celevtedItems.drop();

    }

    public void CheckInputItem()
    {
        if (  isEquip)
        {
            DropItem();
            isEquip = false;
        }
    }

    public void CheckUsed()
    {
       isUsed = Physics2D.OverlapCircle(checkEquipItems.position, checkEuipItemsRadius, whatIsUsed);
    }

    public void CheckInputUsed()
    {
        if ( isEquip )
        {
            celevtedItems.use();
        }
    }

   public  void FlipCelectedItems()
    {
        celevtedItems.Flip();
    }
}
