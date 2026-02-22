using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using ProjectApiCrud.DataContext;
using ProjectApiCrud.Models;

namespace ProjectApiCrud.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {

            _context = context;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            var serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Sucess = false;

                    return serviceResponse;
                }

                _context.Funcionarios.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionario created successfully.";

            } catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = $"An error occurred while creating funcionario: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                var funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                
                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Funcionario not found.";
                    serviceResponse.Sucess = false;

                }
                _context.Funcionarios.Remove(funcionario!);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionario deleted successfully.";

            } catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = $"An error occurred while deleting funcionario: {ex.Message}";
            }
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);


                if (funcionario != null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Funcionario retrieved successfully.";
                    serviceResponse.Sucess = false;
                }

                serviceResponse.Data = funcionario;

            } catch (Exception ex)
            {
                serviceResponse.Message = $"An error occurred while retrieving funcionario by id: {ex.Message}";
                serviceResponse.Sucess = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionarios retrieved successfully.";
            } catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = $"An error occurred while retrieving funcionarios: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InactiveFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Funcionario not found.";
                    serviceResponse.Sucess = false;
                    return serviceResponse;
                }
                funcionario.IsActive = false;
                funcionario.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionario inactivated successfully.";

            } catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = $"An error occurred while retrieving funcionarios: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);
                if (funcionario == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Funcionario not found.";
                    serviceResponse.Sucess = false;

                }


                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionario updated successfully.";
            } catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = $"An error occurred while updating funcionario: {ex.Message}";
            }
            return serviceResponse;
        }
    }
}
