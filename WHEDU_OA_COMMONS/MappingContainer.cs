using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;

namespace WHEDU_OA_COMMONS
{
    public class MappingContainer
    {
        #region 单例模式
        static object _Lock = new object();
        static MappingContainer _XContainer;
        public static MappingContainer GetInstance
        {
            get
            {
                if (_XContainer == null)
                {
                    lock (_Lock)
                    {
                        if (_XContainer == null)
                            _XContainer = new MappingContainer();
                    }
                }
                return _XContainer;
            }
        }
        #endregion
        CompositionContainer _Container;
        private MappingContainer()
        {
            var catalog = new SafeDirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
            _Container = new CompositionContainer(catalog);
        }

        public IEnumerable<IMapping> GetExportedValues(string contractName)
        {
            return _Container.GetExportedValues<IMapping>(contractName);
        }
    }
}
