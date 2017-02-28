# ModClient
C# client for online messaging services.

##Features:
* **Modular backends**: you can write a simple backend so that ModClient can connect to any type of message service.
* **Plugins**: plugins augment incoming and outgoing messages, so you can write bots or helpful internal functions as an add-on.  

![](http://i.imgur.com/6yaJoBC.png) ![](http://i.imgur.com/nJHTfij.png)  

##Plugin API:
* Plugins must inherit from `PluginBase`
* `ParentService`: This is the MessageService that the plugin is connected to. Use `MessageServiceBase.SendMessage(string message)` for output to the chat.
Subscribe to `MessageServiceBase.OnMessageRecieved` or `MessageServiceBase.OnInfoRecieved` to get notified when data comes in.
* `PluginOutput(string message)`: This will send a message to the user locally, use for output from the plugin that shouldn't be send to the rest of chat.
* `Enabled`: can be set by the outside world to enable/diable this plugin. Override the getter/setter and do not do background operations/listening when disabled.  
**NOTE** `PreprocessOutgoingMessage` wil automatically not be called when disabled, so you do not need to check for enabled/disabled in this method.
* `PreprocessOutgoingMessage`: this is called on every installed plugin before a message is sent to the chat server.
You can augment messages before they are sent.
`return null` from this method to capture the message so nothing is sent to the server.
(This is useful for plugin-specific commands that don't need to get forwarded to the chat server)
