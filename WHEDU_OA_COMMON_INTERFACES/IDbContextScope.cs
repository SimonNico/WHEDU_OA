using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHEDU_OA_COMMON_INTERFACES
{
    public interface IDbContextScope:IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        /// <summary>
        /// Saves the changes in all the DbContext instances that were created within this scope.
        /// This method can only be called once per scope.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancelToken);

        /// <summary>
        /// Reloads the provided persistent entities from the data store
        /// in the DbContext instances managed by the parent scope. 
        /// 
		/// If there is no parent scope (i.e. if this DbContextScope
		/// if the top-level scope), does nothing.
        /// 
        /// This is useful when you have forced the creation of a new
        /// DbContextScope and want to make sure that the parent scope
        /// (if any) is aware of the entities you've modified in the 
        /// inner scope.
        /// 
        /// (this is a pretty advanced feature that should be used 
        /// with parsimony). 
        /// </summary>
        void RefreshEntitiesInParentScope(IEnumerable entities);

        /// <summary>
        /// Reloads the provided persistent entities from the data store
        /// in the DbContext instances managed by the parent scope. 
        /// 
        /// If there is no parent scope (i.e. if this DbContextScope
        /// if the top-level scope), does nothing.
        /// 
        /// This is useful when you have forced the creation of a new
        /// DbContextScope and want to make sure that the parent scope
        /// (if any) is aware of the entities you've modified in the 
        /// inner scope.
        /// 
        /// (this is a pretty advanced feature that should be used 
        /// with parsimony). 
        /// </summary>
        Task RefreshEntitiesInParentScopeAsync(IEnumerable entities);

        /// <summary>
        /// The DbContext instances that this DbContextScope manages. Don't call SaveChanges() on the DbContext themselves!
        /// Save the scope instead.
        /// </summary>
        IDbContextCollection DbContexts { get; }
    }
}
