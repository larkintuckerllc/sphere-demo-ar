using Photon;
using ExitGames.Client.Photon;
using UnityEngine;

public class Button : PunBehaviour
{
    public void HandleClick()
    {
        var test = new Hashtable();
        test.Add("a", "apple");
        Debug.Log("CLICKED");
        PhotonNetwork.room.SetCustomProperties(test);
    }

    public override void OnPhotonCustomRoomPropertiesChanged(Hashtable wow)
    {
        Debug.Log(wow);
    }
}
