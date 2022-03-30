using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using portarias.API.Data;
using portarias.API.Models;

namespace portarias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _db;
        public AtividadeController(DataContext db)
        {
            _db = db;

        }

        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _db.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return _db.Atividades.FirstOrDefault(ativ => ativ.Id == id);
        }

        [HttpPost]
        public Atividade Post(Atividade atividade)
        {
            _db.Atividades.Add(atividade);
            if (_db.SaveChanges() > 0)
                return _db.Atividades.FirstOrDefault(atv => atv.Id == atividade.Id);

            throw new Exception("Falha ao adicionar uma atividade");

        }

        [HttpPut]
        public Atividade Put(int id, Atividade atividade)
        {
            if (atividade.Id != id) throw new Exception("Atividade errada.");

            _db.Update(atividade);
            if (_db.SaveChanges() > 0)
                return _db.Atividades.FirstOrDefault(atv => atv.Id == id);

            throw new Exception("Falha ao atualizar a atividade.");
        }



        [HttpDelete]
        public bool Delete(int id)
        {
            var atividade = _db.Atividades.FirstOrDefault(atv => atv.Id == id);
            if (atividade == null)
                throw new Exception("Ativiade não existe!");

            _db.Remove(atividade);
            return _db.SaveChanges() > 0;
        }

    }
}