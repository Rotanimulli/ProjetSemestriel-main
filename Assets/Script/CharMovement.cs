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


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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


        if (CheckBooster())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vDirection += 20;
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
            lastDir = -1;
            myTransform.position = myTransform.position - new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            lastDir = 1;
            myTransform.position = myTransform.position + new Vector3(speed, 0, 0);
        }

        rb.linearVelocityY += vDirection; //gere une partie du saut

        if (isOnWall)
        {
            rb.gravityScale = 0;
            rb.linearVelocityY = 0;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.linearVelocityY = 2;
            }
        }
        else
        {
            rb.gravityScale = 1;
        }
    }



    public bool CheckGround() //empeche de spamm saut
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.1f, groundmask);
        if (rayCastHit)
        {
            return true;
        }
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
        Gizmos.DrawRay(transform.position, Vector3.down * 1.1f);
    }
}





