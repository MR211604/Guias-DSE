using Biblioteca.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.DAL.Interfaces
{
    public interface IEditorialRepository
    {
        public Task<List<Editorial>> GetEditorialesAsync();
        public Task<Editorial?> GetEditorialByIdAsync(int id);
        public Task<int> InsertEditorialAsync(Editorial editorial);
        public Task<Editorial?> UpdateEditorialAsync(Editorial editorial);
        public Task<bool> DeleteEditorialAsync(int id);

    }
}
