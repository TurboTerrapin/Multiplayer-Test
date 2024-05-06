using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JoinPrivateLobby : MonoBehaviour
{
    public TMP_InputField input;

    public TestLobby testLobby;

    public void JoinLobby()
    {
        testLobby.JoinLobbyByCode(input.text);
    }

}
