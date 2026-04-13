using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    public NetworkObject topPlayer;
    public NetworkObject bottomPlayer;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;

        NetworkManager.Singleton.OnClientConnectedCallback += AssignPlayers;
    }

    private void AssignPlayers(ulong clientId)
    {
        Debug.Log("Assigning client: " + clientId);

        if (clientId == 0)
        {
            topPlayer.ChangeOwnership(clientId);
        }
        else
        {
            bottomPlayer.ChangeOwnership(clientId);
        }
    }
}