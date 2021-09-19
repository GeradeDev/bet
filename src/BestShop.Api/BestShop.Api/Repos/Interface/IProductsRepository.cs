using BestShop.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestShop.Repos.Interface
{
    public interface IProductsRepository : IDisposable
    {
        IEnumerable<Product> GetStudents();
        Product GetProductByCode(string code);
        void InsertStudent(Product student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Product student);
        void Save();
    }
}