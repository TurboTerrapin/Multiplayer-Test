using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

public class PlayerList : MonoBehaviour
{
    public List<Player> playerList;


    void Start()
    {
        playerList = new List<Player>();
    }


    public void updateList(List<Player> players)
    {
        playerList = players;
    }


}
