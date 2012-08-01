using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HomePLC.Model;
using FastColoredTextBoxNS;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace HomePLC.Forms
{
    public partial class EditScriptForm : BaseForm
    {
        private Script fScript;
        private static HomePLC.Model.Module fModule = new HomePLC.Model.Module(BoardType.Analog,6,BoardType.Digital,8);

        #region AutocompleteMenu
        AutocompleteMenu popupMenu;
        string[] keywords = { "module", "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "descending", "dynamic", "from", "get", "global", "group", "into", "join", "let", "orderby", "partial", "remove", "select", "set", "value", "var", "where", "yield" };
        string[] snippets = { "if(^)\n{\n;\n}", "if(^)\n{\n;\n}\nelse\n{\n;\n}", "for(^;;)${\n;\n}", "while(^)\n{\n;\n}", "do${\n^;\n}while();", "switch(^)\n{\ncase : break;\n}" };
        string[] declarationSnippets = { 
               "public class ^\n{\n}", "private class ^\n{\n}", "internal class ^\n{\n}",
               "public struct ^\n{\n;\n}", "private struct ^\n{\n;\n}", "internal struct ^\n{\n;\n}",
               "public void ^()\n{\n;\n}", "private void ^()\n{\n;\n}", "internal void ^()\n{\n;\n}", "protected void ^()\n{\n;\n}",
               "public ^{ get; set; }", "private ^{ get; set; }", "internal ^{ get; set; }", "protected ^{ get; set; }"
               };
        string[] property = null;

        class DeclarationSnippet : SnippetAutocompleteItem
        {
            public DeclarationSnippet(string snippet)
                : base(snippet)
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                var pattern = Regex.Replace(fragmentText, FastColoredTextBoxNS.FindForm.RegexSpecSymbolsPattern, "\\$0");
                if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
                    return CompareResult.Visible;
                return CompareResult.Hidden;
            }
        }
        class InsertSpaceSnippet : AutocompleteItem
        {
            string pattern;

            public InsertSpaceSnippet(string pattern)
                : base("")
            {
                this.pattern = pattern;
            }

            public InsertSpaceSnippet()
                : this(@"^(\d*)([a-zA-Z_]+)(\d*)$")
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                if (Regex.IsMatch(fragmentText, pattern))
                {
                    Text = InsertSpaces(fragmentText);
                    if (Text != fragmentText)
                        return CompareResult.Visible;
                }
                return CompareResult.Hidden;
            }

            public string InsertSpaces(string fragment)
            {
                var m = Regex.Match(fragment, pattern);
                if (m == null)
                    return fragment;
                if (m.Groups[1].Value == "" && m.Groups[3].Value == "")
                    return fragment;
                return (m.Groups[1].Value + " " + m.Groups[2].Value + " " + m.Groups[3].Value).Trim();
            }

            public override string ToolTipTitle
            {
                get
                {
                    return Text;
                }
            }
        }
        class InsertEnterSnippet : AutocompleteItem
        {
            Place enterPlace = Place.Empty;

            public InsertEnterSnippet()
                : base("[Line break]")
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                var r = Parent.Fragment.Clone();
                while (r.Start.iChar > 0)
                {
                    if (r.CharBeforeStart == '}')
                    {
                        enterPlace = r.Start;
                        return CompareResult.Visible;
                    }

                    r.GoLeftThroughFolded();
                }

                return CompareResult.Hidden;
            }

            public override string GetTextForReplace()
            {
                //extend range
                Range r = Parent.Fragment;
                Place end = r.End;
                r.Start = enterPlace;
                r.End = r.End;
                //insert line break
                return Environment.NewLine + r.Text;
            }

            public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
            {
                base.OnSelected(popupMenu, e);
                if (Parent.Fragment.tb.AutoIndent)
                    Parent.Fragment.tb.DoAutoIndent();
            }

            public override string ToolTipTitle
            {
                get
                {
                    return "Insert line break after '}'";
                }
            }
        }

        private void BuildAutocompleteMenu()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();

            foreach (var item in snippets)
                items.Add(new SnippetAutocompleteItem(item) { ImageIndex = 1 });
            foreach (var item in declarationSnippets)
                items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });
            foreach (var item in keywords)
                items.Add(new AutocompleteItem(item));
            foreach (var item in property)
            {
                items.Add(new MethodAutocompleteItem(item) { ImageIndex = 2 });
            }
            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            //set as autocomplete source
            popupMenu.Items.SetAutocompleteItems(items);

        }
        #endregion

        private void GetModulePublicMembers()
        {
            PropertyInfo[] pinfo = fModule.GetType().GetProperties();
            FieldInfo[] finfo = fModule.GetType().GetFields();
            
            List<string> mdlProperties = new List<string>();

            foreach (var item in finfo)
            {
                mdlProperties.Add(item.Name);
            }

            foreach (var item in pinfo)
            {
                mdlProperties.Add(item.Name);
            }
            mdlProperties.Sort();

            for (int i = 0; i < mdlProperties.Count; i++)
            {
                property = mdlProperties.ToArray();
            }

        }
        public EditScriptForm(Script script)
        {
            InitializeComponent();
            GetModulePublicMembers();

            fScript = script;
            scriptBS.DataSource = fScript;

            //create autocomplete popup menu
            popupMenu = new AutocompleteMenu(fastColoredTextBox1); ;
            popupMenu.SearchPattern = @"[\w\.:=!<>]";

            BuildAutocompleteMenu();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            fScript.Source = fastColoredTextBox1.Text;
            fModule.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            (fScript as IEditableObject).CancelEdit();
            fModule.Dispose();
        }
    }
}
