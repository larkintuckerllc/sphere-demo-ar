using Photon;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.larkintuckerllc.spheredemoar
{
    public class GameManager : PunBehaviour
    {
        public GameObject playerPrefab;

        public void LeaveRoom()
        {
            // TODO: REDUX STATE HERE
            PhotonNetwork.LeaveRoom();
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer other)
        {
            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.LoadLevel("Play");
            }
        }
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene("Menu");
        }

        void Start()
        {
            if (PlayerManager.LocalPlayerInstance == null)
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
        }
    }
}