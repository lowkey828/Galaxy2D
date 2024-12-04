using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public int health = 5;
    public GameObject itemPrefab;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void AsteroidSpin()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        if (health == 0)
        {
            Boom();
        }
    }

    void Boom()
    {
        anim.SetTrigger("IsBoom");
        DropItem();
        Destroy(gameObject, 0.48f);
    }
    void DropItem()
    {
        int itemDropChannce = Random.Range(0, 10);
        if (itemDropChannce == 3 || itemDropChannce == 5 || itemDropChannce == 7)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("IsBoom");
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.48f);
        }
        else if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
