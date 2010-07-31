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
using System.Text;
using Whee.WordBuilder.Helpers;
using Whee.WordBuilder.Model.Commands;
using Whee.WordBuilder.UIHelpers;

namespace Whee.WordBuilder.ProjectV2
{
    public class ProjectSerializer : IProjectSerializer
    {
        public ProjectSerializer(string source, IRandom random, IWarningViewHelper warningViewHelper)
        {
            SpacesIndent = 2;
            m_source = source;
            if (random == null)
            {
                Random = Whee.WordBuilder.Helpers.Random.Instance;
            }
            else
            {
                Random = random;
            }
            WarningViewHelper = warningViewHelper;
        }

        public IRandom Random { get; private set; }
        public IWarningViewHelper WarningViewHelper { get; private set; }

        int m_lineNumber = 1;
        int m_lastIndentationLevel = 0;
        int m_currentIndentationLevel = 0;
        int m_Offset = 0;
        string m_source;

        public int LastIndentationLevel { get { return m_lastIndentationLevel; } }
        public int CurrentIndentationLevel { get { return m_currentIndentationLevel; } }
        public int Position { get { return m_Offset; } }

        public int SpacesIndent { get; set; }

        private const string WhiteSpace = " \t";
        private const string LineBreakers = "\r\n;";
        private const string Numeric = "0123456789";

        public int GetIndentationLevel(string indentation)
        {
            return indentation.Replace(new string(' ', SpacesIndent), "\t").Replace(" ", "").Length;
        }

        private int Peek()
        {
            if (m_Offset >= m_source.Length) return -1;
            return (int)m_source[m_Offset];
        }

        private int SkipAndPeek()
        {
            m_Offset++;
            return Peek();
        }

        private int ReadCharacterSet(StringBuilder token, string chars)
        {
            int nextChar = Peek();
            int start = m_Offset;

            while (nextChar > -1 && chars.IndexOf((char)nextChar) > -1)
            {
                if (token != null)
                {
                    token.Append((char)nextChar);
                }
                nextChar = SkipAndPeek();
            }

            return m_Offset - start;
        }

        public int ReadWhiteSpace(StringBuilder token)
        {
            return ReadCharacterSet(token, WhiteSpace);
        }

        public int ReadLineBreaks(StringBuilder token)
        {
            int len = ReadCharacterSet(token, LineBreakers);

            m_lineNumber += token.ToString().Replace("\r\n", "!").Replace(";", "").Length;

            return len;
        }

        public int ReadNumeric(StringBuilder token)
        {
            int len = ReadCharacterSet(token, Numeric);
            ReadWhiteSpace(null);
            return len;
        }

        public int ReadText(StringBuilder token)
        {
            int nextChar = Peek();
            int start = m_Offset;

            bool quote = false;
            bool escape = false;

            if (nextChar == '"')
            {
                quote = true;
                nextChar = SkipAndPeek();
            }

            while (nextChar > -1 &&
                   (quote || (WhiteSpace.IndexOf((char)nextChar) == -1 &&
                   LineBreakers.IndexOf((char)nextChar) == -1)) &&
                   (!quote || escape || nextChar != '"'))
            {
                if (!escape && nextChar == '\\')
                {
                    escape = true;
                }
                else
                {
                    if (token != null)
                    {
                        token.Append((char)nextChar);
                    }
                    escape = false;
                }

                nextChar = SkipAndPeek();
            }

            if (quote && nextChar == '"')
            {
                nextChar = SkipAndPeek();
            }

            int len = m_Offset - start;

            ReadWhiteSpace(null);

            return len;
        }

        private void CheckForComments(IProjectNode node)
        {
            if (m_source.Length > m_Offset + 1 && m_source.Substring(m_Offset, 2) == "/*")
            {
                int start = m_Offset;

                m_Offset = m_source.IndexOf("*/", m_Offset + 2);
                if (m_Offset == -1)
                {
                    m_Offset = m_source.Length;
                }
                else
                {
                    m_Offset += 2;
                }

                CreateToken(node, TokenType.Comment, "", start, m_Offset - start);

                ReadWhiteSpace(null);
            }
            else if (m_source.Length > m_Offset + 1 && m_source.Substring(m_Offset, 2) == "//")
            {
                int start = m_Offset;

                m_Offset = m_source.IndexOfAny(new char[] {'\r', '\n'}, m_Offset);
                if (m_Offset == -1)
                {
                    m_Offset = m_source.Length;
                }

                CreateToken(node, TokenType.Comment, "", start, m_Offset - start);
            }
        }

        public Token ReadTextToken(IProjectNode node)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            StringBuilder sb = new StringBuilder();
            int start = m_Offset;
            int len = ReadText(sb);

            if (len > 0)
            {
                return CreateToken(node, TokenType.Text, sb.ToString(), start, len);
            }

            return null;
        }

        public Token ReadNumericToken(IProjectNode node, ref double value, out bool found)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            found = false;
            StringBuilder sb = new StringBuilder();
            int start = m_Offset;
            int len = ReadText(sb);

            if (len > 0)
            {
                found = true;
                if (double.TryParse(sb.ToString(), out value))
                {
                    return CreateToken(node, TokenType.Number, sb.ToString(), start, len);
                }
                else
                {
                    m_Offset = start;
                }
            }

            return null;
        }

        public Token ReadIndentationToken(IProjectNode node)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            StringBuilder sb = new StringBuilder();
            int start = m_Offset;
            int len = ReadWhiteSpace(sb);

            if (len > 0)
            {
                m_lastIndentationLevel = m_currentIndentationLevel;
                m_currentIndentationLevel = GetIndentationLevel(sb.ToString());
                return CreateToken(node, TokenType.Indentation, sb.ToString(), start, len);
            }

            m_lastIndentationLevel = m_currentIndentationLevel;
            m_currentIndentationLevel = 0;
            return null;
        }

        public Token ReadLineBreakToken(IProjectNode node)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            StringBuilder sb = new StringBuilder();
            int start = m_Offset;
            int len = ReadLineBreaks(sb);

            if (len > 0)
            {
                return CreateToken(node, TokenType.LineBreak, sb.ToString(), start, len);
            }

            if (Peek() == -1)
            {
                return CreateToken(node, TokenType.LineBreak, "", start, 0);
            }

            return null;
        }

        public Token ReadBlockStarterToken(IProjectNode node)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            int nextChar = Peek();

            if (nextChar != '{')
            {
                return null;
            }

            int start = m_Offset;
            SkipAndPeek();

            return CreateToken(node, TokenType.BlockStarter, "{", start, 1);
        }

        public Token ReadBlockEnderToken(IProjectNode node)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            int nextChar = Peek();

            if (nextChar != '}')
            {
                return null;
            }

            int start = m_Offset;
            SkipAndPeek();

            return CreateToken(node, TokenType.BlockEnder, "}", start, 1);
        }

        private int ReadSquaredBlock(StringBuilder sb, StringBuilder datasb)
        {
            int start = m_Offset;
            int nextChar = Peek();

            if (nextChar == '[')
            {
                sb.Append("[");

                bool success = false;
                while (nextChar > -1)
                {
                    nextChar = SkipAndPeek();

                    sb.Append((char)nextChar);

                    if (nextChar == ']')
                    {
                        success = true;
                        nextChar = SkipAndPeek();
                        break;
                    }

                    datasb.Append((char)nextChar);
                }

                if (success)
                {
                    ReadWhiteSpace(null);

                    return sb.Length;
                }
                else
                {
                    Warn("Expected ] to end repeating token", m_warningsToNode);
				}
            }
            else
            {
                m_Offset = start;
            }

            return 0;
        }

        public Token ReadSquaredBlockToken(IProjectNode node)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            StringBuilder sb = new StringBuilder();
            StringBuilder datasb = new StringBuilder();

            int start = m_Offset;
            int len = ReadSquaredBlock(sb, datasb);

            if (len > 0)
            {
                return CreateToken(node, TokenType.Text, sb.ToString(), start, sb.Length);
            }

            return null;
        }

        public Token ReadRepeatingToken(IProjectNode node, out int repetitions, out string data)
        {
			m_warningsToNode = node;
            CheckForComments(node);
            StringBuilder sb = new StringBuilder();
            StringBuilder datasb = new StringBuilder();
            int start = m_Offset;
            int len = ReadNumeric(sb);

            if (len > 0)
            {
                int.TryParse(sb.ToString(), out repetitions);

                len = ReadSquaredBlock(sb, datasb);

                if (len > 0)
                {
                    data = datasb.ToString();

                    return CreateToken(node, TokenType.Repeater, sb.ToString(), start, sb.Length);
                }
                else
                {
                    m_Offset = start;
                }
            }

            repetitions = 0;
            data = "";
            return null;
        }

        public void RollBackToken(Token token)
        {
            m_Offset = token.Offset;
            m_Tokens.Remove(token);
        }

        public static IProjectNode LoadString(string script, IRandom random, IWarningViewHelper warningViewHelper)
        {
            ProjectSerializer serializer = new ProjectSerializer(script, random, warningViewHelper);
            return new ProjectNode(serializer);
        }

        public bool Done { get { return Peek() == -1; } }

        private List<Token> m_Tokens = new List<Token>();
        public List<Token> Tokens
        {
            get
            {
                return m_Tokens;
            }
        }

        private Token CreateToken(IProjectNode node, TokenType type, string text, int offset, int length)
        {
            Token t = new Token(node, type, text, offset, length, m_lineNumber);
            m_Tokens.Add(t);
            return t;
        }

		public void Warn(string message, IProjectNode node)
		{
            if (WarningViewHelper != null)
            {
                if (m_lineNumber > 0)
                {
                    WarningViewHelper.AddWarning(node, string.Format("Line {0}: {1}", m_lineNumber, message));
                }
                else
                {
                    WarningViewHelper.AddWarning(node, message);
                }
            }
		}

        public int LineNumber
        {
            get { return m_lineNumber; }
        }
		
		private IProjectNode m_warningsToNode;
    }
}
