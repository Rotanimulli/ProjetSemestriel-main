using JetBrains.Annotations;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public Rigidbody2D rb; //Ne pas oublier d'activer la gravity scale du rigidbody et d'ajouter un collider
    public float speed = 1;
    public float jumpforce = 1;
    public LayerMask groundmask; //Quels layer seront affecté par le raycast attention a ne pas ajouter le layer de votre perso sinon le raycast va trouver le perso avant de trouver le sol
    public LayerMask boostermask;
    public LayerMask leftgrabablemask;
    public LayerMask rightgrabablemask;
    public Transform myTransform;
    public bool isOnWall;
    public float lastDir;
    [SerializeField] private Animator Cory;

    private Vector3 originalScale;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = myTransform.localScale;
        print(originalScale);   
    }

    void Update()
    {

        var vDirection = 0f;
        if (CheckGround())
        {
            if (Input.GetKeyDown(KeyCode.Space)) //gere le saut
            {
                vDirection += jumpforce;
            }
        }

   
        

        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            Cory.SetTrigger("jumpAction");
        }


        if (CheckBooster())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vDirection += 10;
            }
        }

        if (CheckLeftGrabableWall() || CheckRightGrabableWall()) //pour sauter du mur, mais ne fonctionne pas
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vDirection += jumpforce;
            }
        }

        if (CheckLeftGrabableWall() || CheckRightGrabableWall()) //le grab d'un mur vers la droite fonctionne, pas vers la gauche
        {
            isOnWall = true;
        }
        else
        {
            isOnWall = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //mouvements gauche/droite
        {
            WalkLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           WalkRight();
        }
        print(myTransform.localScale);
        if ((Input.GetKey(KeyCode.LeftArrow)) | Input.GetKey(KeyCode.RightArrow))
        {
            Cory.SetBool("isMoving", true);
        }
        else
        {
            Cory.SetBool("isMoving", false);
        }


            rb.linearVelocityY += vDirection; //gere une partie du saut

        if (isOnWall)
        {
            rb.gravityScale = 0;
            rb.linearVelocityY = 0;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.linearVelocityY = 2;
                Cory.SetBool("isClimbing", true);
            }
        }
        else
        {
            rb.gravityScale = 1;
            Cory.SetBool("isClimbing", false);
        }
    }

    private void WalkRight()
    {
        lastDir = 1;
        myTransform.position = myTransform.position + new Vector3(speed, 0, 0);
        myTransform.localScale = originalScale;
    }

    private void WalkLeft()
    {
        lastDir = -1;
        myTransform.position = myTransform.position - new Vector3(speed, 0, 0);
        myTransform.localScale = new Vector3(myTransform.localScale.x * -1, myTransform.localScale.y, myTransform.localScale.z);
        myTransform.localScale = new Vector3(originalScale.x*-1, originalScale.y, originalScale.z); 
    }

    public bool CheckGround() //empeche de spamm saut
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.2f, groundmask);
        if (rayCastHit)
        {
            Cory.SetBool("isOnGround", true);
            return true;
        }
        Cory.SetBool("isOnGround", false);
        return false;
    }

    public bool CheckBooster()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.1f, boostermask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }

    public bool CheckLeftGrabableWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(1, 0), 1.1f, leftgrabablemask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }

    public bool CheckRightGrabableWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1.1f, rightgrabablemask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.down * 0.2f);
    }
}





