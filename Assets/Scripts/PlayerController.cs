using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveSpeedLaser = 5f;
    public GameObject laserPrefab;
    public Transform attackArea;
    public Transform attackAreaLeft;
    public Transform attackAreaRight;

    private int conllectItem = 0;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(inputX, 0).normalized;
        rb.linearVelocity = movement * moveSpeed;


        if (inputX > 0)
        {
            anim.SetBool("IsRight", true);
            anim.SetBool("IsLeft", false);
        }
        else if (inputX < 0)
        {
            anim.SetBool("IsLeft", true);
            anim.SetBool("IsRight", false);
        }
        else
        {
            anim.SetBool("IsLeft", false);
            anim.SetBool("IsRight", false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (conllectItem == 0)
            {
                SingleLaser();
            }
            else if (conllectItem == 1)
            {
                DoubleLaser();
            }
            else if (conllectItem == 2)
            {
                TripleLaser();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (conllectItem < 2)
            {
                Destroy(collision.gameObject);
                conllectItem++;
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void SingleLaser()
    {
        GameObject laser = Instantiate(laserPrefab, attackArea.position, Quaternion.identity);
        Rigidbody2D rbLaser = laser.GetComponent<Rigidbody2D>();
        rbLaser.linearVelocity = new Vector2(0, moveSpeedLaser);
    }

    void DoubleLaser()
    {
        GameObject laserLeft = Instantiate(laserPrefab, attackAreaLeft.position, Quaternion.identity);
        GameObject laserRight = Instantiate(laserPrefab, attackAreaRight.position, Quaternion.identity);

        Rigidbody2D rbLaserLeft = laserLeft.GetComponent<Rigidbody2D>();
        Rigidbody2D rbLaserRight = laserRight.GetComponent<Rigidbody2D>();

        rbLaserLeft.linearVelocity = new Vector2(0, moveSpeedLaser);
        rbLaserRight.linearVelocity = new Vector2(00, moveSpeedLaser);
    }

    void TripleLaser()
    {
        GameObject laser = Instantiate(laserPrefab, attackArea.position, Quaternion.identity);
        Rigidbody2D rbLaser = laser.GetComponent<Rigidbody2D>();
        rbLaser.linearVelocity = new Vector2(0, moveSpeedLaser);

        GameObject laserLeft = Instantiate(laserPrefab, attackAreaLeft.position, Quaternion.identity);
        Rigidbody2D rbLaserLeft = laserLeft.GetComponent<Rigidbody2D>();
        rbLaserLeft.linearVelocity = new Vector2(-0.5f, moveSpeedLaser);

        GameObject laserRight = Instantiate(laserPrefab, attackAreaRight.position, Quaternion.identity);
        Rigidbody2D rbLaserRight = laserRight.GetComponent<Rigidbody2D>();
        rbLaserRight.linearVelocity = new Vector2(0.5f, moveSpeedLaser);
    }
}
