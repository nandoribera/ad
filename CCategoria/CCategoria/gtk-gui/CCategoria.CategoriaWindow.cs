
// This file has been generated by the GUI designer. Do not modify.
namespace CCategoria
{
	public partial class CategoriaWindow
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action saveAction;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Table table3;

		private global::Gtk.Entry entryNombre;

		private global::Gtk.Label label2;

		private global::Gtk.HButtonBox hbuttonbox5;

		private global::Gtk.Button buttonSave;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget CCategoria.CategoriaWindow
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
			this.saveAction = new global::Gtk.Action("saveAction", null, null, "gtk-save");
			w1.Add(this.saveAction, null);
			this.UIManager.InsertActionGroup(w1, 0);
			this.AddAccelGroup(this.UIManager.AccelGroup);
			this.Name = "CCategoria.CategoriaWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("CategoriaWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child CCategoria.CategoriaWindow.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.table3 = new global::Gtk.Table(((uint)(1)), ((uint)(2)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.entryNombre = new global::Gtk.Entry();
			this.entryNombre.CanFocus = true;
			this.entryNombre.Name = "entryNombre";
			this.entryNombre.IsEditable = true;
			this.entryNombre.InvisibleChar = '•';
			this.table3.Add(this.entryNombre);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table3[this.entryNombre]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Nombre");
			this.table3.Add(this.label2);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table3[this.label2]));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox4.Add(this.table3);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.table3]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbuttonbox5 = new global::Gtk.HButtonBox();
			this.hbuttonbox5.Name = "hbuttonbox5";
			this.hbuttonbox5.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child hbuttonbox5.Gtk.ButtonBox+ButtonBoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseStock = true;
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = "gtk-save";
			this.hbuttonbox5.Add(this.buttonSave);
			global::Gtk.ButtonBox.ButtonBoxChild w5 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox5[this.buttonSave]));
			w5.Expand = false;
			w5.Fill = false;
			this.vbox4.Add(this.hbuttonbox5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbuttonbox5]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.Add(this.vbox4);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 358;
			this.DefaultHeight = 62;
			this.Show();
		}
	}
}
