using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab;

    public int lives = 3;

    public override void OnNetworkSpawn()
    {
        if (OwnerClientId == 0)
        {
            transform.position = new Vector2(0, 4);
        }
        else
        {
            transform.position = new Vector2(0, -4);
        }
    }

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
            ShootServerRpc();
        }
    }

    [ServerRpc]
    void ShootServerRpc()
    {
        GameObject proj = ObjectPool.Instance.GetObject();

        proj.transform.position = transform.position + Vector3.down;
        proj.transform.rotation = Quaternion.identity;

        proj.SetActive(true);

        proj.GetComponent<NetworkObject>().Spawn();
    }

    public void TakeHit()
    {
        GameManager.Instance.PlayerHit(this);
    }
}