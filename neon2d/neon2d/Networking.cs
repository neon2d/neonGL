using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.WebSockets;
using System.Net.Sockets;

namespace neon2d.Networking
{
    public class Server
    {

        public async void Start(string httpListenerPrefix)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(httpListenerPrefix);
            listener.Start();

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    ProcessRequest(context);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        public async void ProcessRequest(HttpListenerContext context)
        {
            WebSocketContext socketContext = null;
            try
            {
                socketContext = await context.AcceptWebSocketAsync(subProtocol: null);
                string ipAddress = context.Request.RemoteEndPoint.Address.ToString();
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                context.Response.Close();
                neon2d.Message.log("Exception: " + e);
                return;
            }

            WebSocket socket = socketContext.WebSocket;
            try
            {
                byte[] receiveBuffer = new byte[1024];
                while (socket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), System.Threading.CancellationToken.None);
                    if(result.MessageType == WebSocketMessageType.Close)
                    {
                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", System.Threading.CancellationToken.None);
                    }
                    else
                    {
                        await socket.SendAsync(new ArraySegment<byte>(receiveBuffer, 0, result.Count), WebSocketMessageType.Binary, result.EndOfMessage, System.Threading.CancellationToken.None);
                    }
                }

            }
            catch (Exception e)
            {
                neon2d.Message.log("Exception: " + e);
            }
            finally
            {
                if(socket != null)
                {
                    socket.Dispose();
                }
            }
        }

    }

}
