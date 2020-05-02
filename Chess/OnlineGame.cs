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
using System.Runtime.InteropServices;

namespace Chess
{
    public delegate void OnConnectionHandler();

    abstract class OnlineGame
    {
        protected BinaryReader reader;
        protected BinaryWriter writer;

        protected Thread thread;

        protected TcpClient client;

        protected int port;

        public Player host, join;

        protected bool host_turn;

        public event OnConnectionHandler OnConnection;

        protected void RaiseOnConnectionEvent()
        {
            if (OnConnection != null)
                OnConnection();
        }

        public void Init()
        {
            InitChars();
            StartCommunication();
        }

        protected abstract void InitChars();

        public void StartCommunication()
        {
            thread = new Thread(new ThreadStart(SocketThread));
            thread.IsBackground = true;
            thread.Start();
        }

        protected void ReadAndUpdateCharacter(Player p)
        {
            List <Piece> pieces = new List<Piece>();
            pieces = p.Pieces;
            Staticstuff.board.white_turn = reader.ReadBoolean();
            foreach(Piece piece in pieces)
            {
                piece.location.x = reader.ReadInt32();
                piece.location.y = reader.ReadInt32();
                piece.isAlive = reader.ReadBoolean();
            }
        }

        protected void WriteCharacterData(Player p)
        {
            List<Piece> pieces = new List<Piece>();
            pieces = p.Pieces;
            writer.Write(Staticstuff.board.white_turn);
            foreach (Piece piece in pieces)
            {
                writer.Write(piece.location.x);
                writer.Write(piece.location.y);
                writer.Write(piece.isAlive);
            }

        }

        protected abstract void SocketThread();

    }
}
