using System.Data.Entity.ModelConfiguration.Configuration;

namespace WHEDU_OA_COMMONS
{
    public interface IMapping
    {
        void RegistTo(ConfigurationRegistrar configurationRegistrar);
    }
}
