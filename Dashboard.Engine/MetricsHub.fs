module MetricsHub

open System
open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs
open Microsoft.Owin.Hosting
open Microsoft.AspNet.SignalR.Owin
open FSharp.Interop.Dynamic

[<HubName("metricsHub")>]
type MetricsHub() =
    inherit Hub()

    // if we were intrested in seeing who is connecting
    // or doing something on a new connection this would be the place
    override x.OnConnected() =
        printfn "Connected!"
        base.OnConnected()

    // A function that can be invoked by any client since signalr uses web sockets for two way communication
    member public x.SendMessage(message : string) : unit =
        base.Clients.All?addMessage (message)

