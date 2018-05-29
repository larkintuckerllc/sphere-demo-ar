using UnityEngine;

public class InitializeApp : MonoBehaviour {
	void Awake () {

        // INITIALIZE REDUX
        Provider.Initialize();
        SphereColor.Instance.Intialize();
	}
}
