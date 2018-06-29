using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace WHEDU_OA_COMMONS
{
    public class SafeDirectoryCatalog:ComposablePartCatalog
    {
        private readonly AggregateCatalog _catalog;
        private readonly string _searchPattern = "*.dll";
        private readonly string _cryptdll = "crypt.dll";// C++库,不能装载
        private readonly string _vincryptdll = "aaa.dll";// C++库,不能装载
        private readonly string _sqliteInteropdll = "SQLite.Interop.dll";
        private readonly string _sqlitedll = "System.Data.SQLite.dll";
        private readonly string _ukeydll = "Win32Project2.dll";
        private readonly string _modelPath = "Modules";
        public SafeDirectoryCatalog(string directory)
        {
            List<string> lst = new List<string>();
            var files = Directory.EnumerateFiles(directory, _searchPattern, SearchOption.TopDirectoryOnly);
            lst = files.ToList();
            string modelPath = Path.Combine(directory, _modelPath);
            lst.AddRange(Directory.GetFiles(modelPath, _searchPattern));

            _catalog = new AggregateCatalog();

            foreach (var file in lst.Where(P => !P.Contains(_cryptdll) && !P.Contains(_sqliteInteropdll) && !P.Contains(_sqlitedll) && !P.Contains(_vincryptdll) && !P.Contains(_ukeydll)))
            {
                try
                {
                    AssemblyCatalog asmCat = new AssemblyCatalog(file);
                    if (asmCat.Parts.ToList().Count > 0)
                        _catalog.Catalogs.Add(asmCat);
                }
                catch (ReflectionTypeLoadException)
                {
                }
            }
        }
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return _catalog.Parts; }
        }
    }
}
