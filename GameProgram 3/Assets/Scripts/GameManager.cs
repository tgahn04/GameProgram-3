using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] double time;
    [SerializeField] double initializeTime;

    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int millisecond;

    [SerializeField] Text timeText;

    void Awake()
    {
        initializeTime = PhotonNetwork.Time;
    }

    void Update()
    {
        time = PhotonNetwork.Time - initializeTime;

        minute = (int)time / 60;
        second = (int)time % 60;
        millisecond = (int)(time * 100) % 100;

        timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, millisecond);
    }
}
