//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NUnit.Framework;
using System;
using NUnit.Mocks;
using Whee.WordBuilder.Project;
using Whee.WordBuilder.Helpers;

namespace test
{
	[TestFixture()]
	public class RuleTest
	{
		[SetUp()]
		public void Setup()
		{
			m_Random = new DynamicMock(typeof(IRandom));
		}

		private DynamicMock m_Random;

		[Test()]
		public void TestGetRuleByName()
		{
			RuleCollection rc = new RuleCollection((IRandom)m_Random.MockInstance);
			
			Rule rule1 = new Rule();
			rule1.Name = "r";
			rule1.Probability = 1.0;
			
			rc.Add(rule1);
			
			m_Random.ExpectAndReturn("NextDouble", 0.0);
			Assert.AreSame(rule1, rc.GetRuleByName("r"));
			
			Rule rule2 = new Rule();
			rule2.Name = "r";
			rule2.Probability = 1.0;
			
			rc.Add(rule2);
			
			m_Random.ExpectAndReturn("NextDouble", 0.2);
			Assert.AreSame(rule1, rc.GetRuleByName("r"), "rule 1 expected");
			m_Random.ExpectAndReturn("NextDouble", 0.6);
			Assert.AreSame(rule2, rc.GetRuleByName("r"), "rule 2 expected");
			
			m_Random.Verify();
		}
	}
}
