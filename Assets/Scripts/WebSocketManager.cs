using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.WebSockets;
using UnityEngine;

public class WebSocketManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WebSocket();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void WebSocket() {
        try
        {
            ClientWebSocket ws = new ClientWebSocket();
            CancellationToken ct = new CancellationToken();
            Uri url = new Uri("ws://localhost:8080/api/websocket");
            await ws.ConnectAsync(url, ct);
            await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("hello")), WebSocketMessageType.Binary, true, ct);  // Send data

            while (true)
            {
                var result = new byte[1024];
                await ws.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());  // Receive data
                var str = Encoding.UTF8.GetString(result, 0, result.Length);
                Debug.Log(str);
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
