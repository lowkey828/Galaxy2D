using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Asteroid asteroid = collision.GetComponent<Asteroid>();

            if (asteroid != null)
            {
                asteroid.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
