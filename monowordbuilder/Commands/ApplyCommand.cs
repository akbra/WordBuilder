using System.Collections.Generic;

[Highlight(RegEx = "^\\s*apply \\\\\\{", Color = "Green", NextLevel = 4)]
[CloneHighlighting(1, 4)]
[Highlight(RegEx = "\\\\\\}", Color = "Green", Level = 4, NextLevel = -2)]
public class ApplyCommand : CommandBase
{

	private CommandCollection _commands = new CommandCollection();
	public CommandCollection Commands {
		get { return _commands; }
	}

	public override void CheckSanity(Project project)
	{
		foreach (CommandBase cmd in Commands) {
			cmd.CheckSanity(project);
		}
	}

	public override void Execute(Context context)
	{
		List<Context> branchList = new List<Context>();
		branchList.Add(context);

		Stack<IEnumerator<Context>> branchStack = new Stack<IEnumerator<Context>>();
		branchStack.Push(null);

		IEnumerator<Context> branches = context.Branches.Values.GetEnumerator();

		while (branchStack.Count > 0) {
			while (branches.MoveNext()) {
				branchList.Add(branches.Current);

				branchStack.Push(branches);
				branches = branches.Current.Branches.Values.GetEnumerator();
			}

			branches = branchStack.Pop();
		}

		foreach (Context c in branchList) {
			Commands.Execute(c);
		}
	}

	public override void LoadCommand(Project project, System.IO.TextReader reader, string line, ref int lineNumber)
	{
		base.LoadCommand(project, reader, line, ref lineNumber);

		List<string> parts = ProjectSerializer.ReadTokens(line);

		if (parts[0] != "{") {
			project.Warnings.Add(string.Format("Line {0}: The Apply command requires a {{ at the end of the line.", lineNumber));
		}
		else {
			parts.RemoveAt(0);
			parts.RemoveAt(parts.Count - 1);

			if (parts.Count == 0) {
				if (ProjectSerializer.ReadLines(new object[] { project, Commands }, reader, ProjectSerializer.ParseCommands, ref lineNumber)) {
					project.Warnings.Add(string.Format("Line {0}: The Apply command is not closed correctly.", lineNumber));
				}
			}
			else {
				project.Warnings.Add(string.Format("Line {0}: The Apply command must have no arguments.", lineNumber));
			}
		}
	}

	public override void WriteCommand(System.IO.TextWriter writer)
	{
		writer.WriteLine("Apply {");
		Commands.WriteCommands(writer);
		writer.WriteLine("}");
	}
}
