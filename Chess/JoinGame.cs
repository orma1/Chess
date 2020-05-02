using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Chess
{
    class JoinGame : OnlineGame
    {
        string hostip;

        public JoinGame(string hostip, int port)
        {
            this.port = port;
            this.hostip = hostip;
        }

        protected override void InitChars()
        {
            host = new Player(PieceColor.White);

            join = new Player(PieceColor.Black);
        }

        protected override void SocketThread()
        {
            client = new TcpClient();
            client.Connect(hostip, port);
            reader = new BinaryReader(client.GetStream());
            writer = new BinaryWriter(client.GetStream());

            base.RaiseOnConnectionEvent();

            while (true)
            {
                ReadAndUpdateCharacter(host);
                WriteCharacterData(join);
                Thread.Sleep(10);
            }
        }
    }
}
