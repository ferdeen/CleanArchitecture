using Microsoft.EntityFrameworkCore;

namespace PaxosExercise.Infrastructure.Data
{
    public static class EfExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class 
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
