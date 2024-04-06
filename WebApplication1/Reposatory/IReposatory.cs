namespace OnlineShopping.Reposatory
{
    public interface IReposatory<T> where T : class
    {

        List<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }
}
