using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Roomdata : MonoBehaviourPunCallbacks
{
    [SerializeField] Button button;
    [SerializeField] string titleText;
    [SerializeField] Text roomText;

    private void Start()
    {
        button.onClick.AddListener(() => PhotonNetwork.JoinRoom(titleText));
    }

    public void UpdateRoomInformation(RoomInfo roomInfo)
    {
        titleText = roomInfo.Name;

        roomText.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " ) ";
    }

    public void UpdateRoomStatus()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
    }
}

