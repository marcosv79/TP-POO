﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Controllers;
using TP_POO.Models;

namespace TP_POO.Views
{
    public class CategoriaView
    {
        private CategoriaController categoriaController;

        public CategoriaView(CategoriaController controller)
        {
            categoriaController = controller;
        }

        public void MenuCategoria()
        {
            int op;
            do
            {
                Console.WriteLine("========== Categorias ==========");
                Console.WriteLine("1. Adicionar categoria");
                Console.WriteLine("2. Ver categorias");
                Console.WriteLine("3. Atualizar categoria");
                Console.WriteLine("4. Remover categoria");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out op))
                {
                    Opcao(op);
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            } while (op != 5);
        }

        private void Opcao(int op)
        {
            switch (op)
            {
                case 1:
                    Console.Clear();
                    AdicionarCategoriaView();
                    break;
                case 2:
                    Console.Clear();
                    VerCategoriasView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarCategoriaView();
                    break;
                case 4:
                    Console.Clear();
                    RemoverCategoriaView();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Voltando para o menu principal...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
        private void AdicionarCategoriaView()
        {
            Console.WriteLine("Insira o ID da categoria: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Insira o nome da categoria: ");
                string nome = Console.ReadLine();

                Categoria novaCategoria = new Categoria(id, nome);

                bool categoriaAdicionada = categoriaController.AdicionarCategoriaController(novaCategoria);

                if (categoriaAdicionada)
                {
                    Console.WriteLine("Categoria adicionada com sucesso");
                }
                else
                {
                    Console.WriteLine("Categoria já existente ou ID duplicado");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }



        private void VerCategoriasView()
        {
            var categorias = categoriaController.ListarCategoriasController();

            Console.WriteLine("Lista de categorias:\n");

            foreach (var categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.IdCategoria}, Nome: {categoria.Nome}");
            }

            Console.WriteLine();
        }


        private void AtualizarCategoriaView()
        {
            try
            {
                Console.WriteLine("Insira o ID da categoria para atualizar: ");
                int id = int.Parse(Console.ReadLine());

                Categoria categoriaExistente = categoriaController.findCategoriaById(id);

                if (categoriaExistente != null)
                {
                    Console.WriteLine("Insira o novo nome da categoria: ");
                    string novoNome = Console.ReadLine();

                    Categoria categoriaAtualizada = new Categoria(id, novoNome);
                    if (categoriaController.AdicionarCategoriaController(categoriaAtualizada))
                    {
                        Console.WriteLine("Categoria atualizada com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Categoria já existente");
                    }
                }
                else
                {
                    Console.WriteLine("Categoria não encontrada");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private void RemoverCategoriaView()
        {
            Console.Write("Digite o ID da categoria que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Categoria categoriaExistente = categoriaController.findCategoriaById(id);

            if (categoriaExistente != null)
            {
                categoriaController.RemoverCategoriaController(id);
                Console.WriteLine("Categoria removida com sucesso");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada.");
            }
        }
    }
}
