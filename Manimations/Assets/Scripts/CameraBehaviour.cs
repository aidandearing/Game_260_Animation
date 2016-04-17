using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
    public static Vector3 COM;

    GameObject[] players;
    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 com = Vector3.zero;

        foreach (GameObject player in players)
        {
            com += player.transform.position;
        }
        com /= players.Length;
        com = new Vector3(com.x, 0, com.z);

        float distFromCom = float.NegativeInfinity;

        foreach (GameObject player in players)
        {
            distFromCom = Mathf.Max((com - player.transform.position).magnitude, distFromCom);
        }

        transform.position = com + new Vector3(5 + distFromCom, 5 + distFromCom, 0);

        COM = com;
    }
}
