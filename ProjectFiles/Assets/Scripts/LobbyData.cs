using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

public class LobbyData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI playersText;
    [SerializeField] private TextMeshProUGUI gameModeText;
    [SerializeField] private TextMeshProUGUI lobbyCodeText;

    public TestLobby testLobby;
    private float timer;

    private void Awake()
    {
        
    }

    private void Update()
    {
        UpdateLobby();
    }

    public void UpdateLobby()
    {
        if (timer < 0f)
        {
            Lobby lobby = testLobby.GetLobby();
            lobbyNameText.text = lobby.Name;
            playersText.text = lobby.Players.Count + "/" + lobby.MaxPlayers;
            gameModeText.text = lobby.Data["GameMode"].Value;
            lobbyCodeText.text = lobby.LobbyCode;
            timer = 1.3f;
        }
        timer -= Time.deltaTime;
    }
}
