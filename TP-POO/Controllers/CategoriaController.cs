﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Models;
using System.IO;
using System.Text.Json;


namespace TP_POO.Controllers
{
    [Serializable]
    public class CategoriaController
    {
        #region Attributes

        private List<Categoria> categorias = new List<Categoria>();

        #endregion

        #region Methods

        /// <summary>
        /// Método para encontrar uma categoria através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Categoria findCategoriaById(int id)
        {
            return categorias.Find(c => c.IdCategoria == id);
        }

        /// <summary>
        /// Método para adicionar uma nova categoria
        /// </summary>
        /// <param name="novaCategoria"></param>
        /// <returns></returns>
        public bool AdicionarCategoriaController(Categoria novaCategoria)
        {
            if (categorias.Any(c => c.IdCategoria == novaCategoria.IdCategoria))
            {
                return false;
            }

            if (categorias.Any(c => c.Nome.Equals(novaCategoria.Nome, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            categorias.Add(novaCategoria);
            return true;
        }

        /// <summary>
        /// Método para listar as categorias existentes
        /// </summary>
        /// <returns></returns>
        public List<Categoria> ListarCategoriasController()
        {
            return categorias;
        }

        /// <summary>
        /// Método para atualizar uma categoria
        /// </summary>
        /// <param name="categoriaAtualizada"></param>
        /// <returns></returns>
        public bool AtualizarCategoriaController(Categoria categoriaAtualizada)
        {
            Categoria categoriaExistente = findCategoriaById(categoriaAtualizada.IdCategoria);

            if (categoriaExistente != null)
            {
                if (categorias.Any(c => c.IdCategoria != categoriaAtualizada.IdCategoria && c.Nome.Equals(categoriaAtualizada.Nome, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
                categoriaExistente.Nome = categoriaAtualizada.Nome;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para remover uma categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoverCategoriaController(int id)
        {
            Categoria categoriaExistente = findCategoriaById(id);

                if (categoriaExistente != null)
                {
                    categorias.Remove(categoriaExistente);
                    return true;
                }
                return false;
        }

        /// <summary>
        /// Método para guardas as categorias num ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GuardarCategoriasBin(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, categorias);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Método para carregar as categorias a partir de um ficheiro binário
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool CarregarCategoriasBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    categorias = (List<Categoria>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            } 
            return false;
        }
        public bool GuardarCategoriasJSON(string fileName)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions //Cria o objeto JsonSerializerOptions para configurar o processo de serealizaçao em json
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, //Permite uso de caracteres especiais
                    WriteIndented = true //Permite a formataçao com quebras de linha para ficar mais facilmente legivel
                };

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var categoria in categorias)
                    {
                        string json = JsonSerializer.Serialize(categoria, options);
                        writer.WriteLine(json);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return false;
            }
        }


        #endregion
    }
}