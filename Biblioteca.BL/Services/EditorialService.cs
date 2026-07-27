using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Dtos;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.Services
{
    public class EditorialService(IEditorialRepository repository, IMapper mapper) : IEditorialService
    {
        public async Task<List<EditorialDto>> GetAllEditorialesAsync()
        {
            try
            {
                var result = await repository.GetEditorialesAsync();
                return mapper.Map<List<Editorial>, List<EditorialDto>>(result);
            }
            catch (Exception e)
            {
                return new List<EditorialDto>();
            }
        }

        public async Task<EditorialDto?> GetEditorialByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetEditorialByIdAsync(id);
                if (result == null)
                    return null;
                return mapper.Map<Editorial, EditorialDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> InsertEditorialAsync(EditorialDto editorialDto)
        {
            try
            {
                var entity = mapper.Map<EditorialDto, Editorial>(editorialDto);
                return await repository.InsertEditorialAsync(entity);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<EditorialDto?> UpdateEditorialAsync(EditorialDto editorialDto)
        {
            try
            {
                var entity = mapper.Map<EditorialDto, Editorial>(editorialDto);
                var result = await repository.UpdateEditorialAsync(entity);
                if (result == null)
                    return null;
                return mapper.Map<Editorial, EditorialDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteEditorialAsync(int id)
        {
            try
            {
                return await repository.DeleteEditorialAsync(id);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
