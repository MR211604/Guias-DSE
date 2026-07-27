using Biblioteca.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.BL.Interfaces
{
    public interface IEditorialService
    {
        public Task<List<EditorialDto>> GetAllEditorialesAsync();
        public Task<EditorialDto?> GetEditorialByIdAsync(int id);
        public Task<int> InsertEditorialAsync(EditorialDto editorialDto);
        public Task<EditorialDto?> UpdateEditorialAsync(EditorialDto editorialDto);
        public Task<bool> DeleteEditorialAsync(int id);
    }
}
