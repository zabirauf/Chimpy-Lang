using System;
using System.Collections.Generic;
using System.IO;

namespace ChimpyLang
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Bootstrapping!");
			TextReader reader = null;
			bool debug = false;

			for(int i=0;i<args.Length ; i++)
			{
				if(args[i].Equals("-e")) 
					reader = new StringReader(args[++i]);
				else if (args[i].Equals("-d"))
					debug = true;
				else
					reader = File.OpenText(args[i]);
			}
	
			if(reader == null){
				Console.WriteLine("usage: chimpyland [-d] < -e code | file.cmp >");
				//reader = new StringReader("print(4+5)");
			}
			ChimpyObject value = null;
			Context context = Bootstrapper.Run();
			while(true)
			{
				try
				{
					Console.Write("CHIMPY >> ");
					reader = new StringReader(Console.ReadLine());
					value = context.Eval(reader);
					Console.WriteLine(value.ToJavaObject());
				}
				catch(Exception e)
				{
					Console.WriteLine(e);
					Console.WriteLine(e.StackTrace);
				}
			}
		}
	}
}
