using Photon;
using UnityEngine;

namespace com.larkintuckerllc.spheredemoar
{
    public class Launcher : PunBehaviour
    {
        static readonly string GAME_VERSION = "0.1.0";
        static readonly byte MAX_PLAYERS_PER_ROOM = 4;
        bool isConnecting = false;

        public void Connect()
        {
            // REDUX STATE HERE
            isConnecting = true;
            if (PhotonNetwork.connected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings(GAME_VERSION);
            }
        }

        public override void OnConnectedToMaster()
        {
            if (!isConnecting) return;
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MAX_PLAYERS_PER_ROOM }, null);
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.room.PlayerCount == 1)
            {
                PhotonNetwork.LoadLevel("Play");
            }
        }

        public override void OnDisconnectedFromPhoton()
        {
            Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
        }

        void Awake()
        {
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.automaticallySyncScene = true;
        }
    }
}
