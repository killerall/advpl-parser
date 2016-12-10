using advpl_parser.grammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advpl_parser.expression
{
    class ConditionalExpression : BinaryExpression
    {
        public string getOperator()
        {
            return ((AdvplParser.ExprCompContext)Context).op.Text;
        }
    }
}
