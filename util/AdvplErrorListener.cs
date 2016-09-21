using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using System.Collections;
using advpl_parser.grammar;
using Antlr4.Runtime.Misc;

namespace advpl_parser.util
{
    class AdvplErroInfo
    {
        public int Line;
        public int Column;
        public int TokenSize;
        public string Message;
        public override string ToString()
        {
            return "[" + Line + "]" + "[" + Column + ":" + TokenSize + "][" + Message + "]";
        }
    }


    class AdvplErrorListener : BaseErrorListener
    {
        public ArrayList Errors;
        public AdvplErrorListener ()
        {
            Errors = new ArrayList();
        }
        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {


            
            AdvplErroInfo info = new AdvplErroInfo();
            info.Line = line;
            
            info.Column = charPositionInLine;
            info.TokenSize = offendingSymbol.Text.Length;
            
            if (msg.Contains("missing {':', 'TO', 'NEXT', 'END', 'SELF', 'PROJECT', 'DEFAULT', 'ASSUME', 'DATA', 'WSMETHOD', 'DESCRIPTION', 'AS', 'OF', IDENTIFIER}"))
                info.Message = "missing IDENTIFIER";
            else
                info.Message = msg;
            Errors.Add(info);


        }

    }
}
