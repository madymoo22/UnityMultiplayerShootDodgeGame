using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab;

    public int lives = 3;

    void Update()
    {
        if (!IsOwner) return;

        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
    }

    void HandleShooting()
    {
        if (OwnerClientId != 0) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position + Vector3.down * 1.0f, Quaternion.identity);
    }

    public void TakeHit()
    {
        GameManager.Instance.PlayerHit(this);
    }
}