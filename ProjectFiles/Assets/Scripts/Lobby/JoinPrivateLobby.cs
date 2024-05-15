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
        string joinCode = input.text.Substring(0, 6);

        testLobby.JoinLobbyByCode(joinCode);
    }

}
