using System;
using Antlr4.Runtime;
using advpl_parser.grammar;
using advpl_parser.util;
using advpl_parser;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

class Program
{
    private static void Main(string[] args)
    {
        (new Program()).Run(args);
    }
    public void Run(string[] args)
    {
        try
        {
            RunParser(args[0]);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
        }

    }
    private void RunParser(string source)
    {

        AdvplLanguageServer server = new AdvplLanguageServer();

        server.Start(Console.OpenStandardInput(), Console.OpenStandardOutput()).Wait();

        //Start(Console.OpenStandardInput(), Console.OpenStandardOutput()).Wait();
        /*if (advplParser.NumberOfSyntaxErrors == 0)
        {
            System.Console.WriteLine("OK");
        }
        else
        {
            
            System.Console.WriteLine("AdvplParser Error.");
            
            foreach (AdvplErroInfo info in errorListener.Errors)
            {
                System.Console.WriteLine(info.ToString());
            }
            //string json = JsonConvert.SerializeObject(obj);
        }*/

    }
    public async Task Start(Stream inputStream, Stream outputStream)
    {

        /*NoCaseANTLRFileStream input= new NoCaseANTLRFileStream(source);
        AdvplLexer lexer = new AdvplLexer(input);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
        AdvplParser advplParser = new AdvplParser(commonTokenStream);
        advplParser.RemoveErrorListeners();
        AdvplErrorListener errorListener = new AdvplErrorListener();
        advplParser.AddErrorListener(errorListener);
        ParserRuleContext tree = advplParser.program();
        AdvplCompileInfo info = new AdvplCompileInfo();
        info.Errors = errorListener.Errors;
        string json = JsonConvert.SerializeObject(info);
        System.Console.WriteLine(json);*/
    }
}