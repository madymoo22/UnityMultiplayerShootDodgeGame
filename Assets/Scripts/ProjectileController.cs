using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 8f;

    public AudioClip hitSound; 

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeHit();

                if (hitSound != null)
                {
                    AudioSource.PlayClipAtPoint(hitSound, transform.position, 2.0f);
                }
            }

            Destroy(gameObject);
        }
    }
}