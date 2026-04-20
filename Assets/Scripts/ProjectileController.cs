using Unity.Netcode;
using UnityEngine;

public class ProjectileController : NetworkBehaviour
{
    public float speed = 8f;
    public AudioClip hitSound;

    void Start()
    {
        if (IsServer)
        {
            Invoke(nameof(Deactivate), 5f);
        }
    }

    void Update()
    {
        if (!IsServer) return;

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsServer) return;

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

            Deactivate();
        }
    }

    void Deactivate()
    {
        GetComponent<NetworkObject>().Despawn();
        gameObject.SetActive(false);
    }
}