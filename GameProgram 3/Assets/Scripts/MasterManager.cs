using UnityEngine;
using Photon.Pun;
using System.Collections;
using Photon.Realtime;

public class MasterManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5);

    public IEnumerator Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Potion", Vector3.zero, Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        // base.OnMasterClientSwitched
    }
}
