using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Master.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        //Operazioni CRUD - le firme

        public List<T> GetAll(); //Fetch
        public T Add(T item); // mi faccio tornate T -int,string un tipo
        public T Update(T item);
        public bool Delete(T item); // qui conviene bool
    }
}
