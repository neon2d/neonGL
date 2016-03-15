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

    public class Client
    {

        private static UTF8Encoding encoding = new UTF8Encoding();

        public static string data;

        public void Join(string url)
        {
            Connect(url).Wait();
        }

        public static async Task Connect(string url)
        {

            System.Threading.Thread.Sleep(1000);

            ClientWebSocket socket = null;

            try
            {
                socket = new ClientWebSocket();
                await socket.ConnectAsync(new Uri(url), System.Threading.CancellationToken.None);
                await Task.WhenAll(Receive(socket), Send(socket, "ayy lmao"));
            }
            catch (Exception ex)
            {
                neon2d.Message.log("Exception: " + ex);
            }
            finally
            {
                if(socket != null)
                {
                    socket.Dispose();
                }
            }

        }

        public static async Task Send(ClientWebSocket socket, string content)
        {
            while(socket.State == WebSocketState.Open)
            {
                byte[] buffer = encoding.GetBytes(content);

                await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, System.Threading.CancellationToken.None);

                await Task.Delay(1000);
            }
        }

        public static async Task Receive(ClientWebSocket socket)
        {
            byte[] buffer = new byte[1024];
            while(socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                if(result.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, System.Threading.CancellationToken.None);
                }
                else
                {
                    data = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                }
            }
        }

        public string getData()
        {
            return data;
        }

    }

}
