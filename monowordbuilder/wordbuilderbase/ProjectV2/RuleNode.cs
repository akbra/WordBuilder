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


namespace Whee.WordBuilder.ProjectV2
{
    public class RuleNode : ProjectNodeBase
    {

        public RuleNode(IProjectSerializer serializer)
            : base(serializer)
        {
            Token name = serializer.ReadTextToken(this);
            if (name != null)
            {
                Name = name.Text;
                name.Type = TokenType.Name;

                bool found = false;
                double num = 1.0;
                Token amount = serializer.ReadNumericToken(this, ref num, out found);
                if (amount != null)
                {
                    Probability = num;
                }
				else
				{
					Probability = 1.0;
				}

                Children.Add(new CommandBlockNode(serializer));
            }
            else
            {
                m_serializer.Warn("Name expected", new ProblemAreaNode(serializer.Position));
            }
        }

        public string Name
        {
            get;
            set;
        }

        public double Probability
        {
            get;
            set;
        }

        public override ProjectNodeType NodeType
        {
            get
            {
                return ProjectNodeType.RuleDeclaration;
            }
        }

    }
}
