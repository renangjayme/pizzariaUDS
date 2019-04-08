﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;
using Dominio.Servicos;

namespace Aplicacao
{
    public class ServicoDeAplicacaoDeTamanhos
    {
        ServicoDeDominioDeTamanhos servicoDeDominioDeTamanhos = new ServicoDeDominioDeTamanhos();

        public List<Tamanho> RecuperarTamanhos()
        {
            return servicoDeDominioDeTamanhos.RecuperarTamanhos();
        }
    }
}
