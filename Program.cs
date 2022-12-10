using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			Application.Run(new MainForm());
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
		{
			if (e.Name.StartsWith("Mechvibes.CSharp.resources"))
				return e.RequestingAssembly;

			using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Mechvibes.CSharp.Libraries.{e.Name.Split(',')[0]}.dll"))
			{
				byte[] dll = new byte[s.Length];
				s.Read(dll, 0, dll.Length);

				return Assembly.Load(dll);
			}
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Application.Restart();
		}
	}
}
