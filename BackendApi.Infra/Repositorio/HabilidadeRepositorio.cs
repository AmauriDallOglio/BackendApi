﻿using BackendApi.Dominio.Entidade;
using BackendApi.Dominio.InterfaceRepositorio;
using BackendApi.Infra.Context;
using BackendApi.Infra.Modelo;

namespace BackendApi.Infra.Repositorio
{
    public class HabilidadeRepositorio : RepositorioGenerico<Habilidade>, IHabilidadeRepositorio
    {
        private readonly MeuContext _contexto;
        public HabilidadeRepositorio(MeuContext dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }

        public List<Habilidade> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<Habilidade>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.Habilidade.ToList();
            }
            else
            {
                resultado = _contexto.Habilidade.Where(b => b.Descricao.Contains(descricao)).ToList();
            }
            return resultado;
        }

    }
}
