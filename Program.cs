//////////////////////////////////////////
/// AUTORS: Dotty, Hellzy
/// DATE: 24/12/2014 01:03
/// PROJECT: ANTI-CONFLOOSE CMD LIKE
//////////////////////////////////////////

using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Anti_Confloose
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] globalCommandes= { "help", "title", "exit", "cls" };
            string globalTitle= "C:\\Windows\\system32\\cmd.exe";
            string input="ToiMemeTuSaisPutainCarl!TaMereLaGrosse!";
            string prompt = System.IO.Directory.GetCurrentDirectory();
            ///////////////////////////////////////////////////////////////

            _Welcome(ref globalTitle);
            while (true)
            {
                _WritePrompt(ref prompt);
                _ReadInput(ref input);
                _Command(input, ref globalTitle, ref globalCommandes);
            }
        }

        static void _CheckScript(string[] args, ref string text)
        {
            if(args.Length!=0)
            {
                text = args[0];
                text= System.IO.File.ReadAllText(text);
            }
        }

        static int _ReadInput(ref string input)
        {
            input = Console.ReadLine();
            if (input.Any(c => c < 0 || c > 126))
            {
                Console.WriteLine("Bad String Only ASCII Char Allowed.");
                input = "";
                return 1;
            }
            
            return 0;
        }

        static int _Welcome(ref string title)
        {
            Console.Title = title;
            Console.WriteLine("Microsoft Windows [version 6.3.9600]\n(c) 2013 Microsoft Corporation. Tous droits reserves.\n");
            return 0;
        }

        static int _WritePrompt(ref string prompt)
        {
            Console.Write(prompt + ">");
            return 0;
        }

        static int _TitleModify(ref string title)
        {
            Console.WriteLine("Input New Title: ");
            _ReadInput(ref title);
            Console.Title = title;
            return 0;
        }

        static int _Help(ref string[] globalCommandes)
        {
            Console.WriteLine("");
            foreach (string comm in globalCommandes)
            {
                Console.WriteLine("\t" + comm);
            }
            Console.WriteLine("");
            return 0;
        }

        static int _Cls()
        {
            Console.Clear();
            return 0;
        }

        static int _Command(string commande, ref string globalTitle, ref string[] globalCommandes)
        {
            switch (commande)
            {
                case "help":
                    _Help(ref globalCommandes);
                    break;
                case "title":
                    _TitleModify(ref globalTitle);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "cls":
                    _Cls();
                    break;
                case "":
                    break;
                default:
                    Console.WriteLine("\"" + commande + "\" is not recognized as a valid command.\nType help to have some.\n");
                    break;
            }
            return 0;
        }
    }
}