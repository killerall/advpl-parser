using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advpl_parser.expression
{
    class Expression
    {
        public String Content { get; set; }
        ParserRuleContext ctx;

        public Expression(ParserRuleContext ctx)
        {
            this.ctx = ctx;
            Content = ctx.GetText();
        }
        public Expression()
        {
            
        }

    }
}
