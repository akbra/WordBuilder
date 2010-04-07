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
using NUnit.Mocks;
using System;
using System.Collections.Generic;

using Whee.WordBuilder.Controller;
using Whee.WordBuilder.Helpers;
using Whee.WordBuilder.UIHelpers;
using Whee.WordBuilder.Model;
using Whee.WordBuilder.Model.Commands;

namespace test
{


	[TestFixture()]
	public class GeneratorControllerTest
	{
		[SetUp()]
		public void Setup()
		{
			m_ClipBoardHelper = new DynamicMock(typeof(IClipBoardHelper));
			m_ResultViewHelper = new DynamicMock(typeof(IResultViewHelper));
			m_DetailsTextViewHelper = new DynamicMock(typeof(ITextViewHelper));
			m_GeneratorController = new GeneratorController((IResultViewHelper)m_ResultViewHelper.MockInstance, (IClipBoardHelper)m_ClipBoardHelper.MockInstance, (ITextViewHelper)m_DetailsTextViewHelper.MockInstance);			
		}
		
		private DynamicMock m_DetailsTextViewHelper;
		private DynamicMock m_ResultViewHelper;
		private DynamicMock m_ClipBoardHelper;
		private GeneratorController m_GeneratorController;

		[Test()]
		public void TestClear()
		{
			m_ResultViewHelper.Expect("Clear");
			m_GeneratorController.Clear();
			m_ResultViewHelper.Verify();
		}
		
		[Test()]
		public void TestGenerateNoStartingRules()
		{
			for (int i = 0; i < 100; i++) {
				m_ResultViewHelper.Expect("AddItem");				
			}
			
			DynamicMock random = new DynamicMock(typeof(IRandom));
			Project project = new Project((IRandom)random.MockInstance);
			
			Rule rule = new Rule();
			
			rule.Name = "root";
			rule.Probability = 1.0;
			rule.LineNumber = 1;
			
			LiteralCommand a = new LiteralCommand();
			a.Literal = "a";
			rule.Commands.Add(a);
			                  
			project.Rules.Add(rule);
			
			m_GeneratorController.Generate(project);

			Assert.AreEqual(1, project.StartRules.Count);
			m_ResultViewHelper.Verify();
		}

		[Test()]
		public void TestGenerateOneStartingRule()
		{
			for (int i = 0; i < 10; i++) {
				m_ResultViewHelper.Expect("AddItem");				
			}
			
			DynamicMock random = new DynamicMock(typeof(IRandom));
			Project project = new Project((IRandom)random.MockInstance);
			
			Rule rule = new Rule();
			
			rule.Name = "test";
			rule.Probability = 1.0;
			rule.LineNumber = 1;
			
			LiteralCommand a = new LiteralCommand();
			a.Literal = "a";
			rule.Commands.Add(a);
			                  
			project.Rules.Add(rule);
			
			project.StartRules.Add("test", 10);
			
			m_GeneratorController.Generate(project);

			Assert.AreEqual(1, project.StartRules.Count);
			m_ResultViewHelper.Verify();
		}

		[Test()]
		public void TestGenerateTwoStartingRules()
		{
			for (int i = 0; i < 10; i++) {
				m_ResultViewHelper.Expect("AddItem");				
			}
			
			DynamicMock random = new DynamicMock(typeof(IRandom));
			Project project = new Project((IRandom)random.MockInstance);
			
			Rule rule = new Rule();
			
			rule.Name = "test";
			rule.Probability = 1.0;
			rule.LineNumber = 1;
			
			LiteralCommand a = new LiteralCommand();
			a.Literal = "a";
			rule.Commands.Add(a);

			Rule rule2 = new Rule();
			
			rule2.Name = "test2";
			rule2.Probability = 1.0;
			rule2.LineNumber = 1;
			
			LiteralCommand b= new LiteralCommand();
			b.Literal = "b";
			rule2.Commands.Add(b);

			project.Rules.Add(rule);
			project.Rules.Add(rule2);
			
			project.StartRules.Add("test", 5);
			project.StartRules.Add("test2", 5);
			
			m_GeneratorController.Generate(project);

			Assert.AreEqual(2, project.StartRules.Count);
			m_ResultViewHelper.Verify();
		}
		
		[Test()]
		public void TestCopy()
		{
			List<Context> selected = new List<Context>();
			
			Context result = new Context();
			result.Tokens.Add("a");
			result.Tokens.Add("b");
			result.Tokens.Add("c");
			selected.Add(result);
			m_ResultViewHelper.ExpectAndReturn("GetSelectedItems", selected);

			m_ClipBoardHelper.Expect("Copy", "abc");
			m_GeneratorController.Copy();
			
			m_ResultViewHelper.Verify();
			m_ClipBoardHelper.Verify();
		}
		
		[Test()]
		public void TestCopyAdvanced()
		{
			List<Context> selected = new List<Context>();
			
			Context result = new Context();
			result.Tokens.Add("a");
			result.Tokens.Add("b");
			result.Tokens.Add("c");
			
			Context branch = result.Branch("b1");
			branch.Tokens.Add("d");
			
			selected.Add(result);
			m_ResultViewHelper.ExpectAndReturn("GetSelectedItems", selected);

			m_ClipBoardHelper.Expect("Copy", "abc\r\n\tb1: abcd");
			m_GeneratorController.CopyDescription();
			
			m_ResultViewHelper.Verify();
			m_ClipBoardHelper.Verify();
		}

		[Test()]
		public void TestDetailsView()
		{
			List<Context> selected = new List<Context>();
			
			Context result = new Context();
			result.Tokens.Add("a");
			result.Tokens.Add("b");
			result.Tokens.Add("c");
			
			Context branch = result.Branch("b1");
			branch.Tokens.Add("d");
			
			selected.Add(result);

			m_DetailsTextViewHelper.Expect("OnDocumentChanged", m_GeneratorController, "abc\r\n\tb1: abcd");

			m_GeneratorController.OnTreeViewSelectionChanged(selected);
			
			m_DetailsTextViewHelper.Verify();
		}
		
		[Test()]
		public void TestGenerateNullProject()
		{			
			m_GeneratorController.Generate(null);
		}
	}
}
