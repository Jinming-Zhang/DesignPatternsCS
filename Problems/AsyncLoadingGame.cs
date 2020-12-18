using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

/// <summary>
/// This problem involves asynchronous coing in C# and the handling of synchronize all the codes.
/// Problem: The problem involes many clients and a server.
/// 
/// When clients start a game, they have loading tha game content asynchronizely, however, the server needs to provide a way that makes the game start only after all the clients have finished the loading process.
/// </summary>
namespace interviewAsyncLoadingGame {
    public class ClientLoadGameEventArg : EventArgs {
        public Client SenderClient { get; set; }
        public int LoadingTimeTaken { get; set; }
        public ClientLoadGameEventArg (Client client, int loadingTimeTake) {
            this.SenderClient = client;
            this.LoadingTimeTaken = loadingTimeTake;
        }
    }
    public class Client {
        public event EventHandler<ClientLoadGameEventArg> LoadGameFinished;
        public static int ID = 1;
        public Server CurrentServer { get; set; }
        string name;
        public string Name { get { return this.name; } set { this.name = value; } }
        public Client () {
            this.name = $"client {Client.ID}";
            Client.ID++;
        }

        public void StartGame () {
            WriteLine ($"{this.name} requested starting the game.");
            new Thread (LoadGameAsync).Start ();
            WriteLine ($"{this.name} has finished setting up the game.");
        }
        private void LoadGameAsync () {
            int loadTime = new Random ().Next () % 5 + 2;
            WriteLine ($"{this.name} is loading the game in {loadTime} sec...");
            Thread.Sleep (loadTime * 1000);
            WriteLine ($"{this.name} has finished loading the game!");
            this.LoadGameFinished (this, new ClientLoadGameEventArg (this, loadTime));
        }
        public void RequestStartGame () {
            this.CurrentServer.StartGame ();
        }
    }
    public class Server {
        public List<Client> clients;
        int ClientLoadGameFinishedCounter;
        public Server () {
            clients = new List<Client> ();
            ClientLoadGameFinishedCounter = 0;
        }
        public void AddClient (Client c) {
            clients.Add (c);
            c.CurrentServer = this;
        }
        public void AddClients (List<Client> clients) {
            for (int i = 0; i < clients.Count; i++) {
                Client client = clients[i];
                client.CurrentServer = this;
                client.LoadGameFinished += this.OnClientLoadGameFinishedHandler;
                this.clients.Add (client);
            }
        }
        public void StartGame () {
            this.StartGameSync ();
        }
        public void StartGameSync () {
            foreach (var client in clients) {
                new Thread (client.StartGame).Start ();
            }
            while (this.ClientLoadGameFinishedCounter < this.clients.Count) { }
            WriteLine ("Server: Game start!");
        }

        public void OnClientLoadGameFinishedHandler (object sender, ClientLoadGameEventArg e) {
            WriteLine ($"Server: {e.SenderClient.Name} has finished loading the game");
            this.ClientLoadGameFinishedCounter++;

        }
    }
    public static class SolutionDemo {
        public static void Demo () {

            WriteLine ("Async loading game solution...");
            Server gameserver = new Server ();
            List<Client> clients = new List<Client> () { new Client (), new Client (), new Client () };
            gameserver.AddClients (clients);
            gameserver.StartGameSync ();
        }
    }
}