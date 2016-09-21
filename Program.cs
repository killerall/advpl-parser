using System;
using Antlr4.Runtime;
using advpl_parser.grammar;

class Program
{
    private static void Main(string[] args)
    {
        (new Program()).Run();
    }
    public void Run()
    {
        try
        {
            Console.WriteLine("START");
            RunParser();
            Console.Write("DONE. Hit RETURN to exit: ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
            Console.Write("Hit RETURN to exit: ");
        }
        Console.ReadLine();
    }
    private void RunParser()
    {
        AntlrInputStream inputStream = new AntlrInputStream("hello world\n");
        AdvplLexer helloLexer = new AdvplLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(helloLexer);
        AdvplParser helloParser = new AdvplParser(commonTokenStream);
        /*HelloParser.RContext rContext = helloParser.r();
        MyVisitor visitor = new MyVisitor();
        visitor.VisitR(rContext);*/
    }
}