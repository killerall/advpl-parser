using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using advpl_parser.grammar;
using advpl_parser.util;
using Newtonsoft.Json;
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
        public void SendResponse(Response response, dynamic body = null)
        {
            if (body != null)
            {
                response.SetBody(body);
            }
            SendMessage(response);
        }
        public void Initialize(Response response, dynamic args)
        {

        }
        public void Parse(Response response, dynamic args)
        {
            string source = getString(args, "source");
            NoCaseAntlrStringStream input = new NoCaseAntlrStringStream(source);
            AdvplLexer lexer = new AdvplLexer(input);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            AdvplParser advplParser = new AdvplParser(commonTokenStream);
            advplParser.RemoveErrorListeners();
            AdvplErrorListener errorListener = new AdvplErrorListener();
            advplParser.AddErrorListener(errorListener);
            ParserRuleContext tree = advplParser.program();
            AdvplCompileInfo info = new AdvplCompileInfo();
            info.Errors = errorListener.Errors;
            //string json = JsonConvert.SerializeObject(info);
            SendResponse(response, info);
            //System.Console.WriteLine(json);
        }
        private static string getString(dynamic args, string property, string dflt = null)
        {
            var s = (string)args[property];
            if (s == null)
            {
                return dflt;
            }
            s = s.Trim();
            if (s.Length == 0)
            {
                return dflt;
            }
            return s;
        }
    }

}
