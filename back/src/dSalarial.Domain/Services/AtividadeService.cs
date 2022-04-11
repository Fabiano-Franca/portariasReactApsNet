using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dSalarial.Domain.Entities;
using dSalarial.Domain.Interfaces;
using dSalarial.Domain.Interfaces.Services;

namespace dSalarial.Domain.Services
{
    public class AtividadeService : IAtividadeService
    {
        public IAtividadeRepo _atividadeRepo { get; }

        public AtividadeService(IAtividadeRepo atividadeRepo)
        {
            _atividadeRepo = atividadeRepo;
        }

        public async Task<Atividade> AdicionarAtividade(Atividade model)
        {
            if (await _atividadeRepo.PegaPorTituloAsync(model.Titulo) != null)
                throw new Exception("Já exiiste uma atividade com esse título");

            if (await _atividadeRepo.PegaPorIdAsync(model.Id) == null)
            {
                _atividadeRepo.Adicionar(model);
                if (await _atividadeRepo.SalvarMudançasAsync())
                    return model;
            }

            return null;
        }

        public async Task<Atividade> AtualizarAtividade(Atividade model)
        {
            if (model.DataConclusao != null)
                throw new Exception("Não se pode alterar atividade já concluída");

            if (await _atividadeRepo.PegaPorIdAsync(model.Id) != null)
            {
                _atividadeRepo.Atualizar(model);
                if (await _atividadeRepo.SalvarMudançasAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> ConcluirAtividade(Atividade model)
        {
            if (model != null)
            {
                model.Concluir();
                _atividadeRepo.Atualizar<Atividade>(model);
                return await _atividadeRepo.SalvarMudançasAsync();
            }

            return false;
        }

        public async Task<bool> DeletarAtividade(int atividadeId)
        {
            var atividade = await _atividadeRepo.PegaPorIdAsync(atividadeId);
            if (atividade == null) throw new Exception("Atividade que tentou deletar não existe");

            _atividadeRepo.Deletar(atividade);
            return await _atividadeRepo.SalvarMudançasAsync();
        }

        public async Task<Atividade> PegarAtividadePorIdAsync(int atividadeId)
        {
            try
            {
                var atividade = await _atividadeRepo.PegaPorIdAsync(atividadeId);
                if (atividade == null) return null;

                return atividade;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Atividade[]> PegarTodasAtividadesAsync()
        {
            try
            {
                var atividades = await _atividadeRepo.PegaTodasAsync();
                if (atividades == null) return null;

                return atividades;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
        }
    }
}