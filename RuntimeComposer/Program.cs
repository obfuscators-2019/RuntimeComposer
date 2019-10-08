using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RuntimeComposer
{

    class MainRun
    {
        static void Main(string[] args)
        {


            if(Int32.Parse(args[0]) == 0)
            {
                byte[] body = File.ReadAllBytes("C:\\Users\\Karp\\source\\repos\\MessageBox\\MessageBox\\bin\\Debug\\MessageBox.exe");
                var assembly = Assembly.Load(body);
                var entryPoint = assembly.EntryPoint;
                var commandArgs = new string[0];
                var returnValue = entryPoint.Invoke(null, new object[] { commandArgs });
                Console.WriteLine(returnValue);
            } else
            {

                // at this point I should set up a number of transformations that are picked randomly and used to increase the entropy of possible code paths
                // ex) migrate the child .net assembly into a new process
                //      - maybe rotate processes
                //      - maybe use different injection techniques
                //      - maybe add junk code


                int count = Int32.Parse(args[0]);
                int newCount = count - 1;
                var me = Application.ExecutablePath;
                byte[] body = File.ReadAllBytes(me);
                var assembly = Assembly.Load(body);
                var entryPoint = assembly.EntryPoint;
                var commandArgs = new string[1];
                commandArgs[0] = newCount.ToString();

                System.Windows.Forms.MessageBox.Show("Count: " + commandArgs[0]); 

                var returnValue = entryPoint.Invoke(null, new object[] { commandArgs });
            }

           


        }

    }


    // I always want to try to use recursion and then that i hate it :-(
    /*
    class Runner
    {

        Runner child;
        public byte[] root;


        public Runner(Runner runner, byte []code)
        {
            if(code.Length != 0)
            {
                root = code;
            }

            child = runner;
            
        }

        public Runner(Runner runner)
        {
            child = runner;
        }


        private bool runRunner(Runner composite)
        {
            // base case 
            if(composite == null)
            {
                byte[] body = File.ReadAllBytes("C:\\Users\\Karp\\Downloads\\Program.exe");
                var assembly = Assembly.Load(body);
                var entryPoint = assembly.EntryPoint;
                var commandArgs = new string[0];
                var returnValue = entryPoint.Invoke(null, new object[] { commandArgs });


                return false;
                // in order for this to work I'm going to need to compile this. i'll then need to reference my own .net assembly



            } else // else we're another composite object that needs to execute _another_ .net executable
            {
                //return composite.runRunner(child);
                // ELSE I NEED TO EXECUTE THE COMPOSITE RUNNER .NET ASSEMBLY THAT IS root

                if(root.Length == 0)
                {
                     
                }

                byte[] body = File.ReadAllBytes("C:\\Users\\Karp\\Downloads\\This.exe");
                composite.root = body;
                runRunner(composite);

                var assembly = Assembly.Load(root);
                var entryPoint = assembly.EntryPoint;
                var commandArgs = new string[0]; // could pass argument that is the path of final payload
                var returnValue = entryPoint.Invoke(null, new object[] { commandArgs });

                return true;
            }

            
        }


    }*/
}

