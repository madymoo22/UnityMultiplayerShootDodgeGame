using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gameUI; 

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        menuUI.SetActive(false);
        gameUI.SetActive(true); 
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        menuUI.SetActive(false);
        gameUI.SetActive(true); 
    }
}