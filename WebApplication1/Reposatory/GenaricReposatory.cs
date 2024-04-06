using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace OnlineShopping.Reposatory
{
    public class GenaricReposatory<T> : IReposatory<T> where T : class
    {

        readonly Context context;
        private DbSet<T> table;


        public GenaricReposatory(Context context)
        {


            this.context = context;
            table = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(int id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {

            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Update(obj);
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
