using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class MyNetworkTest : NetworkManager {

    public Transform NetworkUIGroup;

    private Button testBtn;
    private Button hostBtn;
    private Button clientBtn;

        
    private void Start()
    {
        testBtn = NetworkUIGroup.Find("testBtn").GetComponent<Button>();
        hostBtn = NetworkUIGroup.Find("hostBtn").GetComponent<Button>();
        clientBtn = NetworkUIGroup.Find("clientBtn").GetComponent<Button>();

        testBtn.onClick.AddListener(delegate { Debug.Log("OnTestBtnClick"); });

        hostBtn.onClick.AddListener(OnHostBtnClick);
        clientBtn.onClick.AddListener(OnClientBtnClick);
    }

    private void OnHostBtnClick()
    {
        print("StartHost()");
        StartHost();
    }

    private void OnClientBtnClick()
    {
        print("OnClientBtnClick()");
        networkAddress = "192.168.0.10";
        //print("maxDelay : "+maxDelay);

        var m_config = new ConnectionConfig();

        m_config.ConnectTimeout = 200;

        connectionConfig.ConnectTimeout = 500;

        //m_config.DisconnectTimeout = 400;
        print("connectionTimeout : " + m_config.ConnectTimeout);
        print("connectionConfig.connTimeout : " + connectionConfig.ConnectTimeout);
        //print("disconnectTimeout : " + m_config.DisconnectTimeout);

        StartClient(null, connectionConfig);
        //m_netwokClient = new NetworkClient();
        client.RegisterHandler(MsgType.Disconnect, ConnectionError);
        //m_netwokClient.Connect(networkAddress, networkPort);

        StartCoroutine(ClientConnectionChecker());
    }

    private void Update()
    {
        
        if (!NetworkClient.active && !NetworkServer.active )
        {
            NetworkUIGroup.gameObject.SetActive(true);
        } else
        {
            NetworkUIGroup.gameObject.SetActive(false);
        }
    }

    IEnumerator ClientConnectionChecker()
    {
        int i = 0;
        while(true)
        {
            //print(isNetworkActive); // true
            //print(NetworkClient.active); // true
            //print(client.isConnected); // false

            print(i++);
            yield return new WaitForSeconds(1);
        }
        
    }

    public void ConnectionError(NetworkMessage netMsg)
    {
        print("connection error");
        print(netMsg);
        client.Disconnect();
        NetworkClient.ShutdownAll();
        //client.Disconnect();
    }

}
