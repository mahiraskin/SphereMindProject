using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Threading.Tasks;

public class ManageTurns : NetworkBehaviour
{
    public static ManageTurns Instance;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public bool MyTurn(ulong id)
    {
        var players = NetworkManager.Singleton.ConnectedClientsList;
        if (players[index].ClientId == id)
            index = (index + 1) % players.Count;
        return (players[index].ClientId == id);
        
    }
}
