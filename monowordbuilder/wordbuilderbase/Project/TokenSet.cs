using System;
using System.Collections.Generic;
using Whee.WordBuilder.Helpers;

namespace Whee.WordBuilder.Project
{
	public class TokenSet
	{
		public TokenSet(IRandom random)
		{
			m_Random = random;
		}
		
		private IRandom m_Random;
	    
		public string Name { get; set; }
	    
		private List<String> _Tokens = new List<string>();
		public List<String> Tokens {
			get { return _Tokens; }
		}
	    
		public string GetToken()
		{
			return Tokens[m_Random.Next(Tokens.Count)];
		}
	}
}