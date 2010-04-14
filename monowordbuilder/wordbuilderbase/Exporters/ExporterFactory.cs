//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Whee.WordBuilder.Exporters
{


	public sealed class ExporterFactory
	{
		private ExporterFactory ()
		{
		}

		private static Dictionary<string, IExporter> s_exporters;
		private static Dictionary<string, IExporter> Exporters
		{
			get 
			{
				if (s_exporters == null)
				{
					s_exporters = new Dictionary<string, IExporter>();
					
					foreach (Type t in Assembly.GetAssembly(typeof(ExporterFactory)).GetTypes()) 
					{
						if (typeof(IExporter).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface) 
						{
							IExporter ex = (IExporter)Activator.CreateInstance(t);
							s_exporters.Add(ex.Name, ex);
						}
					}				
				}
				
				return s_exporters;
			}
		}

		public static List<string> GetExporterNames()
		{
			return new List<string>(Exporters.Keys);
		}
		
		public static IExporter GetExporter(string name)
		{
			return Exporters[name];
		}
	}
}
