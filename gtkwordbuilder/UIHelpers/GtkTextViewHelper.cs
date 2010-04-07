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
using Whee.WordBuilder.UIHelpers;
using Gtk;

namespace Whee.WordBuilder.UIHelpers
{


	public class GtkTextViewHelper : ITextViewHelper
	{
		public GtkTextViewHelper (TextView textView)
		{
			m_textView = textView;
			m_textView.Buffer.Changed += HandleM_textViewBufferChanged;
		}

		void HandleM_textViewBufferChanged (object sender, EventArgs e)
		{
			if (BufferChanged != null)
			{
				BufferChanged.Invoke(sender, new Whee.WordBuilder.Model.Events.DocumentChangedEventArgs(m_textView.Buffer.Text));
			}
		}
		
		private TextView m_textView;
		
		public void Clear() 
		{
			m_textView.Buffer.Clear();
		}
		
		public void OnDocumentChanged(object sender, string newText)
		{
			m_textView.Buffer.Text = newText;
		}

		public void GotoLine (int linenumber)
		{
			TextIter iter = m_textView.Buffer.GetIterAtLine(linenumber);
			m_textView.Buffer.PlaceCursor(iter);
			m_textView.PlaceCursorOnscreen();
			m_textView.GrabFocus();
		}
		
		public event EventHandler<Whee.WordBuilder.Model.Events.DocumentChangedEventArgs> BufferChanged;		
	}
}
