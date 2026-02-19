using UnityEngine;
using Photon.Pun;
using NUnit.Framework;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public override void OnConnectedToMaster()
    {
        // joinLobby : 특정 로비를 생성하여 진입하는 함수
        if(PhotonNetwork.InLobby == false)
        {
            PhotonNetwork.JoinLobby();
        }
    }
}
