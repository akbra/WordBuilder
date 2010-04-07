//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.UIManager UIManager;
    
    private Gtk.Action FileAction;
    
    private Gtk.Action newAction;
    
    private Gtk.Action openAction;
    
    private Gtk.Action saveAction;
    
    private Gtk.Action saveAsAction;
    
    private Gtk.Action quitAction;
    
    private Gtk.Action WordsAction;
    
    private Gtk.Action GenerateAction;
    
    private Gtk.Action ClearAndGenerateAction;
    
    private Gtk.Action ClearAction;
    
    private Gtk.Action CopySelectedAction;
    
    private Gtk.Action CopyDescriptionsAction;
    
    private Gtk.VBox mainVBox;
    
    private Gtk.MenuBar mainMenuBar;
    
    private Gtk.VPaned vpaned2;
    
    private Gtk.HPaned mainHPanes;
    
    private Gtk.ScrolledWindow GtkScrolledWindow1;
    
    private Gtk.TextView codeTextview;
    
    private Gtk.VPaned resultVPanes;
    
    private Gtk.ScrolledWindow GtkScrolledWindow;
    
    private Gtk.TreeView resultsTreeview;
    
    private Gtk.ScrolledWindow GtkScrolledWindow2;
    
    private Gtk.TextView detailsTextview;
    
    private Gtk.ScrolledWindow warningsScrolledWindow;
    
    private Gtk.TreeView warningsTreeView;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.UIManager = new Gtk.UIManager();
        Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
        this.FileAction = new Gtk.Action("FileAction", "File", null, null);
        this.FileAction.ShortLabel = "File";
        w1.Add(this.FileAction, null);
        this.newAction = new Gtk.Action("newAction", "New", null, "gtk-new");
        this.newAction.ShortLabel = "New";
        w1.Add(this.newAction, "<Control>n");
        this.openAction = new Gtk.Action("openAction", "Open...", null, "gtk-open");
        this.openAction.ShortLabel = "Open...";
        w1.Add(this.openAction, "<Control>o");
        this.saveAction = new Gtk.Action("saveAction", "Save", null, "gtk-save");
        this.saveAction.ShortLabel = "Save";
        w1.Add(this.saveAction, "<Control>s");
        this.saveAsAction = new Gtk.Action("saveAsAction", "Save as...", null, "gtk-save-as");
        this.saveAsAction.ShortLabel = "Save as...";
        w1.Add(this.saveAsAction, "<Control><Alt>s");
        this.quitAction = new Gtk.Action("quitAction", "Exit", null, "gtk-quit");
        this.quitAction.ShortLabel = "Exit";
        w1.Add(this.quitAction, null);
        this.WordsAction = new Gtk.Action("WordsAction", "Words", null, null);
        this.WordsAction.ShortLabel = "Words";
        w1.Add(this.WordsAction, null);
        this.GenerateAction = new Gtk.Action("GenerateAction", "Generate", null, null);
        this.GenerateAction.ShortLabel = "Generate";
        w1.Add(this.GenerateAction, "<Control>g");
        this.ClearAndGenerateAction = new Gtk.Action("ClearAndGenerateAction", "Clear and generate", null, null);
        this.ClearAndGenerateAction.ShortLabel = "Clear and generate";
        w1.Add(this.ClearAndGenerateAction, "<Control><Alt>g");
        this.ClearAction = new Gtk.Action("ClearAction", "Clear", null, null);
        this.ClearAction.ShortLabel = "Clear";
        w1.Add(this.ClearAction, "<Control><Alt>l");
        this.CopySelectedAction = new Gtk.Action("CopySelectedAction", "Copy selected", null, null);
        this.CopySelectedAction.ShortLabel = "Copy selected";
        w1.Add(this.CopySelectedAction, "<Control>j");
        this.CopyDescriptionsAction = new Gtk.Action("CopyDescriptionsAction", "Copy descriptions", null, null);
        this.CopyDescriptionsAction.ShortLabel = "Copy descriptions";
        w1.Add(this.CopyDescriptionsAction, "<Control><Alt>j");
        this.UIManager.InsertActionGroup(w1, 0);
        this.AddAccelGroup(this.UIManager.AccelGroup);
        this.Name = "MainWindow";
        this.Title = "WordBuilder";
        this.Icon = Stetic.IconLoader.LoadIcon(this, "gtk-sort-ascending", Gtk.IconSize.Menu, 16);
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.mainVBox = new Gtk.VBox();
        this.mainVBox.Name = "mainVBox";
        this.mainVBox.Spacing = 6;
        // Container child mainVBox.Gtk.Box+BoxChild
        this.UIManager.AddUiFromString(@"<ui><menubar name='mainMenuBar'><menu name='FileAction' action='FileAction'><menuitem name='newAction' action='newAction'/><menuitem name='openAction' action='openAction'/><separator/><menuitem name='saveAction' action='saveAction'/><menuitem name='saveAsAction' action='saveAsAction'/><separator/><menuitem name='quitAction' action='quitAction'/></menu><menu name='WordsAction' action='WordsAction'><menuitem name='GenerateAction' action='GenerateAction'/><menuitem name='ClearAndGenerateAction' action='ClearAndGenerateAction'/><menuitem name='ClearAction' action='ClearAction'/><separator/><menuitem name='CopySelectedAction' action='CopySelectedAction'/><menuitem name='CopyDescriptionsAction' action='CopyDescriptionsAction'/></menu></menubar></ui>");
        this.mainMenuBar = ((Gtk.MenuBar)(this.UIManager.GetWidget("/mainMenuBar")));
        this.mainMenuBar.Name = "mainMenuBar";
        this.mainVBox.Add(this.mainMenuBar);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.mainVBox[this.mainMenuBar]));
        w2.Position = 0;
        w2.Expand = false;
        w2.Fill = false;
        // Container child mainVBox.Gtk.Box+BoxChild
        this.vpaned2 = new Gtk.VPaned();
        this.vpaned2.CanFocus = true;
        this.vpaned2.Name = "vpaned2";
        this.vpaned2.Position = 199;
        // Container child vpaned2.Gtk.Paned+PanedChild
        this.mainHPanes = new Gtk.HPaned();
        this.mainHPanes.CanFocus = true;
        this.mainHPanes.Name = "mainHPanes";
        this.mainHPanes.Position = 190;
        // Container child mainHPanes.Gtk.Paned+PanedChild
        this.GtkScrolledWindow1 = new Gtk.ScrolledWindow();
        this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
        this.GtkScrolledWindow1.ShadowType = ((Gtk.ShadowType)(1));
        // Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
        this.codeTextview = new Gtk.TextView();
        this.codeTextview.CanFocus = true;
        this.codeTextview.Name = "codeTextview";
        this.GtkScrolledWindow1.Add(this.codeTextview);
        this.mainHPanes.Add(this.GtkScrolledWindow1);
        Gtk.Paned.PanedChild w4 = ((Gtk.Paned.PanedChild)(this.mainHPanes[this.GtkScrolledWindow1]));
        w4.Resize = false;
        // Container child mainHPanes.Gtk.Paned+PanedChild
        this.resultVPanes = new Gtk.VPaned();
        this.resultVPanes.CanFocus = true;
        this.resultVPanes.Name = "resultVPanes";
        this.resultVPanes.Position = 127;
        // Container child resultVPanes.Gtk.Paned+PanedChild
        this.GtkScrolledWindow = new Gtk.ScrolledWindow();
        this.GtkScrolledWindow.Name = "GtkScrolledWindow";
        this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
        // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
        this.resultsTreeview = new Gtk.TreeView();
        this.resultsTreeview.CanFocus = true;
        this.resultsTreeview.Name = "resultsTreeview";
        this.GtkScrolledWindow.Add(this.resultsTreeview);
        this.resultVPanes.Add(this.GtkScrolledWindow);
        Gtk.Paned.PanedChild w6 = ((Gtk.Paned.PanedChild)(this.resultVPanes[this.GtkScrolledWindow]));
        w6.Resize = false;
        // Container child resultVPanes.Gtk.Paned+PanedChild
        this.GtkScrolledWindow2 = new Gtk.ScrolledWindow();
        this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
        this.GtkScrolledWindow2.ShadowType = ((Gtk.ShadowType)(1));
        // Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
        this.detailsTextview = new Gtk.TextView();
        this.detailsTextview.CanFocus = true;
        this.detailsTextview.Name = "detailsTextview";
        this.detailsTextview.Editable = false;
        this.detailsTextview.AcceptsTab = false;
        this.GtkScrolledWindow2.Add(this.detailsTextview);
        this.resultVPanes.Add(this.GtkScrolledWindow2);
        this.mainHPanes.Add(this.resultVPanes);
        this.vpaned2.Add(this.mainHPanes);
        Gtk.Paned.PanedChild w10 = ((Gtk.Paned.PanedChild)(this.vpaned2[this.mainHPanes]));
        w10.Resize = false;
        // Container child vpaned2.Gtk.Paned+PanedChild
        this.warningsScrolledWindow = new Gtk.ScrolledWindow();
        this.warningsScrolledWindow.Name = "warningsScrolledWindow";
        this.warningsScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
        // Container child warningsScrolledWindow.Gtk.Container+ContainerChild
        this.warningsTreeView = new Gtk.TreeView();
        this.warningsTreeView.CanFocus = true;
        this.warningsTreeView.Name = "warningsTreeView";
        this.warningsScrolledWindow.Add(this.warningsTreeView);
        this.vpaned2.Add(this.warningsScrolledWindow);
        this.mainVBox.Add(this.vpaned2);
        Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.mainVBox[this.vpaned2]));
        w13.Position = 1;
        this.Add(this.mainVBox);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 538;
        this.DefaultHeight = 411;
        this.warningsScrolledWindow.Hide();
        this.Show();
        this.newAction.Activated += new System.EventHandler(this.OnNewActionActivated);
        this.openAction.Activated += new System.EventHandler(this.OnOpenActionActivated);
        this.saveAction.Activated += new System.EventHandler(this.OnSaveActionActivated);
        this.saveAsAction.Activated += new System.EventHandler(this.OnSaveAsActionActivated);
        this.quitAction.Activated += new System.EventHandler(this.OnQuitActionActivated);
        this.GenerateAction.Activated += new System.EventHandler(this.OnGenerateActionActivated);
        this.ClearAndGenerateAction.Activated += new System.EventHandler(this.OnClearAndGenerateActionActivated);
        this.ClearAction.Activated += new System.EventHandler(this.OnClearActionActivated);
        this.CopySelectedAction.Activated += new System.EventHandler(this.OnCopySelectedActionActivated);
        this.CopyDescriptionsAction.Activated += new System.EventHandler(this.OnCopyDescriptionsActionActivated);
    }
}
