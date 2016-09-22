using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advpl_parser
{
    public class Message
    {
        public int id { get; private set; }
        public string format { get; private set; }
        public dynamic variables { get; private set; }
        public dynamic showUser { get; private set; }
        public dynamic sendTelemetry { get; private set; }

        public Message(int id, string format, dynamic variables = null, bool user = true, bool telemetry = false)
        {
            this.id = id;
            this.format = format;
            this.variables = variables;
            this.showUser = user;
            this.sendTelemetry = telemetry;
        }
    }
    class AdvplLanguageServer : ProtocolServer
    {
        public void SendErrorResponse(Response response, int id, string format, dynamic arguments = null, bool user = true, bool telemetry = false)
        {
            var msg = new Message(id, format, arguments, user, telemetry);
            //var message = Utilities.ExpandVariables(msg.format, msg.variables);
            //response.SetErrorBody(message, new ErrorResponseBody(msg));
            SendMessage(response);
        }

        protected override void DispatchRequest(string command, dynamic args, Response response)
        {
            if (args == null)
            {
                args = new { };
            }

            try
            {
                switch (command)
                {

                    case "initialize":
                        Initialize(response, args);
                        break;
                    case "parse":
                        Parse(response, args);
                        break;
                }
            }
            catch (Exception e)
            {
                SendErrorResponse(response, 1104, "error while processing request '{_request}' (exception: {_exception})", new { _request = command, _exception = e.Message });
            }

            if (command == "disconnect")
            {
                Stop();
            }
            
        }

        public void Initialize(Response response, dynamic args)
        {

        }
        public void Parse(Response response, dynamic args)
        {

        }
    }
}
