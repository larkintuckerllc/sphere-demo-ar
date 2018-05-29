using Photon;
using UnityEngine.SceneManagement;

namespace com.larkintuckerllc.spheredemoar
{
    public class GameManager : PunBehaviour
    {
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
    }
}