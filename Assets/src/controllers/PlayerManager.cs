using Photon;
using UnityEngine;

public class PlayerManager : PunBehaviour {

    public static GameObject LocalPlayerInstance;

    void Awake()
    {
        if (photonView.isMine)
        {
            LocalPlayerInstance = gameObject;
        }
        DontDestroyOnLoad(gameObject);
    }
}
