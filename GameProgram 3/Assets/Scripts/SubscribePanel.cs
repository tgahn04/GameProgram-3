using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class SubscribePanel : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField[] inputFields = new InputField[3];

    private void Awake()
    {
        inputFields = GetComponentsInChildren<InputField>();
    }

    public void Subscribe()
    {
        var request = new RegisterPlayFabUserRequest
        {
           Username = inputFields[0].text,
           Email = inputFields[1].text,
           Password = inputFields[2].text,
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            Success,
            Failure
        );
    }

    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        gameObject.SetActive(false);
    }

    public void Failure(PlayFabError playFabError)
    {
        var content = playFabError.GenerateErrorReport();

        var lines = content.Split("\n");

        switch (lines.Length)
        {
            case 1:
                PanelManager.Instance.Load(Panel.Error, $"{lines[0]}");
                break;
            case 2:
                PanelManager.Instance.Load(Panel.Error, $"{lines[1]}");
                break;
            case 3:
                PanelManager.Instance.Load(Panel.Error, $"{lines[1]} \n\n {lines[2]}");
                break;
            case 4:
                PanelManager.Instance.Load(Panel.Error, $"{lines[2]} \n\n {lines[3]}");
                break;
            case 5:
                PanelManager.Instance.Load(Panel.Error, $"{lines[2]} \n\n {lines[3]} \n\n {lines[4]}");
                break;
        }
    }
}
