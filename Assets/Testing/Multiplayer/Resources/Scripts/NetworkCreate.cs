using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCreate : MonoBehaviour
{
	public GameObject Player1;
	public GameObject Player2;
	public GameObject Rules;

	// Start is called before the first frame update
	void Start()
	{
		//NetworkIdentity go = Instantiate(GameObject, transform.position, transform.rotation);
		//GameObject.transform.Translate(1, 0, 0);
		if (NetworkServer.active)
		{
			var rules = Rules.GetComponent<TicTacToeRules>();

			var popUp = GetComponent<PopUp>();

			var p1 = NetworkManager.Instantiate(Player1);
			var p2 = NetworkManager.Instantiate(Player2);

			var p1c = p1.GetComponentsInChildren<Snap>();
			var p2c = p2.GetComponentsInChildren<Snap>();

			NetworkServer.SpawnWithClientAuthority(p1, GameObject.FindGameObjectsWithTag("Player")[0]);
			// p1.GetComponentInChildren<Snap>()
			for (int i = 0; i < p1c.Length; i++)
			{
				rules.Player1.Add(p1c[i]);
			}
			NetworkServer.SpawnWithClientAuthority(p2, GameObject.FindGameObjectsWithTag("Player")[1]);
			for (int i = 0; i < p2c.Length; i++)
			{
				rules.Player2.Add(p2c[i]);
			}

			var state = NetworkManager.Instantiate(Rules);

			NetworkServer.Spawn(state);

			popUp.State = state.GetComponent<GameState>();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
