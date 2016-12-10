using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static advpl_parser.grammar.AdvplParser;

namespace advpl_parser.expression
{
    class ParentsExpression : Expression
    {
        public ExpressionList expression { get; set; }
        public ParentsExpression(ParensContext ctx) : base(ctx)
        {
        }
    }
}
