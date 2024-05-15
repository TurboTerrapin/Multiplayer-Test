using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using UnityEngine;

public class TestRelay : MonoBehaviour
{

    public int lobbySize;

    // Start is called before the first frame update
    void Start()
    {
        GetRegions();
    }

    public async void CreateRelay()
    {
        try
        {

            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(lobbySize);

            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            RelayServerData relayServerData = new RelayServerData(allocation, "wss");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();

            Debug.Log("Created Relay! " + joinCode + " " + allocation.AllocationId);
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    public async void JoinRelay(string joinCode)
    {
        try
        {
            Debug.Log("Joining relay with " + joinCode + " j e j ");

            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            Debug.Log("Here 1");

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "wss");

            Debug.Log("Here 2");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            Debug.Log("Here 3");

            NetworkManager.Singleton.StartClient();

            Debug.Log("Relay Connected Successfully");

            //RelayService.Instance.
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    /*
    public async void LeaveRelay()
    {
        try
        {
            //await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId);
            //RelayService.Instance.
            //hostLobby = null;
            //joinedLobby = null;
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }
    */
    public async void GetRegions()
    {
        try
        {
            Debug.Log(await RelayService.Instance.ListRegionsAsync());
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

}
