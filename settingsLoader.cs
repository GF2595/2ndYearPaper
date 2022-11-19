using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.PlatformUI;
using System.Windows;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell.Settings;
using System.ComponentModel.Composition;

namespace CourseWork
{
    static internal class SettingsLoader
    {
        static WritableSettingsStore writableSettingsStore;
        static private List<List<string>> typeSpecifications;
        const string CollectionPath = "types";
        const string PropertyName = "typeNames";
        static private Package package;
        static bool isNotLoaded = true;

        static SettingsLoader()
        {
        }

        static public void LoaderInit(Package pack)
        {
            typeSpecifications = new List<List<string>>();
            package = pack;
            var shellSettingsManager = new ShellSettingsManager(package);
            writableSettingsStore = shellSettingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);
            LoadSettings();
            isNotLoaded = false;
        }

        static internal List<List<string>> getSpecs()
        {
            if (isNotLoaded)
            {
                MessageBox.Show("Settings aren't loaded. Open 'Manage types specifications' menu to load.");
                return new List<List<string>>();
            }
            else
                return typeSpecifications;
        }

        static private void LoadSettings()
        {
            try
            {
                if (writableSettingsStore.PropertyExists(CollectionPath, PropertyName))
                {
                    string value = writableSettingsStore.GetString(CollectionPath, PropertyName);
                    string[] types = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < types.Length; i++)
                    {
                        typeSpecifications.Add(new List<string>());
                        typeSpecifications[i].Add(types[i]);
                        value = writableSettingsStore.GetString(CollectionPath, types[i]);
                        string[] temp = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string str in temp)
                            typeSpecifications[i].Add(str);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        static internal void SaveSettings(List<List<string>> specs)
        {
            if (writableSettingsStore.CollectionExists(CollectionPath))
                writableSettingsStore.DeleteCollection(CollectionPath);
            writableSettingsStore.CreateCollection(CollectionPath);
            typeSpecifications = specs;

            try
            {
                string[] types = new string[typeSpecifications.Count];
                string value = "";

                for (int i = 0; i < typeSpecifications.Count; i++)
                {
                    types[i] = typeSpecifications[i][0];
                    string[] temp = new string[typeSpecifications[i].Count - 1];

                    for (int j = 1; j < typeSpecifications[i].Count; j++)
                        temp[j - 1] = typeSpecifications[i][j];

                    value = string.Join(Environment.NewLine, temp);
                    writableSettingsStore.SetString(CollectionPath, typeSpecifications[i][0], value);
                }

                value = string.Join(Environment.NewLine, types);
                writableSettingsStore.SetString(CollectionPath, PropertyName, value);
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
    }
}
