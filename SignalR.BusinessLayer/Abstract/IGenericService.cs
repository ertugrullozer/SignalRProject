using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Tadd(T entity);
        void Tupdate(T entity);
        void Tdelete(T entity);
        T TGetByID(int id);
        List<T> TGetListAll();
    }
}
