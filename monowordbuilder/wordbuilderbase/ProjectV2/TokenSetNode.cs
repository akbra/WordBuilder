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


namespace Whee.WordBuilder.ProjectV2
{
	public class TokenSetNode : ProjectNodeBase
	{
		public TokenSetNode (IProjectSerializer serializer) : base(serializer)
		{
			LoadParameters();
		}
		
		public override ProjectNodeType NodeType {
			get {
				return ProjectNodeType.TokenSetDeclaration;
			}
		}
		
		private string m_Name;
		public string Name { get { return m_Name; } }
		
		private List<string> m_Tokens =new List<string>();
		public List<string> Tokens { get { return m_Tokens; } }
		
		private void LoadParameters()
		{
			Token name = m_serializer.ReadTextToken(this);
			if (name != null)
			{
                name.Type = TokenType.Name;
				m_Name = name.Text;
			}

            Token lb = m_serializer.ReadLineBreakToken(this);
			while (lb == null)
			{
                Token tok = m_serializer.ReadTextToken(this);
                m_Tokens.Add(tok.Text);
                lb = m_serializer.ReadLineBreakToken(this);
			}
		}
	}
}
