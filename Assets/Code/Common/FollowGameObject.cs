using UnityEngine;

public class FollowGameObject : MonoBehaviour {

    private GameObject playerInstance;
    private bool foundPlayerInstance = false;

    // Use this for initialization
    void Start () {
		playerInstance = GameManager.GetPlayerInstance();
        if (playerInstance != null)
        {
            foundPlayerInstance = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!foundPlayerInstance)
        {
            playerInstance = GameManager.GetPlayerInstance();
            if (playerInstance != null)
            {
                foundPlayerInstance = true;
            }
        }
        else if (playerInstance != null)
        {
            this.transform.position = new Vector3(playerInstance.transform.position.x - 10, 20, playerInstance.transform.position.z - 10);
            this.transform.LookAt(playerInstance.transform);
        }

    }
}
