using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Xml;
using System.ComponentModel;
using HomePLC.Model;

namespace HomePLC.Model
{
    public class Script : INotifyPropertyChanged, IEditableObject
    {
        private Guid fieldID;
        private string fieldName;
        private string fieldSource;
        private bool fieldEnabled;

        private string tempName;
        private string tempSource;

        private Assembly compiled;

        public Script(string Name)
        {
            fieldID = Guid.NewGuid();

            fieldName = Name;
            fieldSource = @"using System;
using HomePLC.Model;
public class Script : HomePLC.Model.IScript
{
    public void Execute(HomePLC.Model.Module module)
    {
        
    }
}";
            compiled = null;
        }

        public Script(Guid ID, XmlElement xe)
        {
            fieldID = ID;
            fieldEnabled = xe.Attributes["enabled"].Value == "True";
            foreach (XmlNode node in xe.ChildNodes)
            {
                string name = node.Name;
                string value = node.InnerText;

                if (name == "Name")
                {
                    fieldName = value;
                }
                else if (name == "Source")
                {
                    fieldSource = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(value));
                }
            }
        }

        public void Save(XmlElement xe)
        {
            XmlNode namenode = xe.OwnerDocument.CreateElement("Name");

            namenode.InnerText = fieldName;

            xe.AppendChild(namenode);

            XmlNode sourcenode = xe.OwnerDocument.CreateElement("Source");

            sourcenode.InnerText = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(fieldSource));
            xe.AppendChild(sourcenode);

            XmlAttribute enablednode = xe.OwnerDocument.CreateAttribute("enabled");

            enablednode.Value = fieldEnabled.ToString();

            xe.Attributes.Append(enablednode);
        }

        public Guid ID
        {
            get
            {
                return fieldID;
            }
        }

        public string Name
        {
            get
            {
                return fieldName;
            }
            set
            {
                fieldName = value;
                TriggerProperyChanged("Name");
            }
        }

        public string Source
        {
            get
            {
                return fieldSource;
            }
            set
            {
                fieldSource = value;
                compiled = null;
            }
        }

        public bool Enabled
        {
            get
            {
                return fieldEnabled;
            }

            set
            {
                fieldEnabled = value;
                TriggerProperyChanged("Enabled");
            }
        }

        public bool IsCompiled
        {
            get
            {
                return compiled != null;
            }
        }

        public void Execute(Module modul)
        {
            if (fieldEnabled)
            {
                if (compiled == null)
                {
                    CompileCode();
                }

                if (compiled != null)
                {
                    RunScript(modul);
                }
            }
        }

        private void CompileCode()
        {
            Microsoft.CSharp.CSharpCodeProvider csProvider = new Microsoft.CSharp.CSharpCodeProvider();

            CompilerParameters options = new CompilerParameters();
            options.GenerateExecutable = false;
            options.GenerateInMemory = true;

            options.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

            CompilerResults result;
            result = csProvider.CompileAssemblyFromSource(options, fieldSource);

            if (result.Errors.HasErrors)
            {
                compiled = null;
                TriggerProperyChanged("IsCompiled");
            }
            else
            {
                if (result.Errors.HasWarnings)
                {
                    compiled = result.CompiledAssembly;
                    TriggerProperyChanged("IsCompiled");
                }
                else
                {
                    compiled = result.CompiledAssembly;
                    TriggerProperyChanged("IsCompiled");
                }
            }
        }

        private void RunScript(Module modul)
        {
            foreach (Type type in compiled.GetExportedTypes())
            {
                foreach (Type iface in type.GetInterfaces())
                {
                    if (iface == typeof(IScript))
                    {
                        ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
                        if (constructor != null && constructor.IsPublic)
                        {
                            IScript scriptObject = constructor.Invoke(null) as IScript;
                            if (scriptObject != null)
                            {
                                scriptObject.Execute(modul);
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                        }
                    }
                }
            }
        }

        private void TriggerProperyChanged(string PropertyName)
        {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(PropertyName);
            PropertyChanged(this, e);
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region IEditableObject Members

        public void BeginEdit()
        {
            tempName = fieldName;
            tempSource = fieldSource;
        }

        public void CancelEdit()
        {
            fieldName = tempName;
            fieldSource = tempSource;
        }

        public void EndEdit()
        {
        }

        #endregion
    }
}
