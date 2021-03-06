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


namespace Whee.WordBuilder.UIHelpers
{


	public class FileDialogHelper : IFileDialogHelper
	{
		public FileDialogHelper ()
		{
		}

		#region IFileDialogHelper implementation
		public SaveCheckDialogResult ShowSaveCheckDialog ()
		{
			Gtk.MessageDialog saveCheckDialog = new Gtk.MessageDialog(null, Gtk.DialogFlags.Modal, Gtk.MessageType.Question, Gtk.ButtonsType.YesNo, false, "The current document has unsaved changes. Do you wish to save those now?");
			saveCheckDialog.AddButton("Cancel", Gtk.ResponseType.Cancel);

			SaveCheckDialogResult result = SaveCheckDialogResult.Cancel;
			
			int dialogResult = saveCheckDialog.Run();
			if ((int)Gtk.ResponseType.Yes == dialogResult)
			{
				result = SaveCheckDialogResult.Save;
			}
			else if ((int)Gtk.ResponseType.No == dialogResult)
			{
				result = SaveCheckDialogResult.NoSave;
			}
			
			saveCheckDialog.Destroy();
			
			return result;
		}
		
		public string ShowSaveDialog ()
		{
			string result = null;
			Gtk.FileChooserDialog saveDialog = new Gtk.FileChooserDialog("Save as", null, Gtk.FileChooserAction.Save, "Cancel", Gtk.ResponseType.Cancel, "Save", Gtk.ResponseType.Accept);
			
			if (saveDialog.Run() == (int)Gtk.ResponseType.Accept)
			{
				result = saveDialog.Filename;
			}
			
			saveDialog.Destroy();
			return result;
		}
		
		public string ShowOpenDialog()
		{
			string result = null;
			Gtk.FileChooserDialog openDialog = new Gtk.FileChooserDialog("Open", null, Gtk.FileChooserAction.Open, "Cancel", Gtk.ResponseType.Cancel, "Open", Gtk.ResponseType.Accept);
			
			if (openDialog.Run() == (int)Gtk.ResponseType.Accept)
			{
				result = openDialog.Filename;
			}
			
			openDialog.Destroy();
			return result;
		}
		
		#endregion
	}
}
