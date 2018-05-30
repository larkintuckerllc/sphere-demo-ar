using Photon;
using UnityEngine.SceneManagement;

namespace com.larkintuckerllc.spheredemoar
{
    public class GameManager : PunBehaviour
    {
        public void LeaveRoom()
        {
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
    }
}