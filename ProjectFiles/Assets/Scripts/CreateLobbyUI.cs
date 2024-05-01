using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreateLobbyUI : MonoBehaviour
{

    public TestLobby testLobby;

    public TMP_InputField lobbyName;

    public Slider lobbySize;

    public Toggle isPrivateLobby;

    public void CreateLobby()
    {
        testLobby.CreateLobby(lobbyName.text, (int)lobbySize.value, isPrivateLobby);
    }
}
