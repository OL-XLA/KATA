import * as signalR from "@microsoft/signalr";

// On ne crée qu'un seul connecteur qui recevra les updated du hub back
class Connector {
  private connection: signalR.HubConnection;
  static connected : boolean = false;
  public events: (
    onMessageReceived: (guid: string, message: string) => void,
    onLogUpdated: (log: string, guid: string) => void
  ) => void;
  static instance: Connector;
  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      // En dur car tres/trop longue à etablir avec le proxy
      .withUrl("http://localhost:7221/ws")
      .withAutomaticReconnect()
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this.events = (onMessageReceived, OnLogUpdated) => {
      this.connection.on("UpdateLog", (log, guid) => {
        OnLogUpdated(log, guid);
      });
      this.connection.on("ReceivedMessage", (streamId, message) => {
        onMessageReceived(streamId, message);
      });
    };

    this.connection.onclose(()=>Connector.connected=false)


    this.connection.start().then(()=>
      {
        Connector.connected = true
      })
  }

  public Register = (guid: string) => {
    this.connection
      .send("register", guid)
      .then((x) => console.log(" register"));
  };


public GetConnected() :boolean{
  return Connector.connected ? Connector.connected : false;
}

  public static getInstance(): Connector {
    if (!Connector.instance) Connector.instance = new Connector();
    return Connector.instance;
  }
}
export default Connector.getInstance;
